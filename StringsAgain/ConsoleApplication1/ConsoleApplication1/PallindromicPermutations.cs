using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class PallindromicPermutations
    {
        public IList<string> GeneratePalindromes(string s)
        {

            IList<string> result = new List<string>();

            // Check if any permuation would result in palindrome
            if (s == null || s.Length == 0) return result;
            if (s.Length == 1)
            {
                result.Add(s);
                return result;
            }

            IDictionary<char, int> dic = new Dictionary<char, int>();
            if (!Helper(s, dic)) return result;

            String mid = "";

            IList<char> halfString = new List<char>();

            IDictionary<char, int> pallindromeDictionary = new Dictionary<char, int>();
            int count = 0;
            //TAke half the number of characters for each entry and record the optional mid(odd length)
            foreach (char key in dic.Keys)
            {
                int val = dic[key];

                if (val % 2 != 0)
                {
                    mid += key;
                }

                if (val / 2 > 0)
                {
                    pallindromeDictionary.Add(key, val / 2);
                    count += val / 2;
                }

            }

            StringBuilder sb = new StringBuilder();


            GetPallindromePermutations(pallindromeDictionary, mid, sb, count,result);

            return result;



        }

        private void GetPallindromePermutations(IDictionary<char, int> dic, string mid, StringBuilder sb, int count, IList<string> result)
        {
            if (sb.Length == dic.Count)
            {
                string finalString = sb.ToString() + mid + GetReverse(sb.ToString());
                result.Add(finalString);
                return;
            }

            IList<char> keys = dic.Keys.ToList<char>();
            foreach (char key in keys)
            {
                if (dic[key] > 0)
                {
                    sb.Append(key);
                    dic[key]--;
                    GetPallindromePermutations(dic, mid, sb, count, result);
                    sb.Length--;
                    dic[key]++;
                }
            }
        }
        private string GetReverse(string s)
        {
            char[] a = s.ToCharArray();
            Array.Reverse(a);
            return new string(a);

        }

        private bool Helper(string s, IDictionary<char, int> dic)
        {
            foreach (char c in s)
            {
                if (c == ' ') continue;
                if (!dic.ContainsKey(c))
                {
                    dic.Add(c, 0);
                }
                dic[c]++;
            }

            int odd_pairs = 0;


            foreach (char c in dic.Keys)
            {
                if (dic[c] % 2 == 1)
                {
                    odd_pairs++;
                }

                if (odd_pairs > 1) return false;

            }
            return s.Length % 2 == 0 ? odd_pairs == 0 : odd_pairs == 1;


        }

    }
}
