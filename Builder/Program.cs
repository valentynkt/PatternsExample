// Builder Design Pattern
//
// Intent: Lets you construct complex objects step by step. The pattern allows
// you to produce different types and representations of an object using the
// same construction code.

using System;

namespace Builder.Conceptual
{
    class Program
    {
        static void Main(string[] args)
        {
            RealCarExampleSimplify();
            ConceptualExample();
        }

        private static void RealCarExampleSimplify()
        {
            Shop shop = new Shop();

            // Test building a Scooter
            VehicleBuilder scooterBuilder = new ScooterBuilder();
            shop.Construct(scooterBuilder);
            Vehicle scooter = scooterBuilder.GetVehicle();
            Console.WriteLine(scooter.Show());

            // Test building a Car
            VehicleBuilder carBuilder = new CarBuilder();
            shop.Construct(carBuilder);
            Vehicle car = carBuilder.GetVehicle();
            Console.WriteLine(car.Show());

            // Test building a Motorcycle
            VehicleBuilder motorcycleBuilder = new MotorCycleBuilder();
            shop.Construct(motorcycleBuilder);
            Vehicle motorcycle = motorcycleBuilder.GetVehicle();
            Console.WriteLine(motorcycle.Show());

            // Wait for user to view output
            Console.ReadKey();
        }

        private static void ConceptualExample()
        {
            // The client code creates a builder object, passes it to the
            // director and then initiates the construction process. The end
            // result is retrieved from the builder object.
            var director = new Director();
            var builder = new ConcreteBuilder();
            director.Builder = builder;

            Console.WriteLine("Standard basic product:");
            director.BuildMinimalViableProduct();
            Console.WriteLine(builder.GetProduct().ListParts());

            Console.WriteLine("Standard full featured product:");
            director.BuildFullFeaturedProduct();
            Console.WriteLine(builder.GetProduct().ListParts());

            // Remember, the Builder pattern can be used without a Director
            // class.
            Console.WriteLine("Custom product:");
            builder.BuildPartA();
            builder.BuildPartC();
            Console.Write(builder.GetProduct().ListParts());
        }
    }
}
