using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class WordSearch
    {
        public IList<string> FindWords(char[,] board, string[] words)
        {
            return FindDictionaryWords(board, words);
        }
        public IList<string> FindDictionaryWords(char[,] matrix, string[] words)
        {
            IList<string> results = new List<string>();

            if (words == null || words.Length == 0) return results;

            int m = matrix.GetLength(0);
            int n = matrix.GetLength(1);

            Trie t = new Trie();
            t.AddToTrie(words);

            TrieNode root = t.Root;
            root.PrintTrieContents();

            var startsWith = root.StartsWithIterative2("pe");
            startsWith = root.StartsWithIterative2("oate");
            bool search = root.SearchIterative("oath");
            search = root.SearchIterative("oa"); 

            bool[,] visited = new bool[m, n];

            
            for (int i = 0; i < m; i++)
            {

                for (int j = 0; j < n; j++)
                {
                    if(!visited[i,j])
                    {
                        DFSHelper(matrix, i, j, m, n, visited, root, "", results);
                    }
                    
                }
            }
            return results;

        }

        private void DFSHelper(char[,] matrix, int r, int c, int m, int n, bool[,] visited, TrieNode node, string prefix, IList<string> results)
        {
            if (r < 0 || r > m - 1 || c < 0 || c > n - 1) return;
            if (!visited[r, c])
            {
                

                string s = prefix + matrix[r, c];
                TrieNode x = node.StartsWithIterative2(s);
                if(x==null)
                {
                    return;
                }

                visited[r, c] = true;
                if(x.LeafNode)
                {
                    results.Add(s);
                }
                
                IList<IList<int>> neighbors = GetValidNeighbors(matrix, r, c, m, n, visited);
                foreach (var neighbor in neighbors)
                {                    
                    DFSHelper(matrix, neighbor[0], neighbor[1], m, n, visited, node, s, results);           

                }

                visited[r, c] = false;
            }
        }
        private IList<IList<int>> GetValidNeighbors(char[,] matrix, int r, int c, int m, int n, bool[,] visited)
        {
            IList<IList<int>> neighbors = new List<IList<int>>();
            int[] rowOffset = new int[] { -1, 0, 0, 1 };
            int[] colOffset = new int[] { 0, -1, 1, 0 };


            for (int i = 0; i < rowOffset.Length; i++)
            {
                int x = r + rowOffset[i];
                int y = c + colOffset[i];
                if (x >= 0 && x < m && y >= 0 && y < n)
                {
                    if (!visited[x, y])
                    {
                        neighbors.Add(new List<int> { x, y });
                    }
                }
            }
            return neighbors;

        }
    }

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

            TrieNode child = null;
            if (!Children.ContainsKey(first))
            {
                child = new TrieNode(first);
                Children.Add(first, child);
            }
            child = Children[first];
            if (word.Length > 1)
            {
                child.Insert(word.Substring(1));
            }
            else
            {
                child.LeafNode = true;

                //Update the dictionary
                Children[first] = child;
            }

        }


        public bool Search(string s, ref bool isLeaf)
        {
            if (string.IsNullOrEmpty(s)) return false;

            char first = s[0];
            // Search in the first level
            if (!Children.ContainsKey(first))
            {
                return false;
            }

            TrieNode n = this.Children[first];
            if (s.Length == 1)
            {
                if (n.LeafNode)
                {
                    isLeaf = true;
                }
                return true;
            }
            else
            {
                string substring = s.Substring(1);
                return n.Search(substring, ref isLeaf);
            }
        }

        public void InsertIterative(String word)
        {
            if (string.IsNullOrEmpty(word))
            {
                return;
            }

            
            TrieNode node = this;
            for(int i=0; i< word.Length;i++)
            {
                TrieNode child = null;
                char ch = word[i];
                if(!node.Children.ContainsKey(ch))
                {
                    child = new TrieNode(ch);
                    node.Children.Add(ch, child);
                }
                child = node.Children[ch];
                node = child;
            }
             node.LeafNode = true;
            
                       
        }

        public bool SearchIterative(string word)
        {
            if (word == null || word.Length == 0) return false;
            TrieNode node = this;
            for (int i = 0; i < word.Length; i++)
            {
                TrieNode child = null;
                char ch = word[i];
                if (!node.Children.ContainsKey(ch))
                {
                    return false;
                }
                child = node.Children[ch];
                node = child;
            }
            return node.LeafNode;

        }

        public bool StartsWithIterative(string word)
        {
            if (word == null || word.Length == 0) return false;
            TrieNode node = this;
            for (int i = 0; i < word.Length; i++)
            {
                TrieNode child = null;
                char ch = word[i];
                if (!node.Children.ContainsKey(ch))
                {
                    return false;
                }
                child = node.Children[ch];
                node = child;
            }
            return true;

        }

        public TrieNode StartsWithIterative2(string word)
        {
            if (word == null || word.Length == 0) return null;
            TrieNode node = this;
            for (int i = 0; i < word.Length; i++)
            {
                TrieNode child = null;
                char ch = word[i];
                if (!node.Children.ContainsKey(ch))
                {
                    return null;
                }
                child = node.Children[ch];
                node = child;
            }
            return node;

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
                Console.Write(kvp.Key + "  ");
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
                _root.InsertIterative(input);
            }
        }

        //public bool Search(string s)
        //{
        //    return _root.Search(s);
        //}

        //public TrieNode Search(string s)
        //{
        //    return _root.Search(s);
        //}
    }
}
