using System.Collections.Generic;

namespace Command.Conceptual
{
    public abstract class Command
    {
        protected Application app;
        protected Editor editor;
        protected string backup;

        public Command(Application app, Editor editor)
        {
            this.app = app;
            this.editor = editor;
        }

        protected void SaveBackup()
        {
            backup = editor.Text;
        }

        public void Undo()
        {
            editor.Text = backup;
        }

        public abstract bool Execute();
    }

    public class CopyCommand : Command
    {
        public CopyCommand(Application app, Editor editor) : base(app, editor) { }

        public override bool Execute()
        {
            app.Clipboard = editor.GetSelection();
            return false;
        }
    }

    public class CutCommand : Command
    {
        public CutCommand(Application app, Editor editor) : base(app, editor) { }

        public override bool Execute()
        {
            SaveBackup();
            app.Clipboard = editor.GetSelection();
            editor.DeleteSelection();
            return true;
        }
    }

    public class PasteCommand : Command
    {
        public PasteCommand(Application app, Editor editor) : base(app, editor) { }

        public override bool Execute()
        {
            SaveBackup();
            editor.ReplaceSelection(app.Clipboard);
            return true;
        }
    }

    public class UndoCommand : Command
    {
        public UndoCommand(Application app, Editor editor) : base(app, editor) { }

        public override bool Execute()
        {
            app.Undo();
            return false;
        }
    }

    public class CommandHistory
    {
        private readonly Stack<Command> history = new Stack<Command>();

        public void Push(Command command)
        {
            history.Push(command);
        }

        public Command Pop()
        {
            return history.Count > 0 ? history.Pop() : null;
        }
    }

    public class Editor
    {
        public string Text { get; set; }

        // For simplicity, this example assumes the entire text is always selected.
        // In a real application, you would need to manage the selection range.
        public string GetSelection()
        {
            return Text;
        }

        public void DeleteSelection()
        {
            Text = string.Empty; // Clears the text as if the entire text is selected.
        }

        public void ReplaceSelection(string text)
        {
            // This replaces the entire text, assuming the whole text is selected.
            Text = text;
        }
    }

    public class Application
    {
        public string Clipboard { get; set; }
        public Editor[] Editors { get; set; }
        public Editor ActiveEditor { get; set; }
        public CommandHistory History { get; set; }

        public Application()
        {
            History = new CommandHistory();
            // Initialization of editors and active editor is required.
        }

        public void ExecuteCommand(Command command)
        {
            if (command.Execute())
            {
                History.Push(command);
            }
        }

        public void Undo()
        {
            Command command = History.Pop();
            command?.Undo();
        }
    }

}
