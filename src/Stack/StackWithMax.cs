using System;

namespace DS
{
    /*
     👉 Implement a stack that has the following methods:
       ✔ Push(val), which pushes an element onto the stack
       ✔ Pop(), which pops off and returns the topmost element of the stack. If there are no elements in the stack, then it should throw an error or return null.
       ✔ Max(), which returns the maximum value in the stack currently. If there are no elements in the stack, then it should throw an error or return null.
    */

    public class MaxStack<T> : Stack<T> where T : IComparable<T>
    {
        private T[] _maxItems = new T[0];
        private int _count;

        public MaxStack()
        {
        }

        public MaxStack(int capacity) : base(capacity)
        {
        }

        public override void Push(T value)
        {
            base.Push(value);

            if (_maxItems.Length == _count) _maxItems = IncreaseCapacity(_maxItems, _count);

            if (_count > 0 && value.CompareTo(_maxItems[_count - 1]) < 0)
            {
                _maxItems[_count] = _maxItems[_count - 1];
                _count++;
            }
            else
            {
                _maxItems[_count++] = value;
            }
        }

        public override T Pop()
        {
            var item = base.Pop();

            _maxItems[--_count] = default;

            return item;
        }

        public T Max()
        {
            if (_count == 0) throw new InvalidOperationException("The stack is empty");
            return _maxItems[_count - 1];
        }
    }
}