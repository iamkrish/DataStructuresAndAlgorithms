using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class RegularExpressionMatching
    {
        public bool IsMatch(string s, string p)
        {
            if (s == null && p == null) return true;
            if (s == null || p == null) return false;
            if (s.Length == 0 && p.Length == 0) return true;
            if (s.Length == 0 || p.Length == 0) return false;

            return Helper(s, p);
        }

        private bool Helper(string s, string p)
        {
            int m = s.Length;
            int n = p.Length;

            bool[,] table = new bool[m + 1, n + 1];
            table[0, 0] = true;

            //Check the 1st row

            //Deals with patterns like a* or a*b* or a*b*c*

            for (int j = 1; j <= n; j++)
            {
                if (p[j - 1] == '*')
                {
                    table[0, j] = table[0, j - 2];
                }

            }

            for (int i = 1; i <= m; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    if (s[i - 1] == p[j - 1] || p[j - 1] == '.')
                    {
                        table[i, j] = table[i - 1, j - 1];
                    }

                    else if (p[j - 1] == '*')
                    {

                        //Exclude
                        table[i, j] = table[i, j - 2];

                        //Include
                        if (s[i - i] == p[j - 2] || p[j - 2] == '.')
                        {
                            table[i, j] = table[i, j] | table[i - 1, j];
                        }
                    }
                    else
                    {
                        table[i, j] = false;
                    }
                }
            }

            return table[m, n];
        }
    }
}
