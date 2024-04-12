// Template Method Design Pattern
//
// Intent: Defines the skeleton of an algorithm in the superclass but lets
// subclasses override specific steps of the algorithm without changing its
// structure.

using System;

namespace TemplateMethod.Conceptual
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
            Console.WriteLine("Starting the game simulation...\n");

            // Create an instance of OrcsAI and simulate a turn
            GameAI orcsAI = new OrcsAI();
            Console.WriteLine("Orcs' turn:");
            orcsAI.Turn();
            Console.WriteLine();

            // Create an instance of MonstersAI and simulate a turn
            GameAI monstersAI = new MonstersAI();
            Console.WriteLine("Monsters' turn:");
            monstersAI.Turn();
            Console.WriteLine();

            Console.WriteLine("Game simulation completed.");
        }
        private static void ConceptualExample()
        {
            Console.WriteLine("Same client code can work with different subclasses:");

            Client.ClientCode(new ConcreteClass1());

            Console.Write("\n");

            Console.WriteLine("Same client code can work with different subclasses:");
            Client.ClientCode(new ConcreteClass2());
        }
    }
}
