// Command Design Pattern
//
// Intent: Turns a request into a stand-alone object that contains all
// information about the request. This transformation lets you parameterize
// methods with different requests, delay or queue a request's execution, and
// support undoable operations.

using System;

namespace Command.Conceptual
{
    class Program
    {
        static void Main(string[] args)
        {
            RealExample();
            //  ConceptualExample();
        }

        private static void RealExample()
        {
            // Setup application and editor

            var app = new Application();
            var editor = new Editor();
            app.ActiveEditor = editor;

            // Simulate user interaction
            // User types some text
            editor.Text = "Hello, World!";
            Console.WriteLine($"Editor text: {editor.Text}");

            // User selects "Hello, " and copies it
            editor.Text = "Hello, World!";
            app.ExecuteCommand(new CopyCommand(app, editor));
            Console.WriteLine($"Clipboard after copy: {app.Clipboard}");

            // User selects the entire text and cuts it
            app.ExecuteCommand(new CutCommand(app, editor));
            Console.WriteLine($"Editor text after cut: {editor.Text}");
            Console.WriteLine($"Clipboard after cut: {app.Clipboard}");

            // User pastes the clipboard content
            app.ExecuteCommand(new PasteCommand(app, editor));
            Console.WriteLine($"Editor text after paste: {editor.Text}");

            // User realizes a mistake and decides to undo the last action
            app.Undo();
            Console.WriteLine($"Editor text after undo: {editor.Text}");

            // Wait for user input to prevent the console from closing immediately
            Console.ReadLine();
        }

        private static void ConceptualExample()
        {
            Receiver receiver = new Receiver();
            Invoker invoker = new Invoker();
            invoker.SetOnStart(new SimpleCommand("Say Hi!"));
            invoker.SetOnFinish(new ComplexCommand(receiver, "Send email", "Save report"));

            invoker.DoSomethingImportant();
        }
    }
}
