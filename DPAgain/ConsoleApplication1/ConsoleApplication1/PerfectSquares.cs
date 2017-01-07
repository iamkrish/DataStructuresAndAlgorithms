using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class PerfectSquares
    {
        public int NumSquares(int n)
        {
            if (n <= 2) return n;

            int[] table = new int[n + 1];

            int max = (int)Math.Sqrt(n);

            for(int i=1;i<table.Length;i++)
            {
                table[i] = Int32.MaxValue;
            }
            table[0] = 1;

            for (int i = 1; i <= max; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    if (i * i == j)
                    {
                        table[j] = 1;
                    }
                    else if (j > i * i)
                    {
                        table[j] = Math.Min(table[j], 1 + table[j - i * i]);
                    }
                }
            }
            return table[n];
        }
    }
}
