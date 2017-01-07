using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication7
{
    
    public class MultiplyStrings
    {
        public string Multiply(string num1, string num2)
        {
            ///string x = num1.Reverse()
            if (num1 == null || num2 == null) return string.Empty;
            if (num1.Length == 0 || num2.Length == 0) return string.Empty;

            int[] result = new int[num1.Length + num2.Length];



            for (int i = 0; i < num1.Length; i++)
            {
                for (int j = 0; j < num2.Length; j++)
                {
                    int a = num1[i] - '0';
                    int b = num2[j] - '0';

                    result[i + j] += a * b;

                }
            }

            StringBuilder sb = new StringBuilder();
            int r = 0, q = 0;
            for (int i = 0; i < result.Length; i++)
            {
                int sum = result[i];
                r = sum % 10;
                q = sum / 10;

                sb.Insert(0, r);

                if (i < result.Length - 1)
                {
                    result[i + 1] += q;
                }
            }


            while (sb.Length > 1 && sb[0] == '0')
            {
                sb.Remove(0, 1);
            }
            return sb.ToString();
        }
    }
}
