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
            //this should be calculated from configs not hardcoded
            string configOS = "Windows";
            var service = new SomeService(configOS);
            //paint without knowing IGUIFactory. We can encapsulate this abstract factory in this moment and use method that will work with this factory
            Console.WriteLine("The moment we can encapsulate all abstraction, factories and all elements but still render elements using this method");
            service.PaintAllElements();

            //in this moment we can call our higher abstractions and directly work with factory and abstraction elements but concrete factory and elements are still hidden from us
            Console.WriteLine("The moment we know about abstractions and can work with them directly but concrete factories and products are hidden from us");
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