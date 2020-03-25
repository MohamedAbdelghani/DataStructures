using System;
using System.Collections.Generic;
using System.Text;

namespace DS.Stack
{
    /// <summary>
    /// Defines a set of problems that can be solved using a stack
    /// </summary>
    public class StackApplications
    {
        /*
         Given a string of round, curly, and square open and closing brackets, return whether the brackets are balanced(well-formed).
         For example, given the string "([])", you should return true.
         Given the string "([)]" or "((()", you should return false.
        */

        // O(N) space & time
        public static bool IsBalancedBrackets(string token)
        {
            var map = new Dictionary<char, char>
            {
                { '{','}' },
                { '(' , ')'},
                { '[' ,']'}
            };

            var stack = new Stack<char>();
            foreach (var c in token)
            {
                if (stack.Count != 0 && (map.TryGetValue(stack.Peek(), out var v) && v == c))
                    stack.Pop();
                else
                    stack.Push(c);
            }

            return stack.Count == 0;
        }

        // Sort a stack using another stack such that the smallest items are on the top.
        // O(N^2) time and O(N) space.
        public static void SortStack(Stack<int> items)
        {
            var buffer = new Stack<int>();

            while (items.Count != 0)
            {
                var temp = items.Pop();

                while (buffer.Count != 0 && buffer.Peek() > temp)
                {
                    items.Push(buffer.Pop());
                }

                buffer.Push(temp);
            }

            while (buffer.Count != 0)
            {
                items.Push(buffer.Pop());
            }
        }
    }
}