using System;

namespace DS
{
    /// <summary>
    /// Queue implementation with 2 stacks
    /// </summary>
    public class QueueWith2Stacks<T> where T : IComparable<T>
    {
        public int Count => _first.Count + _second.Count;

        private Stack<T> _first, _second;

        public QueueWith2Stacks()
        {
            _first = new Stack<T>();
            _second = new Stack<T>();
        }

        public void Enqueue(T item)
        {
            _first.Push(item);
        }

        public T Dequeue()
        {
            ShiftStacks();

            return _second.Pop();
        }

        public T Peek()
        {
            ShiftStacks();
            return _second.Peek();
        }

        private void ShiftStacks()
        {
            if (_second.Count == 0)
            {
                while (_first.Count != 0)
                {
                    _second.Push(_first.Pop());
                }
            }
        }
    }
}