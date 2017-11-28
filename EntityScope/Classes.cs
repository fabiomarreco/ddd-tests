using System;

public class Car
{
    public Tire FrontLefTire { get; private set; }
    public Tire FrontRightTire { get; private set; }
    public Tire BackLeftTire { get; private set; }
    public Tire BackRightTire { get; private set; }


    public void AddMilage (double milage)
    {
        FrontLefTire.Milage += milage;
        FrontRightTire.Milage += milage;
        BackLeftTire.Milage += milage;
        BackRightTire.Milage += milage;
    }
}


public class Tire
{
    public double Milage { get; set; }
    public DateTime PurchaseDate { get; set; }
    public string ID { get; set; }
}