using System;
using System.Collections.Generic;
using System.Linq;

namespace DS
{
    public class PriorityQueue<T>
    {
        private readonly List<QueueItem<T>> _list = new List<QueueItem<T>>();
        public readonly int _capacity;
        public int Count => _list.Count;

        public PriorityQueue(int capacity = int.MaxValue)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity), "Capacity should be >= 0.");
            }

            _capacity = capacity;
        }

        public PriorityQueue(IEnumerable<QueueItem<T>> collection, int capacity = int.MaxValue)
        {
            collection = collection ?? Enumerable.Empty<QueueItem<T>>();

            var items = collection.ToArray();

            if (items.Length > capacity)
            {
                throw new ArgumentOutOfRangeException(nameof(collection), "Collection length can't be greater than queue capacity");
            }

            _list.AddRange(items.OrderBy(x => x.Priority));
        }

        /// <summary>
        /// Adds value to the queue with the specified priority.
        /// Lower priority numbers correspond to higher priorities.
        /// Negative priorities are allowed and are not treated differently from other values.
        /// </summary>
        public void Enqueue(T value, int priority)
        {
            if (_list.Count >= _capacity)
            {
                throw new InvalidOperationException("Can't add items to full queue.");
            }

            var item = new QueueItem<T>(value, priority);

            var index = _list.FindIndex(x => x.Priority > priority);

            if (index != -1)
            {
                _list.Insert(index, item);
            }
            else
            {
                _list.Add(item);
            }
        }

        /// <summary>
        /// Removes and returns the highest priority value.
        /// </summary>
        /// <exception cref="System.InvalidOperationException">The <see cref="PriorityQueue{T}"/> is empty.</exception>
        public T Dequeue()
        {
            if (Count == 0)
                throw new InvalidOperationException("Queue empty.");

            var first = _list.First();
            _list.RemoveAt(0);

            return first.Value;
        }

        /// <summary>
        ///  Returns the value of highest priority in the queue, without removing it.
        /// </summary>
        /// <exception cref="System.InvalidOperationException">The <see cref="PriorityQueue{T}"/> is empty.</exception>
        public T Peek()
        {
            if (Count == 0)
                throw new InvalidOperationException("Queue empty.");

            return _list.First().Value;
        }

        /// <summary>
        ///  Returns the priority of the first element in the queue, without removing it.
        /// </summary>
        /// <exception cref="System.InvalidOperationException">The <see cref="PriorityQueue{T}"/> is empty.</exception>
        public int PeekPriority()
        {
            if (Count == 0)
                throw new InvalidOperationException("Queue empty.");

            return _list.First().Priority;
        }

        /// <summary>
        /// Adjusts an existing value in the queue to have a new specified priority,
        /// which must be at least as urgent as (≤) that value's previous priority in the queue.
        /// </summary>
        public void Prioritise(T value, int newPriority)
        {
            var item = _list.FirstOrDefault(x => x.Value.Equals(value));

            if (item == null)
                throw new ArgumentException("Specified value is not present in the queue.", nameof(value));
            if (item.Priority < newPriority)
                throw new ArgumentException("New priority must be at least as urgent as that value's previous priority in the queue", nameof(newPriority));

            _list.Remove(item);

            Enqueue(value, newPriority);
        }

        /// <summary>
        ///  Removes all elements from the <see cref="PriorityQueue{T}"/>
        /// </summary>
        public void Clear()
        {
            _list.Clear();
        }
    }

    public class QueueItem<T>
    {
        public QueueItem(T value, int priority)
        {
            Value = value;
            Priority = priority;
        }

        public T Value { get; set; }
        public int Priority { get; set; }
    }
}