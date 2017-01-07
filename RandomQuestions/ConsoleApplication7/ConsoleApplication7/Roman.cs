using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication7
{
  
    public class Roman
    {
        public int RomanToInt(string s)
        {

            if (s == null || s.Length == 0) return 0;

            IDictionary<char, int> map = new Dictionary<char, int>();
            map.Add('I', 1);
            map.Add('V', 5);
            map.Add('X', 10);
            map.Add('L', 50);
            map.Add('C', 100);
            map.Add('D', 500);
            map.Add('M', 1000);

            int i = s.Length - 2;
            int j = s.Length - 1;
            int result = map[s[j]];

            while (i >= 0)
            {
                if (map[s[i]] >= map[s[j]])
                {
                    result += map[s[i]];
                }
                else
                {
                    result -= map[s[i]];
                }
                i--;
                j--;
            }

            return result;
        }
    }
}
