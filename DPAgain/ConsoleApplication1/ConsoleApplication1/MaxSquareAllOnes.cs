using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class MaxSquareAllOnes
    {
        public int MaximalSquare(char[,] matrix)
        {
            if (matrix == null || matrix.Length == 0) return 0;

            int m = matrix.GetLength(0);
            int n = matrix.GetLength(1);

            int[,] table = new int[m + 1, n + 1];

            for (int i = 1; i <= m; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    if (matrix[i - 1, j - 1] == '1')
                    {

                        table[i, j] = 1 + Math.Min(table[i - 1, j], Math.Min(table[i, j - 1], table[i - 1, j - 1]));
                    }
                }
            }

            return table[m, n];
        }
    }
}
