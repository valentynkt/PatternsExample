using System;

namespace Strategy.Conceptual.Calculator
{
    // The strategy interface declares operations common to all supported versions of some algorithm.
    public interface IStrategy
    {
        int Execute(int a, int b);
    }

    // Concrete strategies implement the algorithm while following the base strategy interface.
    public class ConcreteStrategyAdd : IStrategy
    {
        public object DoAlgorithm(object data)
        {
            throw new NotImplementedException();
        }

        public int Execute(int a, int b)
        {
            return a + b;
        }
    }

    public class ConcreteStrategySubtract : IStrategy
    {
        public object DoAlgorithm(object data)
        {
            throw new NotImplementedException();
        }

        public int Execute(int a, int b)
        {
            return a - b;
        }
    }

    public class ConcreteStrategyMultiply : IStrategy
    {
        public object DoAlgorithm(object data)
        {
            throw new NotImplementedException();
        }

        public int Execute(int a, int b)
        {
            return a * b;
        }
    }

    // The context defines the interface of interest to clients.
    public class Context
    {
        private IStrategy _strategy;

        // Usually, the context accepts a strategy through the constructor, 
        // and also provides a setter so that the strategy can be switched at runtime.
        public void SetStrategy(IStrategy strategy)
        {
            _strategy = strategy;
        }

        // The context delegates some work to the strategy object instead of implementing multiple versions of the algorithm on its own.
        public int ExecuteStrategy(int a, int b)
        {
            return _strategy.Execute(a, b);
        }
    }
}
