using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class Anagrams
    {
        public IList<IList<string>> GroupStrings(string[] strings)
        {

            IList<IList<string>> res = new List<IList<string>>();

            if (strings == null || strings.Length == 0) return res;
            if (strings.Length == 1)
            {
                res.Add(new List<string>() { strings[0] });
                return res;
            }

            IDictionary<string, IList<string>> dic = new Dictionary<string, IList<string>>();


            foreach (string s in strings)
            {
                string prev = GetPreviousString(s);
                if (dic.ContainsKey(prev))
                {
                    dic[prev].Add(s);
                }

                string next = GetNextString(s);
                if (dic.ContainsKey(next))
                {
                    dic[next].Add(s);
                }

                if (!dic.ContainsKey(s))
                {
                    dic.Add(s, new List<string>() { s });
                }
            }

            foreach (string key in dic.Keys)
            {
                res.Add(dic[key]);
            }

            return res;

        }

        private string GetPreviousString(string s)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == 'a')
                {
                    sb.Append('z');
                }
                else
                {
                    sb.Append((char)(s[i] - 1));
                }
            }

            return sb.ToString();
        }

        private string GetNextString(string s)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == 'z')
                {
                    sb.Append('a');
                }
                else
                {
                    sb.Append((char)(s[i] + 1));
                }
            }

            return sb.ToString();
        }
    }
}
