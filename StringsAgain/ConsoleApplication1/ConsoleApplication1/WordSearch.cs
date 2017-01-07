using System.Collections.Generic;

namespace ConsoleApplication1
{
    class WordSearch
    {
        public bool WordExists(char[,] matrix, string word)
        {
            int m = matrix.GetLength(0);
            int n = matrix.GetLength(1);

            bool[,] visited = new bool[m, n];

            bool success = false;
            int index = 0;
            for(int i =0;i< m;i++)
            {
                for(int j =0; j<n; j++)
                {
                    success = WordExistsHelper(matrix, i, j, m, n, word, index, visited);
                    if(success)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool WordExistsHelper(char[,] matrix, int r, int c, int m, int n,string word, int index, bool[,] visited)
        {
            if(index == word.Length)
            {
                return true;
            }

            if(matrix[r,c] == word[index])
            {
                visited[r, c] = true;
                if (index == word.Length - 1) return true;
                IList<IList<int>> neighbors = WordSearchHelper.GetValidNeighbors(matrix, r, c, m, n, visited);
                foreach (var neighbor in neighbors)
                {
                    bool success = WordExistsHelper(matrix, neighbor[0], neighbor[1], m, n, word, index + 1, visited);
                    if (success)
                    {
                        return true;
                    }
                }
                visited[r, c] = false;
            }
            
            return false;

        }
    }

    class WordSearch2
    {
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

            bool[,] visited = new bool[m, n];

            //bool success = false;
            //int index = 0;
            for (int i = 0; i < m; i++)
            {
                
                for (int j = 0; j < n; j++)
                {
                    DFSHelper(matrix, i, j, m, n, visited, root, "", results);
                }
            }
            return results;

        }

        private void DFSHelper(char[,] matrix, int r, int c, int m, int n, bool[,] visited, TrieNode node,  string prefix, IList<string> results)
        {
            if(!visited[r,c])
            {
                visited[r, c] = true;
                
                string s = prefix+matrix[r,c];
                TrieNode match = node.Search3(s);
                if(match!=null)
                {
                    if (match.LeafNode)
                    {
                        results.Add(s);
                    }
                    //string before = s;

                    IList<IList<int>> neighbors = WordSearchHelper.GetValidNeighbors(matrix, r, c, m, n, visited);
                    foreach (var neighbor in neighbors)
                    {
                        DFSHelper(matrix, neighbor[0], neighbor[1], m, n, visited, node, s, results);
                        //sb = new StringBuilder(before);

                    }
                }
                
                
                visited[r, c] = false;
            }
        }

        private TrieNode GetDictionary(string[] words)
        {
            Trie trie = new Trie();

            trie.AddToTrie(words);
            return trie.Root;
        }
            
    }
}
