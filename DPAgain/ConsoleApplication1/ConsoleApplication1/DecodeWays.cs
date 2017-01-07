using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
     public class DecodeWays
    {
        public int NumDecodings(string s)
        {
            if (s == null || s.Length == 0) return 0;

            if (s.Length == 1)
            {
                if (s[0] >= '1' && s[0] <= '9') return 1;
                return 0;
            }

            int[] table = new int[s.Length + 1];

            table[0] = 1;
            table[1] = (s[0] >= '0' && s[0] <= '9') ? 1 : 0;

            for (int i = 2; i <=s.Length; i++)
            {
                string first = s.Substring(i - 1, 1);
                int first_value = Convert.ToInt32(first);

                if (first_value >= 1 && first_value <= 9)
                {
                    table[i] += table[i - 1];
                }

                string second = s.Substring(i - 2, 2);
                int second_value = Convert.ToInt32(second);

                if (second_value >= 10 && second_value <= 26)
                {
                    table[i] += table[i - 2];
                }
            }

            return table[s.Length];
        }
    }
}
