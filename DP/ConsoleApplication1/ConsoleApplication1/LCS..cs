using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class LCS
    {

        public int LCSRecursive(char[] a, char[] b, int len1, int len2)
        {
            if (len1 == a.Length || len2 == b.Length)
            {
                return 0;
            }
            else
            {
                if (a[len1] == b[len2])
                {
                    return 1 + LCSRecursive(a, b, len1 + 1, len2 + 1);
                }
                else
                {
                    int res1 = LCSRecursive(a, b, len1, len2 + 1);
                    int res2 = LCSRecursive(a, b, len1 + 1, len2);
                    return res1 >= res2 ? res1 : res2;
                }
            }
        }

        public int LCDDynamicPrograming(char[] a, char[] b)
        {
            if (a == null || b == null) return 0;
            if (a.Length == 0 || b.Length == 0) return 0;
            
            int[,] lcs = new int[a.Length+1, b.Length+1];

            
            // A[0][0...M] = 0
            // A[0...N][0] = 0
             
            for (int i = 1; i <= a.Length; i++)
            {
                for (int j = 1; j <= b.Length; j++)
                {
                    if (a[i-1] == b[j-1])
                    {
                        lcs[i,j] = 1 + lcs[i - 1, j - 1];
                        
                    }
                    else
                    {
                        //lcs[i, j] = Math.Max(lcs[i - 1, j], lcs[i, j - 1]);
                        if(lcs[i-1,j]>lcs[i,j-1])
                        {

                        }
                    }
                }
            }
            return lcs[a.Length, b.Length];

        }
    }
}
