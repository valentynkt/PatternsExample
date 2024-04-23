// State Design Pattern
//
// Intent: Lets an object alter its behavior when its internal state changes. It
// appears as if the object changed its class.

using System;

namespace State.Conceptual
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
            var player = new AudioPlayer();

            Console.WriteLine("Testing the Audio Player with State Pattern");

            // Initially in ReadyState
            Console.WriteLine("\nInitial State: Ready");
            player.ClickPlay(); // Starts playback and transitions to PlayingState
            Console.WriteLine("Clicked Play: Should be playing now");

            // Now in PlayingState
            Console.WriteLine("\nState: Playing");
            player.ClickLock(); // Locks the player and transitions to LockedState
            Console.WriteLine("Clicked Lock: Should be locked now");

            // Now in LockedState
            Console.WriteLine("\nState: Locked");
            player.ClickPlay(); // No effect because the player is locked
            Console.WriteLine("Clicked Play: No effect, player is locked");

            player.ClickLock(); // Unlocks the player and returns to ReadyState
            Console.WriteLine("Clicked Lock Again: Should be unlocked and ready now");

            // Player back in ReadyState
            Console.WriteLine("\nState: Ready");
            player.ClickNext(); // Assumes going to the next track
            Console.WriteLine("Clicked Next: Should prepare the next track");

            Console.WriteLine("\nTesting complete.");
        }

        private static void ConceptualExample()
        {
            // The client code.
            var context = new Context(new ConcreteStateA());
            context.Request1();
            context.Request2();
        }
    }
}
