using NUnit.Framework;
using System;

namespace DS.Tests
{
    public class QueueWith2StacksTests
    {
        [Test]
        public void Queue_Success_Cases()
        {
            var queue = new QueueWith2Stacks<int>();

            Assert.AreEqual(0, queue.Count);

            var list = new int[1000];
            var random = new Random();

            for (int i = 0; i < list.Length; i++)
            {
                list[i] = random.Next();
            }

            for (var i = 0; i < list.Length; i++)
            {
                queue.Enqueue(list[i]);

                Assert.AreEqual(i + 1, queue.Count);
            }

            var index = 0;

            while (index < list.Length)
            {
                Assert.AreEqual((list.Length - index), queue.Count);
                Assert.AreEqual(list[index], queue.Peek());
                Assert.AreEqual(list[index], queue.Dequeue());

                index++;
            }
        }
    }
}