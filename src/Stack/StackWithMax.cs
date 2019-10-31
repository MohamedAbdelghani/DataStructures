using System;

namespace DS.Stack
{
    /*
     👉 Implement a stack that has the following methods:
       ✔ push(val), which pushes an element onto the stack
       ✔ pop(), which pops off and returns the topmost element of the stack. If there are no elements in the stack, then it should throw an error or return null.
       ✔ max(), which returns the maximum value in the stack currently. If there are no elements in the stack, then it should throw an error or return null.
    */

    public class StackWithMax<T> where T : IComparable<T>
    {
        public int Count => _count;
        public int Capacity => _capacity;

        private T[] _stack = new T[0];
        private T[] _maxStack = new T[0];
        private int _count;
        private int _maxCount;
        private int _capacity;

        public StackWithMax()
        {
        }

        public StackWithMax(int capacity)
        {
            _capacity = capacity;
        }

        public void Push(T value)
        {
            if (_stack.Length == _count) _stack = IncreaseCapacity(_stack, _count);
            if (_maxStack.Length == _maxCount) _maxStack = IncreaseCapacity(_maxStack, _maxCount);

            _stack[_count++] = value;

            if (_maxCount > 0)
            {
                if (value.CompareTo(_maxStack[_maxCount - 1]) > 0) _maxStack[_maxCount++] = value;
            }
            else
            {
                _maxStack[_maxCount++] = value;
            }
        }

        public T Peek()
        {
            if (_count == 0) throw new InvalidOperationException("The stack is empty");

            return _stack[_count - 1];
        }

        public T Pop()
        {
            if (_count == 0) throw new InvalidOperationException("The stack is empty");

            var item = _stack[--_count];

            _stack[_count] = default;

            if (item.CompareTo(_maxStack[_maxCount - 1]) == 0)
            {
                _maxCount--;
                _maxStack[_maxCount] = default;
            }

            return item;
        }

        public T Max()
        {
            if (_maxCount == 0) throw new InvalidOperationException("The stack is empty");
            return _maxStack[_maxCount - 1];
        }

        private T[] IncreaseCapacity(T[] array, int currentCapacity)
        {
            _capacity = currentCapacity == 0 ? 4 : currentCapacity * 2;
            var arr = new T[_capacity];

            if (currentCapacity != 0)
            {
                System.Array.Copy(array, arr, array.Length);
            }

            return arr;
        }
    }
}