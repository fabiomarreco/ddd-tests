using System;
namespace SepareteClasses.ChildClass
{
    public class Car
    {
        public Tire FrontLefTire { get; private set; }
        public Tire FrontRightTire { get; private set; }
        public Tire RearLeftTire { get; private set; }
        public Tire RearRightTire { get; private set; }


        public void AddMilage (double milage)
        {
            // Does not work
            

            // FrontLefTire.AddMilage(milage);
            // FrontRightTire.AddMilage(milage);
            // RearLeftTire.AddMilage(milage);
            // RearRightTire.AddMilage(milage);
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


        public class Tire
        {
            public double Milage { get; private set;  }
            public DateTime PurchaseDate { get; set; }
            public string ID { get; set; }
            private void AddMilage(double milage) => Milage += milage;
        }
            
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

