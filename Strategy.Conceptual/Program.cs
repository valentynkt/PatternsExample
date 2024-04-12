// Strategy Design Pattern
//
// Intent: Lets you define a family of algorithms, put each of them into a
// separate class, and make their objects interchangeable.
// add alias
using Strategy.Conceptual.Conceptual;
using System;

namespace Strategy.Conceptual
{
    class Program
    {
        static void Main(string[] args)
        {
            CalculatorExample();
            ConceptualExample();
        }

        private static void CalculatorExample()
        {
            var context = new Calculator.Context();
            Console.WriteLine("Enter the first number:");
            int firstNumber = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the second number:");
            int secondNumber = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the desired action (addition, subtraction, multiplication):");
            string action = Console.ReadLine();

            switch (action)
            {
                case "addition":
                    context.SetStrategy(new Calculator.ConcreteStrategyAdd());
                    break;
                case "subtraction":
                    context.SetStrategy(new Calculator.ConcreteStrategySubtract());
                    break;
                case "multiplication":
                    context.SetStrategy(new Calculator.ConcreteStrategyMultiply());
                    break;
            }

            int result = context.ExecuteStrategy(firstNumber, secondNumber);
            Console.WriteLine($"Result: {result}");
        }

        private static void ConceptualExample()
        {
            // The client code picks a concrete strategy and passes it to the
            // context. The client should be aware of the differences between
            // strategies in order to make the right choice.
            var context = new Context();

            Console.WriteLine("Client: Strategy is set to normal sorting.");
            context.SetStrategy(new ConcreteStrategyA());
            context.DoSomeBusinessLogic();

            Console.WriteLine();

            Console.WriteLine("Client: Strategy is set to reverse sorting.");
            context.SetStrategy(new ConcreteStrategyB());
            context.DoSomeBusinessLogic();
        }
    }
}
