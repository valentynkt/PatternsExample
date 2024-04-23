// Singleton Design Pattern
//
// Intent: Lets you ensure that a class has only one instance, while providing a
// global access point to this instance.

namespace Singleton.Conceptual
{
    using System;

    class Singleton
    {
        private static Singleton nonThreadSafeInstance;
        private static Singleton threadSafeInstance;
        private static readonly object lockObject = new object();

        // Private constructor to prevent external instantiation.
        private Singleton() { }

        // Non-thread-safe Singleton accessor
        public static Singleton GetNonThreadSafeInstance(string value)
        {
            if (nonThreadSafeInstance == null)
            {
                nonThreadSafeInstance = new Singleton { Value = value };
            }
            return nonThreadSafeInstance;
        }

        // Thread-safe Singleton accessor using double-check locking
        public static Singleton GetThreadSafeInstance(string value)
        {
            if (threadSafeInstance == null)
            {
                lock (lockObject)
                {
                    if (threadSafeInstance == null)
                    {
                        threadSafeInstance = new Singleton { Value = value };
                    }
                }
            }
            return threadSafeInstance;
        }

        // Property to store value
        public string Value { get; set; }
    }

    class Program
    {
        static void Main()
        {
            TestNonThreadSafeSingleton();
            TestThreadSafeSingleton();
        }

        static void TestNonThreadSafeSingleton()
        {
            // Demonstrate non-thread-safe Singleton
            var singletonA = Singleton.GetNonThreadSafeInstance("Initial Value");
            Console.WriteLine("Non-Thread-Safe Singleton Value: " + singletonA.Value);

            // Attempting to change the instance value
            var singletonB = Singleton.GetNonThreadSafeInstance("New Value");
            Console.WriteLine("Non-Thread-Safe Singleton Value: " + singletonB.Value);
        }

        static void TestThreadSafeSingleton()
        {
            // Demonstrate thread-safe Singleton
            var singletonC = Singleton.GetThreadSafeInstance("Initial Value");
            Console.WriteLine("Thread-Safe Singleton Value: " + singletonC.Value);

            // Attempting to change the instance value
            var singletonD = Singleton.GetThreadSafeInstance("New Value");
            Console.WriteLine("Thread-Safe Singleton Value: " + singletonD.Value);
        }
    }
}
