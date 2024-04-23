// Singleton Design Pattern
//
// Intent: Lets you ensure that a class has only one instance, while providing a
// global access point to this instance.

using System;
using System.Threading;

namespace Singleton
{
    class Singleton
    {
        // Constructor is private to prevent instantiation from outside the class.
        private Singleton() { }

        private static Singleton _instance; // Holds the single instance.
        private static readonly object _lock = new object(); // Lock used for synchronization.

        // Accessor for the Singleton instance with double-check locking for enhanced thread safety.
        public static Singleton GetInstance(string value)
        {
            if (_instance == null) // First check for an existing instance without acquiring the lock.
            {
                lock (_lock) // Lock to ensure only one thread can enter.
                {
                    if (_instance == null) // Double check within the lock for safety.
                    {
                        _instance = new Singleton
                        {
                            Value = value // Initialize the instance with the provided value.
                        };
                    }
                }
            }
            return _instance; // Return the singleton instance.
        }

        // Example property to demonstrate that the Singleton instance can store and maintain state.
        public string Value { get; set; }
    }


    class Program
    {
        static void Main(string[] args)
        {
            // The client code.

            Console.WriteLine(
                "{0}\n{1}\n\n{2}\n",
                "If you see the same value, then singleton was reused (yay!)",
                "If you see different values, then 2 singletons were created (booo!!)",
                "RESULT:"
            );

            Thread process1 = new Thread(() =>
            {
                TestSingleton("FOO");
            });
            Thread process2 = new Thread(() =>
            {
                TestSingleton("BAR");
            });

            process1.Start();
            process2.Start();

            process1.Join();
            process2.Join();
        }

        public static void TestSingleton(string value)
        {
            Singleton singleton = Singleton.GetInstance(value);
            Console.WriteLine(singleton.Value);
        }
    }
}
