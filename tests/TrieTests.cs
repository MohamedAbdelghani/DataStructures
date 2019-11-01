using NUnit.Framework;

namespace DS.Tests
{
    public class TrieTests
    {
        [Test]
        public void Trie_Success_Cases()
        {
            var trie = new Trie();

            trie.AddWord("dog");
            trie.AddWord("deer");
            trie.AddWord("deal");

            var words = trie.GetWordsForPrefix("de");

            CollectionAssert.AreEquivalent(new[] { "deer", "deal" }, words);
        }
    }
}