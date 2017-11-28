
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



}


public class Tire
{
    public double Milage { get; private set;  }
    public DateTime PurchaseDate { get; set; }
    public string ID { get; set; }
    public void AddMilage(double milage) => Milage += milage;
}
