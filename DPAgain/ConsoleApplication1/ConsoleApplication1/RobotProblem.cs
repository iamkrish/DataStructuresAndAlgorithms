using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class RobotProblem
    {
        public IList<IList<GridPoint>> NumberOfUniquePaths(int[,] matrix)
        {
            IList<IList<GridPoint>> res = new List<IList<GridPoint>>();

            if (matrix == null || matrix.Length == 0) return res;


            IList<GridPoint> list = new List<GridPoint>();
            int m = matrix.GetLength(0);
            int n = matrix.GetLength(1);

            bool[,] visited = new bool[m, n];
            NumberOfUniquePathsHelper(matrix, 0, 0, m, n, visited, res, list);


            return res;
        }

        

        private void NumberOfUniquePathsHelper(int[,] matrix, int r, int c, int m, int n, bool[,] visited, IList<IList<GridPoint>> results, IList<GridPoint> list)
        {
            if (r >= m || c >= n)
            {
                return;
            }

            if (r == m - 1 && c == n - 1)
            {
                list.Add(new GridPoint(r, c));
                IList<GridPoint> res = new List<GridPoint>(list);
                results.Add(res);
                return;
            }

            IList<IList<int>> neighbors = GetValidNeighbors(matrix, r, c, m, n, visited);
            visited[r, c] = true;
            list.Add(new GridPoint(r, c));
            for (int i = 0; i < neighbors.Count; i++)
            {

                NumberOfUniquePathsHelper(matrix, neighbors[i][0], neighbors[i][1], m, n, visited, results, list);
            }
            visited[r, c] = false;
            list.Remove(list[list.Count - 1]);
        }

        private IList<IList<int>> GetValidNeighbors(int[,] matrix, int r, int c, int m, int n, bool[,] visited)
        {
            IList<IList<int>> neighbors = new List<IList<int>>();

            int[] rowOffSet = new int[] { 0, 1 };
            int[] colOffSet = new int[] { 1, 0 };

            for (int i = 0; i < rowOffSet.Length; i++)
            {
                int ro = r + rowOffSet[i];
                int co = c + colOffSet[i];
                if (ro < m && co < n && matrix[ro, co] != -1 && !visited[ro,co] )
                {
                    neighbors.Add(new List<int> { r + rowOffSet[i], c + colOffSet[i] });
                }
            }
            return neighbors;
        }

        public void PrintAllPaths(IList<IList<GridPoint>> results)
        {
            for (int i = 0; i < results.Count; i++)
            {
                IList<GridPoint> list = results[i];
                for (int j = 0; j < list.Count; j++)
                {
                    Console.Write(list[j].x + " " + list[j].y);
                    Console.Write(" => ");
                }
                Console.ReadLine();
            }
        }


        public int NumberOfUniquePathsDP(int[,] matrix)
        {
            if (matrix == null || matrix.Length == 0) return 0;
            int m = matrix.GetLength(0);
            int n = matrix.GetLength(1);
            return NumberOfUniquePathsDPHelper(matrix, m, n);
        }

        private int NumberOfUniquePathsDPHelper(int[,] matrix, int m, int n)
        {
            int[,] result = new int[m, n];

            // hink slightlly differentlt than coin change

            for (int i = 0; i < m; i++)
            {
                if (matrix[i, 0] != -1)
                {
                    result[i, 0] = 1;
                }
                else
                {
                    result[i, 0] = 0;
                }
            }

            for (int i = 0; i < n; i++)
            {
                if (matrix[0, i] != -1)
                {
                    result[0, i] = 1;
                }
                else
                {
                    result[0, i] = 0;
                }
            }

            for (int i = 1; i < m; i++)
            {
                for (int j = 1; j < n; j++)
                {

                    if (matrix[i, j] != -1)
                    {
                        result[i, j] = result[i, j - 1] + result[i - 1, j];
                    }
                    else
                    {
                        result[i, j] = 0;
                    }
                }
            }
            return result[m - 1, n - 1];
        }
    }



    public class GridPoint
    {
        public int x;
        public int y;
        public GridPoint(int i, int j)
        {
            x = i;
            y = j;
        }
    }
}
