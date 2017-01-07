using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    public class AlienDictionary
    {
        public string AlienOrder(string[] words)
        {

            if (words == null || words.Length == 0) return string.Empty;

            IDictionary<char, HashSet<char>> dic = GetMappings(words);
            IList<char> keys = dic.Keys.ToList<char>();

            IDictionary<char, bool> visited = new Dictionary<char, bool>();
            foreach (char key in keys)
            {
                visited.Add(key, false);
            }

            Stack<char> stack = new Stack<char>();

            foreach (char k in keys)
            {
                if (!visited[k])
                {
                    DFS(k, dic, visited, stack);
                }

            }

            StringBuilder sb = new StringBuilder();

            while (stack.Count > 0)
            {
                sb.Append(stack.Pop());
            }

            return sb.ToString();
        }


        private void DFS(char c, IDictionary<char, HashSet<char>> dic, IDictionary<char, bool> visited, Stack<char> stack)
        {

            visited[c] = true;

            foreach (char n in dic[c])
            {
                if (!visited[n])
                {
                    DFS(n, dic, visited, stack);

                }
            }

            stack.Push(c);
        }

        private IDictionary<char, HashSet<char>> GetMappings(string[] words)
        {
            IDictionary<char, HashSet<char>> dictionary = new Dictionary<char, HashSet<char>>();

            for (int k = 0; k < words.Length; k++)
            {
                string word = words[k];

                for (int i = 0; i < word.Length; i++)
                {
                    char target = word[i];
                    if (!dictionary.ContainsKey(target))
                    {
                        dictionary.Add(target, new HashSet<char>());

                    }

                    for (int j = i + 1; j < word.Length; j++)
                    {
                        if (word[j] != target)
                        {
                            dictionary[target].Add(word[j]);
                        }
                    }
                }
            }
            return dictionary;
        }

    }

  }
