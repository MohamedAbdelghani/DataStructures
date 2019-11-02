using NUnit.Framework;
using System;

namespace DS.Tests
{
    [TestFixture]
    public class StackTests
    {
        [Test]
        public void Push_Pop_Success_Cases()
        {
            var stack = new DS.Stack<int>();

            Assert.AreEqual(0, stack.Count);

            var counter = 0;

            while (counter <= 50)
            {
                stack.Push(counter);

                Assert.AreEqual(counter, stack.Peek());
                Assert.AreEqual(counter + 1, stack.Count);

                counter++;
            }

            counter--;

            while (counter > 0)
            {
                Assert.AreEqual(counter, stack.Pop());
                Assert.AreEqual(counter - 1, stack.Peek());
                Assert.AreEqual(counter, stack.Count);

                counter--;
            }
        }

        [Test]
        public void Pop_ThrowsException_When_Stack_Is_Empty()
        {
            var stack = new Stack<int>();

            Assert.Throws<InvalidOperationException>(() => stack.Pop());
        }

        [Test]
        public void Peek_ThrowsException_When_Stack_Is_Empty()
        {
            var stack = new Stack<int>();

            Assert.Throws<InvalidOperationException>(() => stack.Peek());
        }
    }
}