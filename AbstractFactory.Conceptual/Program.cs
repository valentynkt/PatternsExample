// Abstract Factory Design Pattern
//
// Intent: Lets you produce families of related objects without specifying their
// concrete classes.

using System;

namespace AbstractFactory.Conceptual
{
    class Program
    {
        static void Main(string[] args)
        {
            RealExample();
            ConceptualExample();
        }

        private static void RealExample()
        {
            IGUIFactory factory;
            // Configuration for OS type, should be set based on actual system settings
            string configOS = "Windows";
            var service = new SomeService(configOS);

            // Paint GUI elements without direct access to the factory
            Console.WriteLine("Rendering GUI elements using encapsulated factory methods.");
            service.PaintAllElements();

            // Accessing factory and GUI elements through an abstraction layer
            Console.WriteLine("Accessing GUI elements through factory abstraction.");
            factory = service.GetFactory();
            var button = factory.CreateButton();
            var checkBox = factory.CreateCheckBox();
            button.Paint();
            checkBox.Paint();

        }

        private static void ConceptualExample()
        {
            new Client().Main();
        }
    }
}