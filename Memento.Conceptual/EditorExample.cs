namespace Memento.Conceptual
{
    // Originator class
    public class Editor
    {
        private string _text;
        private int _curX, _curY, _selectionWidth;

        public void SetText(string text)
        {
            _text = text;
        }

        public void SetCursor(int x, int y)
        {
            _curX = x;
            _curY = y;
        }

        public void SetSelectionWidth(int width)
        {
            _selectionWidth = width;
        }

        public Snapshot CreateSnapshot()
        {
            return new Snapshot(this, _text, _curX, _curY, _selectionWidth);
        }
    }

    // Memento class
    public class Snapshot
    {
        private readonly Editor _editor;
        private readonly string _text;
        private readonly int _curX, _curY, _selectionWidth;

        public Snapshot(Editor editor, string text, int curX, int curY, int selectionWidth)
        {
            _editor = editor;
            _text = text;
            _curX = curX;
            _curY = curY;
            _selectionWidth = selectionWidth;
        }

        public void Restore()
        {
            _editor.SetText(_text);
            _editor.SetCursor(_curX, _curY);
            _editor.SetSelectionWidth(_selectionWidth);
        }
    }

    // Command class that acts as Caretaker
    public class Command
    {
        private Snapshot _backup;
        private readonly Editor _editor;

        public Command(Editor editor)
        {
            _editor = editor;
        }

        public void MakeBackup()
        {
            _backup = _editor.CreateSnapshot();
        }

        public void Undo()
        {
            _backup?.Restore();
        }
    }
}
