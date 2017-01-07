using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class StringCompression
    {
        public string Compress(string s)
        {
            if (s == null || s.Length < 3) return s;

            StringBuilder sb = new StringBuilder();

            int len = s.Length;

            int i = 0;
            int balance = len;
            while(i<len)
            {
                char c = s[i];
                int count = 1;
                while(++i<len && s[i]==c)
                {
                    count++;
                    if (count > balance) return s;
                }
                i--;
                sb.Append(c);
                sb.Append(count);
                if (sb.Length >= len) return s;
                balance = len - sb.Length;                
                i++;
            }

            return sb.ToString();
        }
    }
}
