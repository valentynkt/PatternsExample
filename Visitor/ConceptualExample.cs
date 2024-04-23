using System;
using System.Collections.Generic;

namespace Visitor.Conceptual.ConceptualExample
{
    // The Component interface includes an `accept` method that takes a visitor as an argument.
    public interface IComponent
    {
        void Accept(IVisitor visitor);
    }

    // Concrete Component A implements the `Accept` method to trigger the visitor's corresponding method.
    public class ConcreteComponentA : IComponent
    {
        // Calls `VisitConcreteComponentA` to let the visitor know it's working with Component A.
        public void Accept(IVisitor visitor)
        {
            visitor.VisitConcreteComponentA(this);
        }

        // Specific method only available in this component.
        public string ExclusiveMethodOfConcreteComponentA()
        {
            return "A";
        }
    }

    // Concrete Component B works similarly to Component A.
    public class ConcreteComponentB : IComponent
    {
        // Calls `VisitConcreteComponentB` to let the visitor know it's working with Component B.
        public void Accept(IVisitor visitor)
        {
            visitor.VisitConcreteComponentB(this);
        }

        // Specific method only available in this component.
        public string SpecialMethodOfConcreteComponentB()
        {
            return "B";
        }
    }

    // The Visitor interface declares methods to handle visits to different component types.
    public interface IVisitor
    {
        void VisitConcreteComponentA(ConcreteComponentA element);
        void VisitConcreteComponentB(ConcreteComponentB element);
    }

    // Concrete Visitors define operations that can be performed on all component classes.
    // These operations can take advantage of component-specific methods.
    class ConcreteVisitor1 : IVisitor
    {
        public void VisitConcreteComponentA(ConcreteComponentA element)
        {
            Console.WriteLine(element.ExclusiveMethodOfConcreteComponentA() + " + ConcreteVisitor1");
        }

        public void VisitConcreteComponentB(ConcreteComponentB element)
        {
            Console.WriteLine(element.SpecialMethodOfConcreteComponentB() + " + ConcreteVisitor1");
        }
    }

    class ConcreteVisitor2 : IVisitor
    {
        public void VisitConcreteComponentA(ConcreteComponentA element)
        {
            Console.WriteLine(element.ExclusiveMethodOfConcreteComponentA() + " + ConcreteVisitor2");
        }

        public void VisitConcreteComponentB(ConcreteComponentB element)
        {
            Console.WriteLine(element.SpecialMethodOfConcreteComponentB() + " + ConcreteVisitor2");
        }
    }

    // Client code uses the visitor to operate on a collection of components without knowing their concrete classes.
    public class Client
    {
        public static void ClientCode(List<IComponent> components, IVisitor visitor)
        {
            foreach (var component in components)
            {
                component.Accept(visitor);
            }
        }
    }
}
