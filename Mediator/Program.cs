// Mediator Design Pattern
//
// Intent: Lets you reduce chaotic dependencies between objects. The pattern
// restricts direct communications between the objects and forces them to
// collaborate only via a mediator object.

using Mediator.Conceptual.AuthUIExample;
using System;

namespace Mediator.Conceptual
{
    class Program
    {
        static void Main(string[] args)
        {
            RealExample();
            //    ConceptualExample();
        }

        private static void RealExample()
        {
            AuthenticationDialog dialog = new AuthenticationDialog();

            // Simulate user interactions
            dialog.loginOrRegisterChkBx.Check(); // User checks the 'loginOrRegister' checkbox
            dialog.loginUsername.Text = "user";
            dialog.loginPassword.Text = "password";
            dialog.okBtn.Click(); // User clicks the 'OK' button
        }

        private static void ConceptualExample()
        {
            // The client code.
            Component1 component1 = new Component1();
            Component2 component2 = new Component2();
            new ConcreteMediator(component1, component2);

            Console.WriteLine("Client triggers operation A.");
            component1.DoA();

            Console.WriteLine();

            Console.WriteLine("Client triggers operation D.");
            component2.DoD();
        }
    }
}
