using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class WordPatternProblem
    {
        public bool WordPattern(string pattern, string str)
        {

            return Helper(pattern, str);
        }

        private bool Helper(string pattern, string s)
        {
            if (pattern == null && s == null) return true;
            if (pattern == null || s == null) return false;
            if (pattern.Length == 0 && s.Length == 0) return true;
            if (pattern.Length == 0 || s.Length == 0) return false;

            string[] tokens = s.Trim().Split(new char[] { ' ' });
            if (tokens.Length != pattern.Length) return false;
            IDictionary<char, string> lookup = new Dictionary<char, string>();

            for (int i = 0; i < pattern.Length; i++)
            {
                if (lookup.ContainsKey(pattern[i]))
                {
                    if (lookup[pattern[i]] != tokens[i])
                    {
                        return false;
                    }
                }
                else
                {
                    lookup.Add(pattern[i], tokens[i]);
                }
            }

            return true;
        }

    }
}
