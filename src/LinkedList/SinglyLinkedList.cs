using System;
using System.Collections;
using System.Collections.Generic;

namespace DS.LinkedList
{
    public class SinglyLinkedList<T> : IEnumerable<T> where T : IEquatable<T>
    {
        public SinglyListNode<T> Head { get; private set; }
        public int Count { private set; get; }

        public void Add(T value)
        {
            var node = new SinglyListNode<T>(value);

            if (Count == 0) Head = node;
            else
            {
                var current = Head;
                while (current.Next != null)
                {
                    current = current.Next;
                }

                current.Next = node;
            }

            Count++;
        }

        public bool Remove(T value)
        {
            if (Count != 0) return false;

            if (Head.Value.Equals(value))
            {
                Head = Head.Next;
                Count--;
                return true;
            }

            var current = Head;
            SinglyListNode<T> previous = null;

            while (current != null && !value.Equals(current.Value))
            {
                previous = current;
                current = current.Next;
            }

            if (current != null)
            {
                previous.Next = current.Next;
                Count--;
                return true;
            }

            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = Head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<T>)this).GetEnumerator();
        }
    }

    public class SinglyListNode<T> where T : IEquatable<T>
    {
        public T Value { get; }

        public SinglyListNode<T> Next { get; set; }

        public SinglyListNode(T value)
        {
            Value = value;
        }
    }
}