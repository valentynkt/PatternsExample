using System;
using System.Collections.Generic;
using System.Text;

namespace Builder.Conceptual
{
    public class Shop
    {
        // Builder uses a complex series of steps
        public void Construct(VehicleBuilder vehicleBuilder)
        {
            vehicleBuilder.BuildFrame();
            vehicleBuilder.BuildEngine();
            vehicleBuilder.BuildWheels();
            vehicleBuilder.BuildDoors();
        }
    }

    /// <summary>
    /// The 'Builder' abstract class
    /// </summary>
    public abstract class VehicleBuilder
    {
        private Vehicle _vehicle;
        // Gets vehicle instance

        public Vehicle GetVehicle()
        {
            var vehicle = this._vehicle;
            this._vehicle = null;
            return vehicle;
        }
        // Abstract build methods
        public abstract void BuildFrame();
        public abstract void BuildEngine();
        public abstract void BuildWheels();
        public abstract void BuildDoors();

        public void ShowVehicleParts()
        {
            Console.WriteLine(_vehicle.Show());
        }
    }

    // <summary>
    /// The 'ConcreteBuilder1' class
    /// </summary>
    class MotorCycleBuilder : VehicleBuilder
    {
        private Vehicle _vehicle;

        public MotorCycleBuilder()
        {
            Reset();
        }
        public override void BuildFrame()
        {
            _vehicle["frame"] = "MotorCycle Frame";
        }
        public override void BuildEngine()
        {
            _vehicle["engine"] = "500 cc";
        }
        public override void BuildWheels()
        {
            _vehicle["wheels"] = "2";
        }
        public override void BuildDoors()
        {
            _vehicle["doors"] = "0";
        }
        public void Reset()
        {
            this._vehicle = new Vehicle("MotorCycle"); ;
        }
    }

    /// <summary>
    /// The 'ConcreteBuilder2' class
    /// </summary>
    class CarBuilder : VehicleBuilder
    {
        private Vehicle _vehicle;
        public CarBuilder()
        {
            _vehicle = new Vehicle("Car");
        }
        public override void BuildFrame()
        {
            _vehicle["frame"] = "Car Frame";
        }
        public override void BuildEngine()
        {
            _vehicle["engine"] = "2500 cc";
        }
        public override void BuildWheels()
        {
            _vehicle["wheels"] = "4";
        }
        public override void BuildDoors()
        {
            _vehicle["doors"] = "4";
        }
        public void Reset()
        {
            this._vehicle = new Vehicle("Car"); ;
        }
    }
    /// <summary>
    /// The 'ConcreteBuilder3' class
    /// </summary>
    class ScooterBuilder : VehicleBuilder
    {
        private Vehicle _vehicle;
        public ScooterBuilder()
        {
            Reset();
        }
        public override void BuildFrame()
        {
            _vehicle["frame"] = "Scooter Frame";
        }
        public override void BuildEngine()
        {
            _vehicle["engine"] = "50 cc";
        }
        public override void BuildWheels()
        {
            _vehicle["wheels"] = "2";
        }
        public override void BuildDoors()
        {
            _vehicle["doors"] = "0";
        }
        public void Reset()
        {
            this._vehicle = new Vehicle("Scooter"); ;
        }
    }

    /// <summary>
    /// The 'Product' class
    /// </summary>
    public class Vehicle
    {
        private readonly string _vehicleType;
        private readonly Dictionary<string, string> _parts =
          new Dictionary<string, string>();
        // Constructor
        public Vehicle(string vehicleType)
        {
            this._vehicleType = vehicleType;
        }

        // Indexer
        public string this[string key]
        {
            get { return _parts[key]; }
            set { _parts[key] = value; }
        }

        public string Show()
        {
            var showString =
                "\n--------------------------"
                + $"\nVehicle Type: {_vehicleType}"
                + $"\nFrame : {_parts["frame"]}"
                + $"\nEngine : {_parts["engine"]}"
                + $"\n#Wheels: {_parts["wheels"]}"
                + $"\n#Doors : {_parts["doors"]}";
            return showString;
        }
    }
}
