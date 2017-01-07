using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class StringArrayPermutation
    {
        public IList<string> GetStringPermutations(string[] inp)
        {
            IList<string> result = new List<string>();
            if (inp == null) return result;
            if(inp.Length==1)
            {
                result.Add(inp[0]);
                return result;
            }

            //int min_length=3;
            //char[] output = new char[min_length];
            //PermuteHelper(inp, 0, result, output);

            StringBuilder sb = new StringBuilder();
            PermuteHelper2(inp, 0, result, sb);
            return result;
        }

        private void PermuteHelper(string[] inp, int rec_index, IList<string> res, char[] output)
        {
            if(rec_index==output.Length)
            {
                res.Add(new string(output));
                return ;
            }

            string s = inp[rec_index];
            for(int i=0;i<s.Length;i++)
            {
                output[rec_index] = s[i];
                PermuteHelper(inp, rec_index + 1, res, output);
            }

        }

        private void PermuteHelper2(string[] inp, int rec_index, IList<string> res, StringBuilder sb)
        {
            if (rec_index == inp.Length)
            {
                res.Add(sb.ToString());
                return;
            }

            string s = inp[rec_index];
            for (int i = 0; i < s.Length; i++)
            {
                sb.Append(s[i]);
                PermuteHelper2(inp, rec_index + 1, res, sb);
                sb.Length--;
            }

        }


    }
}
