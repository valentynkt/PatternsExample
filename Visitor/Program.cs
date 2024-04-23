// Visitor Design Pattern
//
// Intent: Lets you separate algorithms from the objects on which they operate.

using System;
using System.Collections.Generic;
using Visitor.Conceptual.ConceptualExample;
using Visitor.Conceptual.ShapeExample;
namespace Visitor.Conceptual
{
    class Program
    {
        static void Main(string[] args)
        {
            // RealExample
            Application.Run();
            // ConceptualExample
            ConceptualExample();
        }


        private static void ConceptualExample()
        {
            List<IComponent> components =
            [
                new ConcreteComponentA(),
                new ConcreteComponentB()
            ];

            Console.WriteLine("The client code works with all visitors via the base Visitor interface:");
            var visitor1 = new ConcreteVisitor1();
            Client.ClientCode(components, visitor1);

            Console.WriteLine();

            Console.WriteLine("It allows the same client code to work with different types of visitors:");
            var visitor2 = new ConcreteVisitor2();
            Client.ClientCode(components, visitor2);
        }
    }
}
