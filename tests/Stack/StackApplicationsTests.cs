using DS.Stack;
using NUnit.Framework;
using System;

namespace DS.Tests.Stack
{
    [TestFixture]
    public class StackApplicationsTests
    {
        [Test]
        public void IsBalancedBrackets_Checks_For_Brackets_Balancing()
        {
            Assert.IsTrue(StackApplications.IsBalancedBrackets("([])"));
            Assert.IsFalse(StackApplications.IsBalancedBrackets("((()"));
            Assert.IsFalse(StackApplications.IsBalancedBrackets("([)]"));
        }

        [Test]
        public void SortStack_Sorts_Given_Stack_In_Place()
        {
            // Arrange
            var items = new[] { 6, 2, 9, 78, 45, 0, -3, 200 };
            var stack = new Stack<int>();

            foreach (var item in items)
            {
                stack.Push(item);
            }
            Array.Sort(items);

            // Act
            StackApplications.SortStack(stack);

            // Assert
            CollectionAssert.AreEqual(items, stack);
        }
    }
}