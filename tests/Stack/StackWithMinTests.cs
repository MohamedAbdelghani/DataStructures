using DS.Stack;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DS.Tests.Stack
{
    [TestFixture]
    public class StackWithMinTests
    {
        [Test]
        public void Min_WhenCalled_Returns_Minimum_Value()
        {
            var stack = new StackWithMin<int>();

            var list = new List<int> { 1, 8, 3, 9, 2, 20, 12, 10, 4, 50, -70, 100, 99, 0, 8, 45 };

            var min = list[0];

            for (var i = 0; i < list.Count; i++)
            {
                if (list[i] < min) min = list[i];

                stack.Push(list[i]);
                Assert.AreEqual(min, stack.Min());
            }

            for (var i = list.Count - 1; i >= 0; i--)
            {
                Assert.AreEqual(list.Min(), stack.Min());

                stack.Pop();
                list.RemoveAt(i);
            }
        }
    }
}