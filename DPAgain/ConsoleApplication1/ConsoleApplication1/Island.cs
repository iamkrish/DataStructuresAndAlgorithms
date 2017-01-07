using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{

    public class Island
    {
        public IList<int> NumIslands2(int m, int n, int[,] positions)
        {

            var res= Helper(positions, m, n);
            return res;
        }

        private IList<int> Helper(int[,] positions, int m, int n)
        {

            IList<int> res = new List<int>();

            //UnionFind uf = new UnionFind(m * n);

            int[,] area = new int[m, n];

            int[] parents = new int[m * n];
            for(int i =0;i<parents.Length;i++)
            {
                parents[i] = i;
            }

            int count = 0;

            for (int i = 0; i < positions.GetLength(0); i++)
            {
                int a = positions[i, 0];
                int b = positions[i, 1];


                area[a, b] = 1;
                count++;

                int node_index = n*a + b;
               // UnionFindNode ufn = uf.Nodes[a + b];

                IList<IList<int>> neighbors = GetNeighbors(area, a, b, m, n);
                for (int k = 0; k < neighbors.Count; k++)
                {
                    if (area[neighbors[k][0], neighbors[k][1]] == 1)
                    {
                        int index = neighbors[k][0]*n + neighbors[k][1];

                        int neigbor_parent_index = GetRoot(parents, index);

                        if(neigbor_parent_index!=node_index)
                        {
                            parents[neigbor_parent_index] = node_index;
                            count--;
                        }
                       
                    }

                }

                res.Add(count);
            }


            return res;

        }

        private IList<IList<int>> GetNeighbors(int[,] area, int r, int c, int m, int n)
        {
            IList<IList<int>> res = new List<IList<int>>();
            int[] row_Offset = new int[] { -1, 0, 0, 1 };
            int[] col_Offset = new int[] { 0, -1, 1, 0 };

            for (int i = 0; i < row_Offset.Length; i++)
            {
                if (r + row_Offset[i] >= m || r + row_Offset[i] < 0 || c + col_Offset[i] >= n || c + col_Offset[i] < 0)
                {
                    continue;
                }
                else
                {

                    res.Add(new List<int>() { r + row_Offset[i], c + col_Offset[i] });
                }

            }

            return res;
        }


        public int GetRoot(int[] parents, int i)
        {
            if(parents[i]!=i)
            {
                parents[i] = GetRoot(parents, parents[i]);
            }
            return parents[i];
        }
    }

    public class Islands2
    {
        public int NumIslands(char[,] grid)
        {
            int m = grid.GetLength(0);
            int n = grid.GetLength(1);
            return Helper(grid, m, n);
        }


        private int Helper(char[,] grid, int m, int n)
        {

            int[] parents = new int[m * n];
            for (int i = 0; i < parents.Length; i++)
            {
                parents[i] = i;
            }

            int count = 0;

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {

                    if (grid[i, j] == '0') continue;
                    int index = i * n + j;
                    count++;

                    IList<IList<int>> neighbors = GetNeighbors(grid, i, j, m, n);
                    for (int k = 0; k < neighbors.Count; k++)
                    {
                        if (grid[neighbors[k][0], neighbors[k][1]] == '0') continue;
                        int neighbor_index = neighbors[k][0] * n + neighbors[k][1];


                        int neigbor_parent_index = GetRoot(parents, neighbor_index);

                        if (neigbor_parent_index != index)
                        {
                            parents[neigbor_parent_index] = index;
                            count--;
                        }
                    }
                }
            }

            return count;

        }

        private IList<IList<int>> GetNeighbors(char[,] area, int r, int c, int m, int n)
        {
            IList<IList<int>> res = new List<IList<int>>();
            int[] row_Offset = new int[] { -1, 0};
            int[] col_Offset = new int[] { 0, -1};

            for (int i = 0; i < row_Offset.Length; i++)
            {
                if (r + row_Offset[i] >= m || r + row_Offset[i] < 0 || c + col_Offset[i] >= n || c + col_Offset[i] < 0)
                {
                    continue;
                }
                else
                {

                    res.Add(new List<int>() { r + row_Offset[i], c + col_Offset[i] });
                }

            }

            return res;
        }


        public int GetRoot(int[] parents, int i)
        {
            if (parents[i] != i)
            {
                parents[i] = GetRoot(parents, parents[i]);
            }
            return parents[i];
        }
    }
}
