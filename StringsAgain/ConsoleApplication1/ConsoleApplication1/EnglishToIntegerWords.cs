using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    
    public class EnglishToIntegerWords
    {

        string[] ones = new string[] { " ", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine" };

        string[] tens = new string[] {"Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Ninteen" };

        string[] lessThan100 = new string[] { " ", " ", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };

        string[] lessThanBillion = new string[] { "Hundred", "Thousand", "Million", "Billion" };

        public string NumberToWords(int num)
        {

            StringBuilder sb1 = new StringBuilder();
            StringBuilder sb2 = new StringBuilder();
            int x = num;
            int quoitent = 0;
            int rem =0;
            int i = 1;
            do
            {
                quoitent = x / 1000;                
                rem = x % 1000;

                Helper(rem, sb2);
                sb1.Insert(0, sb2.ToString());
                sb2.Clear();
                if (quoitent > 0)
                {
                    sb1.Insert(0, lessThanBillion[i]+" ");
                    i++;
                }
                x = quoitent;
            } while (x > 0);

            return sb1.ToString();
        }


        // HAndle all numbers less than 1000
        private void Helper(int n, StringBuilder sb)
        {
            if (n == 0) return;

            if (n >= 100)
            {
                int val = n / 100;
                sb.Append(ones[val]+" ");
                sb.Append(lessThanBillion[0] + " ");
                Helper(n % 100, sb);
            }

            else if (n >= 20 && n <=99)
            {
                int val = n / 10;
                sb.Append(lessThan100[val]+ " ");
                Helper(n % 10, sb);
            }

            else if (n >= 10 && n <= 19)
            {
                int val = n % 10;
                sb.Append(tens[val] +" ");

            }
            else
            {
                sb.Append(ones[n]+" ");
            }
        }
    }
}
