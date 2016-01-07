using System.Collections.Generic;

namespace Solutions.Definition
{
    public class TrieNode
    {
        public char Data;
        public Dictionary<char, TrieNode> Children = new Dictionary<char, TrieNode>();
        public bool IsLeaf;
        // Initialize your data structure here.
        public TrieNode()
        {
        }

        public TrieNode(char c)
        {
            Data = c;
        }
    }
}

