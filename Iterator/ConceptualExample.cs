using System.Collections;
using System.Collections.Generic;

namespace Iterator.Conceptual
{
    // Concrete Iterators implement various traversal algorithms.
    class AlphabeticalOrderIterator : IEnumerator<string>
    {
        private readonly WordsCollection _collection;
        private int _position = -1;
        private readonly bool _reverse;

        public AlphabeticalOrderIterator(WordsCollection collection, bool reverse = false)
        {
            _collection = collection;
            _reverse = reverse;
            if (reverse)
            {
                _position = collection.Items.Count;
            }
        }

        public object Current => _collection.Items[_position];

        string IEnumerator<string>.Current => throw new System.NotImplementedException();

        public bool MoveNext()
        {
            int updatedPosition = _position + (_reverse ? -1 : 1);

            if (updatedPosition >= 0 && updatedPosition < _collection.Items.Count)
            {
                _position = updatedPosition;
                return true;
            }
            return false;
        }

        public void Reset()
        {
            _position = _reverse ? _collection.Items.Count - 1 : 0;
        }

        // Dispose method isn't used in this case, as there is no unmanaged resources.
        public void Dispose() { }
    }

    // Concrete Collections provide one or several methods for retrieving fresh iterator instances.
    class WordsCollection : IEnumerable
    {
        public List<string> Items { get; } = [];
        private bool _direction = false;

        public void ReverseDirection()
        {
            _direction = !_direction;
        }

        public void AddItem(string item)
        {
            Items.Add(item);
        }

        // Explicitly implement the non-generic GetEnumerator method.
        IEnumerator IEnumerable.GetEnumerator()
        {
            return new AlphabeticalOrderIterator(this, _direction); // No need to cast here
        }
    }

}
