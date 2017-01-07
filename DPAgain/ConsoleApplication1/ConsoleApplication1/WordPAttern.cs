
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class WordPAttern
    {
        public bool WordPatternMatch(string pattern, string str)
        {
            if (str == null || pattern == null) return false;
            if (str.Length == 0 && pattern.Length == 0) return true;
            if (str.Length == 0 || pattern.Length == 0) return false;

            IDictionary<char, string> dic = new Dictionary<char, string>();
            HashSet<string> set = new HashSet<string>();
            return dfs(str, pattern, 0, 0, dic, set);
        }

        private bool dfs(string text, string pattern, int i, int j, IDictionary<char, string> dic, HashSet<string> set)
        {

            if (i == text.Length && j == pattern.Length)
            {
                return true;
            }

            if (i >= text.Length || j >= pattern.Length)
            {
                return false;
            }

            char c = pattern[j];

            for (int k = i + 1; k <= text.Length; k++)
            {

                string sub = text.Substring(j, k-j);
                if (!dic.ContainsKey(c) && !set.Contains(sub))
                {

                    dic.Add(c, sub);
                    set.Add(sub);

                    //string rest = text.Substring(j,k-j);
                    if (dfs(text, pattern, k, j + 1, dic, set))
                    {
                        return true;
                    }
                    dic.Remove(c);
                    set.Remove(sub);
                }
                else if (dic.ContainsKey(c) && string.Equals(dic[c], sub))
                {
                    //string rest = text.Substring(k);
                    if (dfs(text, pattern, k, j + 1, dic, set))
                    {
                        return true;
                    }

                }
            }

            return false;
        }
    }
}
