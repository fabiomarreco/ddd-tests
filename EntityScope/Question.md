I´m trying to understand how to represent certain DDD (Domain Driven Design) rules.
Following the Blue Book convention we have:

- The root Entity has global identity and is responsible for checking invariants.
- The root entity controls access and cannot be blindsided by changes to its internals.
- Transient references to internal members can be passed out for use withing a single operation only.

I´m having a hard time to find the best way to enforce the invariants when clients can have access to internal entities. 

This problem of course only happens if the child entity is mutable.

Supose this toy example where you have a `Car` with four `Tire`(s). I want to track the usage of each `Tire` idependently.

Clearly `Car` is a *Aggregate Root* and `Tire` is an *Child Entity*.

> **Business Rule**: Milage cannot be added to to a single `Tire`. Milage can only be added to all 4 tires, when attached to a `Car`


A *naive* implementation would be:

```csharp
public class Tire
{
    public double Milage { get; private set;  }
    public DateTime PurchaseDate { get; set; }
    public string ID { get; set; }
    public void AddMilage(double milage) => Milage += milage;
}

public class Car
{
    public Tire FrontLefTire { get; private set; }
    public Tire FrontRightTire { get; private set; }
    public Tire RearLeftTire { get; private set; }
    public Tire RearRightTire { get; private set; }

    public void AddMilage (double milage)
    {
        FrontLefTire.AddMilage(milage);
        FrontRightTire.AddMilage(milage);
        RearLeftTire.AddMilage(milage);
        RearRightTire.AddMilage(milage);
    }

    public void RotateTires()
    {
        var oldFrontLefTire = FrontLefTire;
        var oldFrontRightTire = FrontRightTire;
        var oldRearLeftTire = RearLeftTire;
        var oldRearRightTire = RearRightTire;

        RearRightTire = oldFrontLefTire;
        FrontRightTire = oldRearRightTire;
        RearLeftTire = oldFrontRightTire;
        FrontLefTire = oldRearLeftTire;
    }

    //...
}
```

But the `Tire.AddMilage` method is public, meaning any service *could* do something like this:

```csharp
Car car = new Car(); //...

// Adds Milage to all tires, respecting invariants - OK
car.AddMilage(200); 

//corrupt access to front tire, change milage of single tire on car violating business rules - ERROR
car.FrontLefTire.AddMilage(200); 
```

Possible solutions that crossed my mind:

1. Create `events` on `Tire` to validate the change, and implement it on `Car`
2. Make `Car` a factory of `Tire`, passing a *`TireState`* on its contructor, and holding a reference to it.


But I feel there should be an easier way to do this.

What do you think ?