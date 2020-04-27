using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DS
{
    /// <summary>
    /// An async-compatible producer/consumer queue.
    /// </summary>
    public class AsyncQueue<T>
    {
        private readonly Queue<T> _queue = new Queue<T>();
        private readonly Queue<TaskCompletionSource<T>> _waitingQueue = new Queue<TaskCompletionSource<T>>();
        private readonly object _lock = new object();

        public int Count
        {
            get
            {
                lock (_lock)
                {
                    return _queue.Count;
                }
            }
        }

        public IEnumerable<T> DequeueAll()
        {
            while (_queue.Count > 0)
            {
                yield return _queue.Dequeue();
            }
        }

        public async Task<T> DequeueAsync(CancellationToken cancellationToken = default)
        {
            TaskCompletionSource<T> tcs;

            lock (_lock)
            {
                if (_queue.Count > 0) return _queue.Dequeue();

                tcs = new TaskCompletionSource<T>();
                _waitingQueue.Enqueue(tcs);
            }

            using (cancellationToken.Register(() => tcs.TrySetCanceled(), false))
            {
                return await tcs.Task;
            }
        }

        public void Enqueue(T item)
        {
            TaskCompletionSource<T> awaiter = null;

            lock (_lock)
            {
                if (_waitingQueue.Count > 0)
                {
                    awaiter = _waitingQueue.Dequeue();
                }
                else
                {
                    _queue.Enqueue(item);
                }
            }

            if (awaiter != null)
                awaiter.TrySetResult(item);
        }
    }
}