using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrieDemo
{
    internal class Trie
    {
        private readonly TrieNode _root;   
        public Trie() {

            _root = new TrieNode();
        }

        public void Insert(string word)
        {
            var node = _root;

            foreach (var c in word)
            {
                if (!node.Children.ContainsKey(c))
                {
                    node.Children[c] = new TrieNode();
                }
                node = node.Children[c];
            }
            node.IsEndOfWord = true;
        }

        public bool Search(string word)
        {
            var node = _root;

            foreach (var c in word)
            {
                if (!node.Children.ContainsKey(c))
                {
                    return false;
                }
                node = node.Children[c];
            }
            return node.IsEndOfWord;
        }

        public bool StartsWith(string prefix)
        {
            var node = _root;

            foreach (var c in prefix)
            {
                if (!node.Children.ContainsKey(c))
                {
                    return false;
                }

                node = node.Children[c];
            }
            return true;
        }

        public List<string> SearchPrefix(string prefix)
        {
            var result = new List<string>();

            var node = _root;

            foreach (var c in prefix)
            {
                if (!node.Children.ContainsKey(c))
                {
                    return result;
                }

                node = node.Children[c];
            }

            DFS(node, prefix, result);

            return result;
        }

        private void DFS(TrieNode node, string currentWord, List<string> result)
        {
            if (node.IsEndOfWord)
            {
                result.Add(currentWord);
            }

            foreach (var (c, childNode) in node.Children)
            {
                DFS(childNode, currentWord + c, result);
            }
        }
    }
}
