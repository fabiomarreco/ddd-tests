using System;
namespace SepareteClasses.ChildInterface
{
    public class Car
    {
        public Tire FrontLefTire { get; private set; }
        public Tire FrontRightTire { get; private set; }
        public Tire RearLeftTire { get; private set; }
        public Tire RearRightTire { get; private set; }


        public void AddMilage (double milage)
        {
            ((IWritableTire)FrontLefTire).AddMilage(milage);
            ((IWritableTire)FrontRightTire).AddMilage(milage);
            ((IWritableTire)RearLeftTire).AddMilage(milage);
            ((IWritableTire)RearRightTire).AddMilage(milage);
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

        public interface IWritableTire 
        {
            void AddMilage(double milage);
        }

            
    }


    
        public class Tire : Car.IWritableTire
        {
            public double Milage { get; private set;  }
            public DateTime PurchaseDate { get; set; }
            public string ID { get; set; }
            void Car.IWritableTire.AddMilage(double milage) => Milage += milage;
        }


    public class SomeService
    {
        public void Execute()
        {
            Car car = new Car();

            car.AddMilage(200); // Adds Milage to all tires, 

            //car.FrontLefTire.AddMilage(200); //#Error: Not accessible - Invariants were inforced

        }
    }
}

