using DS.Stack;
using NUnit.Framework;

namespace DS.Tests.Stack
{
    [TestFixture]
    public class StackTests
    {
        [Test]
        public void Stack_Push_Pop_Success_Cases()
        {
            var stack = new Stack<int>();

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
    }
}