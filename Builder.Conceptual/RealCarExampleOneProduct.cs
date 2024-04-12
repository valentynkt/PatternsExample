using System.Collections.Generic;

namespace Builder.Conceptual
{
    // The 'Director' class
    public class Shop
    {
        // Orchestrates the build steps
        public void Construct(VehicleBuilder vehicleBuilder)
        {
            vehicleBuilder.Reset();
            vehicleBuilder.BuildFrame();
            vehicleBuilder.BuildEngine();
            vehicleBuilder.BuildWheels();
            vehicleBuilder.BuildDoors();
        }
    }

    // The 'Builder' abstract class
    public abstract class VehicleBuilder
    {
        protected Vehicle vehicle;

        // Resets the builder with a new vehicle instance
        public virtual void Reset() { }

        // Returns the built vehicle and resets the builder
        public Vehicle GetVehicle()
        {
            var result = vehicle;
            Reset();
            return result;
        }

        // Abstract build methods
        public abstract void BuildFrame();
        public abstract void BuildEngine();
        public abstract void BuildWheels();
        public abstract void BuildDoors();
    }

    // 'ConcreteBuilder' for Motorcycles
    public class MotorCycleBuilder : VehicleBuilder
    {
        public override void Reset()
        {
            vehicle = new Vehicle("MotorCycle");
        }

        public override void BuildFrame()
        {
            vehicle["frame"] = "MotorCycle Frame";
        }

        public override void BuildEngine()
        {
            vehicle["engine"] = "500 cc";
        }

        public override void BuildWheels()
        {
            vehicle["wheels"] = "2";
        }

        public override void BuildDoors()
        {
            vehicle["doors"] = "0"; // Motorcycles don't have doors
        }
    }

    // 'ConcreteBuilder' for Cars
    public class CarBuilder : VehicleBuilder
    {
        public override void Reset()
        {
            vehicle = new Vehicle("Car");
        }

        public override void BuildFrame()
        {
            vehicle["frame"] = "Car Frame";
        }

        public override void BuildEngine()
        {
            vehicle["engine"] = "2500 cc";
        }

        public override void BuildWheels()
        {
            vehicle["wheels"] = "4";
        }

        public override void BuildDoors()
        {
            vehicle["doors"] = "4";
        }
    }

    // 'ConcreteBuilder' for Scooters
    public class ScooterBuilder : VehicleBuilder
    {
        public override void Reset()
        {
            vehicle = new Vehicle("Scooter");
        }

        public override void BuildFrame()
        {
            vehicle["frame"] = "Scooter Frame";
        }

        public override void BuildEngine()
        {
            vehicle["engine"] = "50 cc";
        }

        public override void BuildWheels()
        {
            vehicle["wheels"] = "2";
        }

        public override void BuildDoors()
        {
            vehicle["doors"] = "0"; // Scooters don't have doors
        }
    }

    // The 'Product' class
    public class Vehicle
    {
        private readonly string vehicleType;
        private readonly Dictionary<string, string> parts = [];

        public Vehicle(string vehicleType)
        {
            this.vehicleType = vehicleType;
        }

        public string this[string key]
        {
            get => parts.ContainsKey(key) ? parts[key] : null;
            set => parts[key] = value;
        }

        public string Show()
        {
            return $"\n--------------------------\n" +
                   $"Vehicle Type: {vehicleType}\n" +
                   $"Frame: {this["frame"]}\n" +
                   $"Engine: {this["engine"]}\n" +
                   $"#Wheels: {this["wheels"]}\n" +
                   $"#Doors: {this["doors"]}";
        }
    }
}
