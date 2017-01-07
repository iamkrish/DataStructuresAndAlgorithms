using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Pallindrome
    {
        public string ShortestPalindrome(string s)
        {

            if (s == null || s.Length < 2) return s;

            char[] a = s.ToCharArray();
            Array.Reverse(a);
            string rev = new string(a);
           
            string concat = s + "#"+ rev;
            int lps = LPS(concat);
            StringBuilder sb = new StringBuilder();
            int i = s.Length;
            int j = lps;
            return rev.Substring(0, s.Length - lps) + s;

        }

        int LPS(string s)
        {
            int len = 0;
            
            int[] lps = new int[s.Length];
            lps[0] = 0;
            int i = 1;
            while (i < s.Length)
            {
                if (s[i] == s[len])
                {
                    len++;
                    lps[i] = len;
                    i++;
                }
                else
                {
                    if (len == 0)
                    {
                        lps[i] = 0;
                        i++;
                    }
                    else
                    {
                        len = lps[len - 1];
                    }
                }
            }

            return lps[s.Length - 1];
        }

       
    }
}
