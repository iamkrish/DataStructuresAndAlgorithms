using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class OneEditDistanceAway
    {
        public bool IsOneEditDistance(string s, string t)
        {

            if (s == null && t == null) return true;
            if (s == null || t == null) return false;

            int i = 0; int j = 0;
            int m = s.Length;
            int n = t.Length;

            if (Math.Abs(m - n) > 1) return false;
            int count = 0;

            while (i < m && j < n)
            {
                if (s[i] != t[j])
                {
                    if (count == 1) return false;

                    if (m > n) i++;
                    else if (m < n) j++;
                    else
                    {
                        i++;
                        j++;
                    }

                    count++;
                }
                else
                {
                    i++;
                    j++;
                }
            }

            if (i < m || j < n) count++;

            return count == 1;
        }
    }
}
