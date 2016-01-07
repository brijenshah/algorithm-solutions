using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solutions.Definition;

namespace Solutions.Trie
{
    // Implement a trie with insert, search, and startsWith methods
    [TestClass]
    public class PrefixTree
    {
        private TrieNode root;

        public PrefixTree()
        {
            root = new TrieNode();
        }

        // Inserts a word into the trie.
        public void Insert(string word)
        {
            var children = root.Children;

            for (int i = 0; i < word.Length; i++)
            {
                char c = word[i];
                TrieNode t;

                if (children.ContainsKey(c))
                {
                    t = children[c];
                }
                else
                {
                    t = new TrieNode(c);
                    children.Add(c, t);
                }

                children = t.Children;

                if (i == word.Length - 1)
                {
                    t.IsLeaf = true;
                }
            }

        }

        // Returns if the word is in the trie.
        public bool Search(string word)
        {
            TrieNode t = SearchNode(word);

            if (t != null && t.IsLeaf)
            {
                return true;
            }
            return false;
        }

        // Returns if there is any word in the trie
        // that starts with the given prefix.
        public bool StartsWith(string word)
        {

            if (SearchNode(word) != null)
            {
                return true;
            }
            return false;
        }

        private TrieNode SearchNode(string word)
        {
            var children = root.Children;
            TrieNode t = null;

            foreach (char c in word)
            {
                if (children.ContainsKey(c))
                {
                    t = children[c];
                    children = t.Children;
                }
                else
                {
                    return null;
                }
            }
            return t;
        }

        [TestMethod]
        [TestCategory("Trie")]
        public void Prefix_Tree()
        {
            // Your Trie object will be instantiated and called as such:
            PrefixTree trie = new PrefixTree();
            trie.Insert("fleet");
            trie.Insert("flight");

            Assert.IsTrue(trie.StartsWith("fl"));
        }
    }
}
