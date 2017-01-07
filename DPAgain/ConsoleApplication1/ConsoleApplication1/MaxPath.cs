using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class PointsInGrid
    {
        public int MinPathSum(int[,] grid)
        {
            return MinPathHelper(grid);

        }

        private int MinPathHelper(int[,] grid)
        {
            if (grid == null || grid.Length == 0) return 0;
            int m = grid.GetLength(0);
            int n = grid.GetLength(1);

            if (m == 1 && n == 1) return grid[0, 0];

            int[,] table = new int[m, n];

            table[0, 0] = grid[0, 0];

            for (int i = 1; i < m; i++)
            {
                table[i, 0] = table[i - 1, 0] + grid[i, 0];
            }

            for (int j = 1; j < n; j++)
            {
                table[0, j] = table[0, j - 1] + grid[0, j];
            }


            for (int i = 1; i < m; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    int min_val = Math.Min(table[i - 1, j], table[i, j - 1]);
                    //current_sum+=min_val;
                    table[i, j] = min_val + grid[i, j];
                }
            }

            return table[m - 1, n - 1];
        }
    }
}
