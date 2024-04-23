// Chain of Responsibility Design Pattern
//
// Intent: Lets you pass requests along a chain of handlers. Upon receiving a
// request, each handler decides either to process the request or to pass it to
// the next handler in the chain.

using System;

namespace ChainOfResponsibility.Conceptual
{
    class Program
    {
        static void Main(string[] args)
        {
            ConceptualExample();
        }

        private static void ConceptualExample()
        {
            // The other part of the client code constructs the actual chain.
            var monkey = new MonkeyHandler();
            var squirrel = new SquirrelHandler();
            var dog = new DogHandler();

            monkey.SetNext(squirrel).SetNext(dog);

            // The client should be able to send a request to any handler, not
            // just the first one in the chain.
            Console.WriteLine("Chain: Monkey > Squirrel > Dog\n");
            Client.ClientCode(monkey);
            Console.WriteLine();

            Console.WriteLine("Subchain: Squirrel > Dog\n");
            Client.ClientCode(squirrel);
        }
    }
}
