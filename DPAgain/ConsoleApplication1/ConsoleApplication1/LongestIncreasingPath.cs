using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    
    public class LongestIncreasingPathProblem
    {
        public int LongestIncreasingPath(int[,] matrix)
        {

            if (matrix == null || matrix.Length == 0) return 0;
            if (matrix.Length == 1) return 1;

            int m = matrix.GetLength(0);
            int n = matrix.GetLength(1);
            int max_len = 0;
            int[,] lookup = new int[m, n];

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    max_len = Math.Max(max_len, DfsHelper(matrix, lookup, i, j, m, n));
                }
            }

            return max_len;
        }

        private int DfsHelper(int[,] matrix, int[,] lookup, int i, int j, int m, int n)
        {

            if (lookup[i, j] != 0)
            {
                return lookup[i, j];
            }
            // Get Valid Neighbors



            //Get VAlid Neighbors
            var neighbors = GetNeighbors(matrix, i, j, m, n);
            foreach (var neighbor in neighbors)
            {
                // Try to include its neighbors if its valid to increase the value of the longest 
                lookup[i, j] = Math.Max(lookup[i, j], DfsHelper(matrix, lookup, neighbor[0], neighbor[1], m, n));
            }

            return ++lookup[i, j];

        }

        private IList<IList<int>> GetNeighbors(int[,] matrix, int i, int j, int m, int n)
        {
            IList<IList<int>> res = new List<IList<int>>();

            int[] x_offset = new int[] { 0, -1, 0, 1 };
            int[] y_offset = new int[] { -1, 0, 1, 0 };


            for (int l = 0; l < x_offset.Length; l++)
            {
                int a = i + x_offset[l];
                int b = j + y_offset[l];

                if (a >= 0 && a < m && b >= 0 && b < n && matrix[a, b] > matrix[i, j])
                {
                    res.Add(new List<int>() { a, b });
                }
            }

            return res;
        }
    }
}
