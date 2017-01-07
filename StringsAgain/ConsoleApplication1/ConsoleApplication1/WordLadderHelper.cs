using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public static class WordLadderHelper
    {
        public static IDictionary<string, ISet<string>> GetWildCardPatterns(ISet<string> validWords)
        {
            IDictionary<string, ISet<string>> dic = new Dictionary<string, ISet<string>>();

            foreach (string validWord in validWords)
            {
                IList<string> patterns = CreateWildCardPattern(validWord);

                foreach (string pattern in patterns)
                {
                    if (!dic.ContainsKey(pattern))
                    {
                        HashSet<string> set = new HashSet<string>();
                        set.Add(validWord);
                        dic.Add(pattern, set);
                    }
                    else
                    {
                        dic[pattern].Add(validWord);
                    }
                }
            }
            return dic;
        }

        public static IList<string> GetValidLinkedWords(string word, ISet<string> validWords)
        {
            IList<string> result = new List<string>();

            IList<string> patterns = CreateWildCardPattern(word);
            IDictionary<string, ISet<string>> patternToValidWordsMapping = GetWildCardPatterns(validWords);

            foreach (string pattern in patterns)
            {
                if (patternToValidWordsMapping.ContainsKey(pattern))
                {
                    ISet<string> words = patternToValidWordsMapping[pattern];

                    foreach (string w in words)
                    {
                        result.Add(w);
                    }
                }
            }
            return result;
        }

        public static IList<string> CreateWildCardPattern(string word)
        {
            IList<string> list = new List<string>();

            for (int i = 0; i < word.Length; i++)
            {
                string pattern = word.Substring(0, i) + "_" + word.Substring(i + 1);
                list.Add(pattern);
            }
            return list;
        }
    }
}
