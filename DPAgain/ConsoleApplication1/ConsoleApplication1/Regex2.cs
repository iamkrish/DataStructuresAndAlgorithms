using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class Regex2
    {
        public bool IsMatch(string s, string p)
        {


            int m = s.Length;
            int n = p.Length;

            bool[,] table = new bool[m + 1, n + 1];
            table[0, 0] = true;

            for (int i = 1; i <= n; i++)
            {
                if (p[i - 1] == '*')
                {
                    table[0, i] = table[0, i - 2];
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
                        //Ignoring the a* pattern
                        table[i, j] = table[i, j - 2];

                        //include
                        //eg: ab -> ab*
                        //eg: ab ->a.*
                        if ( (s[i - 1] == p[j - 2]) || (p[j - 2] == '.'))
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
