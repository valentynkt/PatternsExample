// Flyweight Design Pattern
//
// Intent: Lets you fit more objects into the available amount of RAM by sharing
// common parts of state between multiple objects, instead of keeping all of the
// data in each object.

using System;
// Use Json.NET library, you can download it from NuGet Package Manager

namespace Flyweight.Conceptual
{
    class Program
    {
        static void Main(string[] args)
        {
            RealWorldExample();
            ConceptualExample();
        }

        private static void RealWorldExample()
        {
            Forest forest = new Forest();
            forest.PlantTree(1, 2, "Pine", "Green", "Needle");
            forest.PlantTree(5, 3, "Oak", "Brown", "Leaf");

            // Draw the forest
            forest.Draw();
        }

        private static void ConceptualExample()
        {
            // The client code usually creates a bunch of pre-populated
            // flyweights in the initialization stage of the application.
            var factory = new FlyweightFactory(
                new Car { Company = "Chevrolet", Model = "Camaro2018", Color = "pink" },
                new Car { Company = "Mercedes Benz", Model = "C300", Color = "black" },
                new Car { Company = "Mercedes Benz", Model = "C500", Color = "red" },
                new Car { Company = "BMW", Model = "M5", Color = "red" },
                new Car { Company = "BMW", Model = "X6", Color = "white" }
            );
            factory.listFlyweights();

            addCarToPoliceDatabase(factory, new Car
            {
                Number = "CL234IR",
                Owner = "James Doe",
                Company = "BMW",
                Model = "M5",
                Color = "red"
            });

            addCarToPoliceDatabase(factory, new Car
            {
                Number = "CL234IR",
                Owner = "James Doe",
                Company = "BMW",
                Model = "X1",
                Color = "red"
            });

            factory.listFlyweights();
        }

        public static void addCarToPoliceDatabase(FlyweightFactory factory, Car car)
        {
            Console.WriteLine("\nClient: Adding a car to database.");

            var flyweight = factory.GetFlyweight(new Car
            {
                Color = car.Color,
                Model = car.Model,
                Company = car.Company
            });

            // The client code either stores or calculates extrinsic state and
            // passes it to the flyweight's methods.
            flyweight.Operation(car);
        }
    }
}
