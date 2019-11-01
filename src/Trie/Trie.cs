using System;
using System.Collections.Generic;

namespace DS
{
    /*
        Implement an autocomplete system.That is, given a query string s and a set of all possible query strings, return all strings in the set that have s as a prefix.
        For example, given the query string de and the set of strings[dog, deer, deal], return [deer, deal].
        Hint: Try preprocessing the dictionary into a more efficient data structure to speed up queries.
    */

    public class Trie
    {
        public TrieNode Root = new TrieNode();

        public bool Search(string word)
        {
            var node = SearchWord(word);

            return node != null && node.IsTerminal;
        }

        private TrieNode SearchWord(string word)
        {
            var node = Root;
            foreach (var c in word)
            {
                if (!node.Children.TryGetValue(c, out var next))
                {
                    return null;
                }
                node = next;
            }

            return node;
        }

        public void AddWord(string word)
        {
            if (string.IsNullOrWhiteSpace(word)) throw new ArgumentException(nameof(word), "Word can not be empty or null");
            if (Search(word)) throw new InvalidOperationException($"Word '{word}' already exists in trie");

            var node = Root;
            var prefix = "";
            foreach (var c in word)
            {
                prefix += c;
                if (!node.Children.TryGetValue(c, out var next))
                {
                    next = new TrieNode(prefix);
                    node.Children.Add(c, next);
                }
                next.PrefixCount++;
                node = next;
            }
            node.IsTerminal = true;
        }

        public bool RemoveWord(string word)
        {
            if (string.IsNullOrEmpty(word)) return false;

            var lastNode = SearchWord(word);

            if (lastNode == null || !lastNode.IsTerminal) return false;

            var node = Root;
            foreach (var c in word)
            {
                if (node.Children[c].PrefixCount == 1)
                {
                    node.Children.Remove(c);
                    return true;
                }
                node = node.Children[c];
                node.PrefixCount--;
            }

            return false;
        }

        public IEnumerable<string> GetWordsForPrefix(string prefix)
        {
            var words = new List<string>();
            var node = Root;
            foreach (var c in prefix)
            {
                if (!node.Children.TryGetValue(c, out var next))
                {
                    return words; // no words found
                }
                node = next;
            }

            GetWords(node, words);

            return words;
        }

        private void GetWords(TrieNode node, List<string> words)
        {
            if (node.IsTerminal)
            {
                words.Add(node.Prefix);
            }

            foreach (var n in node.Children.Values)
            {
                GetWords(n, words);
            }
        }
    }
}