using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace DS.Tests.Stack
{
    public class StackWithMaxTests
    {
        [Test]
        public void Max_WhenCalled_Returns_Maximum_Value()
        {
            var stack = new MaxStack<int>();

            var list = new List<int> { 1, 8, 3, 9, 2, 20, 12, 10, 4, 50, -70, 100, 99, 0, 8, 45 };

            var max = list[0];

            for (var i = 0; i < list.Count; i++)
            {
                if (list[i] > max) max = list[i];

                stack.Push(list[i]);
                Assert.AreEqual(max, stack.Max());
            }

            for (var i = list.Count - 1; i >= 0; i--)
            {
                Assert.AreEqual(list.Max(), stack.Max());

                stack.Pop();
                list.RemoveAt(i);
            }
        }
    }
}