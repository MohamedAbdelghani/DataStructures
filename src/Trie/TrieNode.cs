using System.Collections.Generic;

namespace DS
{
    public class TrieNode
    {
        public Dictionary<char, TrieNode> Children { get; } = new Dictionary<char, TrieNode>();

        public bool IsTerminal { get; set; }
        public string Prefix { get; set; }
        public int PrefixCount { get; set; }

        public TrieNode()
        {
        }

        public TrieNode(string prefix)
        {
            Prefix = prefix;
        }
    }
}