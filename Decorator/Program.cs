// Decorator Design Pattern
//
// Intent: Lets you attach new behaviors to objects by placing these objects
// inside special wrapper objects that contain the behaviors.

using System;

namespace Decorator.Conceptual
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
            // Example usage
            var app = new Application();
            app.DumbUsageExample();

            var configurator = new ApplicationConfigurator();
            var dataSource = configurator.ConfigurationExample(enabledEncryption: true, enabledCompression: true);
            var salaryManager = new SalaryManager(dataSource);
            var salary = salaryManager.Load();
            Console.WriteLine($"Loaded salary data: {salary}");
        }

        private static void ConceptualExample()
        {
            Client client = new Client();

            var simple = new ConcreteComponent();
            Console.WriteLine("Client: I get a simple component:");
            client.ClientCode(simple);
            Console.WriteLine();

            // ...as well as decorated ones.
            //
            // Note how decorators can wrap not only simple components but the
            // other decorators as well.
            ConcreteDecoratorA decorator1 = new ConcreteDecoratorA(simple);
            ConcreteDecoratorB decorator2 = new ConcreteDecoratorB(decorator1);
            Console.WriteLine("Client: Now I've got a decorated component:");
            client.ClientCode(decorator2);
        }
    }
}
