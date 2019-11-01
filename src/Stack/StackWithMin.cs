using System;

namespace DS.Stack
{
    /*
   👉 Implement a stack that has the following methods:
     ✔ Oush(val), which pushes an element onto the stack
     ✔ Pop(), which pops off and returns the topmost element of the stack. If there are no elements in the stack, then it should throw an error or return null.
     ✔ Min(), which returns the minimum value in the stack currently. If there are no elements in the stack, then it should throw an error or return null.
  */

    public class StackWithMin<T> : Stack<T> where T : IComparable<T>
    {
        private T[] _minItems = new T[0];
        private int _count;

        public StackWithMin()
        {
        }

        public StackWithMin(int capacity) : base(capacity)
        {
        }

        public override void Push(T value)
        {
            base.Push(value);

            if (_minItems.Length == _count) _minItems = IncreaseCapacity(_minItems, _count);

            if (_count > 0)
            {
                if (value.CompareTo(_minItems[_count - 1]) < 0) _minItems[_count++] = value;
            }
            else
            {
                _minItems[_count++] = value;
            }
        }

        public override T Pop()
        {
            var item = base.Pop();

            if (item.CompareTo(_minItems[_count - 1]) == 0)
            {
                _minItems[--_count] = default;
            }

            return item;
        }

        public T Min()
        {
            if (_count == 0) throw new InvalidOperationException("The stack is empty");
            return _minItems[_count - 1];
        }
    }
}