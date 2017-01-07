using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public static class WordSearchHelper
    {
        public static  IList<IList<int>> GetValidNeighbors(char[,] matrix, int r, int c, int m, int n, bool[,] visited)
        {
            IList<IList<int>> neighbors = new List<IList<int>>();
            int[] rowOffset = new int[] { -1, 0, 0, 1 };
            int[] colOffset = new int[] { 0, -1, 1, 0 };


            for (int i = 0; i < rowOffset.Length; i++)
            {
                int x = r + rowOffset[i];
                int y = c + colOffset[i];
                if (x >= 0 && x < m && y >= 0 && y < n)
                {
                    if (!visited[x, y])
                    {
                        neighbors.Add(new List<int> { x, y });
                    }
                }
            }
            return neighbors;

        }
    }
}
