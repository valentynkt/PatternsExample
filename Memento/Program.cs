// Memento Design Pattern
//
// Intent: Lets you save and restore the previous state of an object without
// revealing the details of its implementation.

using System;

namespace Memento.Conceptual
{
    class Program
    {
        static void Main(string[] args)
        {
            EditorExample();
            ConceptualExample();
        }

        private static void EditorExample()
        {
            Editor editor = new Editor();
            Command command = new Command(editor);

            // Simulate user actions
            editor.SetText("First version of text");
            command.MakeBackup(); // Saving the state before changes

            editor.SetText("Second version of text");

            // Undo the changes
            command.Undo(); // The text reverts back to "First version of text"
        }

        private static void ConceptualExample()
        {
            // The client code.
            Originator originator = new Originator("Super-duper-super-puper-super.");
            Caretaker caretaker = new Caretaker(originator);

            caretaker.Backup();
            originator.DoSomething();

            caretaker.Backup();
            originator.DoSomething();

            caretaker.Backup();
            originator.DoSomething();

            Console.WriteLine();
            caretaker.ShowHistory();

            Console.WriteLine("\nClient: Now, let's rollback!\n");
            caretaker.Undo();

            Console.WriteLine("\n\nClient: Once more!\n");
            caretaker.Undo();

            Console.WriteLine();
        }
    }
}
