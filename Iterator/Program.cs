// Iterator Design Pattern
//
// Intent: Lets you traverse elements of a collection without exposing its
// underlying representation (list, stack, tree, etc.).

using System;
using CustomIEnumerable = Iterator.Conceptual.CustomIteratorUsingIEnumerable;

namespace Iterator.Conceptual
{
    class Program
    {
        static void Main(string[] args)
        {
            RealExampleCustom();
            ConceptualExample();
        }

        // Example Iterator pattern using IEnumerable
        private static void RealExampleCustom()
        {
            // Initialize the social network implementation.
            CustomIEnumerable.SocialNetwork facebook = new CustomIEnumerable.Facebook();

            // Create the application that will use this network.
            CustomIEnumerable.Application app = new CustomIEnumerable.Application(facebook);

            // Profile ID for the user whose friends and coworkers will receive messages.
            string profileId = "user123";

            // Send spam to friends.
            Console.WriteLine("Sending messages to friends:");
            app.SendSpamToFriends(profileId, "Hello, friend! Check out our new promotion.");

            // Send spam to coworkers.
            Console.WriteLine("\nSending messages to coworkers:");
            app.SendSpamToCoworkers(profileId, "Hello, coworker! Don't forget our meeting at 3 PM.");

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }

        // Example Iterator pattern using custom iterator
        private static void RealExampleIEnumerable()
        {
            Custom.Application app = new Custom.Application();
            app.Config();

            // Normally the profile would be retrieved from the social network.
            Custom.Profile profile = new Custom.Profile("profileId123", "user@example.com");
            app.SendSpamToFriends(profile);
            app.SendSpamToCoworkers(profile);

            Console.ReadKey();
        }
        private static void ConceptualExample()
        {
            // The client code may or may not know about the Concrete Iterator
            // or Collection classes, depending on the level of indirection you
            // want to keep in your program.
            var collection = new WordsCollection();
            collection.AddItem("First");
            collection.AddItem("Second");
            collection.AddItem("Third");

            Console.WriteLine("Straight traversal:");

            foreach (var element in collection)
            {
                Console.WriteLine(element);
            }

            Console.WriteLine("\nReverse traversal:");

            collection.ReverseDirection();

            foreach (var element in collection)
            {
                Console.WriteLine(element);
            }
        }
    }

}
