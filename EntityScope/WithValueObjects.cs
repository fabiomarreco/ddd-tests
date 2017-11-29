using System;
namespace SepareteClasses.WithValueObjects
{
    public abstract class ValueObject{
        // override equals, etc...
    }


    public class Car
    {
        private  Tire _frontRightTire;
        private  Tire _rearLeftTire;
        private  Tire _rearRightTire;
        private  Tire _frontLefTire;

        public TireState GetFrontRightTire() => new TireState(_frontRightTire.Milage, _frontRightTire.PurchaseDate);
        //... Methods for other tires


        public void AddMilage(double milage)
        {
            _frontLefTire.AddMilage(milage);
            _frontRightTire.AddMilage(milage);
            _rearLeftTire.AddMilage(milage);
            _rearRightTire.AddMilage(milage);
        }

        public void RotateTires()
        {
            var oldFrontLefTire = _frontLefTire;
            var oldFrontRightTire = _frontRightTire;
            var oldRearLeftTire = _rearLeftTire;
            var oldRearRightTire = _rearRightTire;

            _rearRightTire = oldFrontLefTire;
            _frontRightTire = oldRearRightTire;
            _rearLeftTire = oldFrontRightTire;
            _frontLefTire = oldRearLeftTire;
        }

    }



    public class Tire 
    {
        public double Milage { get; private set; }
        public DateTime PurchaseDate { get; set; }
        public string ID { get; set; }
        public void AddMilage(double milage) => Milage += milage;
    }


    public class TireState : ValueObject
    {
        public readonly double Milage;
        public readonly DateTime PurchaseDate;

        public TireState(double milage, DateTime purchaseDate)
        {
            Milage = milage;
            PurchaseDate = purchaseDate;
        }
    }


    public class SomeService
    {
        public void Execute()
        {
            Car car = new Car();
            car.AddMilage(200); // Adds Milage to all tires, 

            TireState state = car.GetFrontRightTire(); // tirestate immutable, invariants preserved - OK
        }
    }

}

