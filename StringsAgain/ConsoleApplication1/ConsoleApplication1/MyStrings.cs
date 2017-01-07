using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class MyStrings
    {
        public string Reverse(string input)
        {
            if (string.IsNullOrEmpty(input)) return string.Empty;
            if (input.Length == 1)
            {
                if (input[0] != ' ') return input;
                return string.Empty;
            }
            return ReverseHelper(input);
        }

        private string ReverseHelper(string s)
        {
            char[] a = GetFilteredString(s).ToCharArray();
            Reverse(a, 0, a.Length - 1);
            int i = 0;
            int j = 0;

            while(i<a.Length)
            {
                j = i;
                while(i<a.Length && a[i]!=' ')
                {
                    i++;
                }

                if (i == a.Length)
                {
                    Reverse(a, j, i-1);
                    break;
                }

                Reverse(a, j, i - 1);
                i++;
            }

            return new string(a);
        }

        private string GetFilteredString(string input)
        {
            StringBuilder sb = new StringBuilder();

            // Trim spaces
            int i = 0;
            while(i<input.Length)
            {
                while(i<input.Length && input[i] ==' ')
                {
                    i++;
                }

                if (i == input.Length) break;

                if(sb.Length>0)
                {
                    sb.Append(' ');
                }

                //words                
                while(i< input.Length && input[i]!=' ')
                {
                    sb.Append(input[i]);
                    i++;
                }               
                
            }

            return sb.ToString();
        }

        private void Reverse(char[]  a, int start, int end)
        {
            char temp = ' ';
            while(start<end)
            {
                temp = a[start];
                a[start] = a[end];
                a[end] = temp;
                start++;
                end--;
            }
        }
    }
}
