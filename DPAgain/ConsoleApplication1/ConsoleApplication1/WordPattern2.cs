using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class WordPattern2
    {
        public bool PatternMatches(string text, string pattern)
        {
            if (text == null && pattern == null) return true;
            if (text == null || pattern == null) return false;

            IDictionary<char, string> map = new Dictionary<char, string>();
            HashSet<string> set = new HashSet<string>();
            return Helper(text,0, pattern,0,map,set);
        }

        private bool Helper(string text,int i, string pattern, int j, IDictionary<char,string> map, HashSet<string> set)
        {
            if(i==text.Length && j==pattern.Length)
            {
                return true;
            }
            if(i==text.Length || j==pattern.Length)
            {
                return false;
            }

            char c = pattern[j];
            if(map.ContainsKey(c))
            {
                string match = map[c];

                //Verify that string indeed starts with pattern at this index
                if(i+match.Length>text.Length)
                {
                    return false;
                }
                string verify = text.Substring(i, match.Length);
                if(!string.Equals(match,verify))
                {
                    return false;
                }

                //Try matching the rest( note that i moves forward by i+ match.Length)

                return Helper(text, i + match.Length, pattern, j + 1, map, set);

            }

            else
            {
                for(int k = i; k<text.Length;k++)
                {
                    string sub = text.Substring(i, (k-i+1));
                    
                    if(set.Contains(sub))
                    {
                        continue;
                    }

                    set.Add(sub);
                    map.Add(c, sub);

                    if (Helper(text, k+1, pattern, j + 1, map, set))
                    {
                        return true;
                    }

                    set.Remove(sub);
                    map.Remove(c);
                }

                return false;
            }
        }
    }
}
