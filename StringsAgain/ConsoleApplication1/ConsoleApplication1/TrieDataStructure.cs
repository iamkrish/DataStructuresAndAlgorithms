using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class TrieNode
    {
        public char Character { get; set; }

        public IDictionary<char, TrieNode> Children { get; set; }

        public bool LeafNode { get; set; }

        public TrieNode()
        {
            Children = new Dictionary<char, TrieNode>();
        }

        public TrieNode(char c) : this()
        {
            Character = c;
        }

        public void Insert(String word)
        {
            if (string.IsNullOrEmpty(word))
            {
                return;
            }

            char first = word[0];
            string subString = word.Substring(1);
            TrieNode child = null;
            Children.TryGetValue(first, out child);
            if (child == null)
            {
                child = new TrieNode(first);
                Children.Add(first, child);
            }

            if (word.Length > 1)
            {
                child.Insert(subString);
            }
            else
            {
                child.LeafNode = true;
                //stop recursion
            }
        }

        public void Insert2(string word)
        {
            if (word == null || word.Length == 0) return;

            if (!Children.ContainsKey(word[0]))
            {
                Children.Add(word[0], new TrieNode(word[0]));
            }
            if (word.Length > 1)
            {
                Children[word[0]].Insert2(word.Substring(1));
            }
            else
            {
                this.LeafNode = true;
            }
        }

        public bool Search2(string word)
        {
            if (word == null || word.Length == 0) return false;

            if (Children.ContainsKey(word[0]))
            {
                if (word.Length > 1)
                {
                    return Search2(word.Substring(1));
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }


        }

        public TrieNode Search3(string word)
        {
            if (word == null || word.Length == 0) return null;

            if (Children.ContainsKey(word[0]))
            {
                if (word.Length > 1)
                {
                    return Children[word[0]].Search3(word.Substring(1));
                }
                else
                {
                    return this.Children[word[0]];
                }
            }
            else
            {
                return null;
            }


        }

        public bool Search(String s)
        {
            if (string.IsNullOrEmpty(s)) return false;

            char first = s[0];
            // Search in the first level
            if (!Children.ContainsKey(first))
            {
                return false;
            }

            if (s.Length == 1)
            {
                return true;
            }

            string substring = s.Substring(1);
            return Children[first].Search(substring);
        }

        //not quite the output we expect
        public void PrintTrieContents()
        {
            if (this.Children.Count == 0)
            {
                // No children. nothing to print;
                return;
            }

            foreach (KeyValuePair<char, TrieNode> kvp in Children)
            {
                Console.Write(kvp.Key+ "  ");
                TrieNode child = kvp.Value;
                child.PrintTrieContents();
                Console.WriteLine();
            }
        }
    }

    public class Trie
    {
        private TrieNode _root;
        public TrieNode Root
        {
            get
            {
                return _root;
            }
        }

        public Trie()
        {
            _root = new TrieNode();
        }

        public void AddToTrie(string[] inputs)
        {
            foreach (var input in inputs)
            {
                _root.Insert(input);
            }
        }

        //public bool Search(string s)
        //{
        //    return _root.Search(s);
        //}

        public TrieNode Search(string s)
        {
            return _root.Search3(s);
        }
    }
}
