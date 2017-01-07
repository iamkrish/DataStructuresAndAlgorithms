using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    /// <summary>
    /// If we have a series of n union and find operations, the amortized complexity of
    /// each operation is O(aplha(n)) where alpha(n) is Ackermann function that grows very fast.
    /// So the amortized complexity is nearly constant.
    /// </summary>
    class UnionFind
    {
        class Subset
        {
            public int Rank { get; set; }
            public int Parent { get; set; }
        }

        private Subset[] subsets;
        public UnionFind(int V)
        {
            subsets = new Subset[V];
            for (int i = 0; i < V; i++)
            {
                subsets[i] = new Subset();
                subsets[i].Parent = i;
                subsets[i].Rank = 0;
            }
        }

        // Complexity O(log(V)
        public int FindWithPathCompression(int v)
        {
            return FindWithPathCompression(subsets, v);
        }

        //Complexity O(log(V))
        public void UnionByRank(int x, int y)
        {
            int x_parent = FindWithPathCompression(subsets, x);
            int y_parent = FindWithPathCompression(subsets, y);
            if (subsets[x_parent].Rank > subsets[y_parent].Rank)
            {
                subsets[y_parent].Parent = x_parent;
                //subsets[x_parent].Rank += 1; Should not increment rank 
            }
            else if (subsets[x_parent].Rank < subsets[y_parent].Rank)
            {
                subsets[x_parent].Parent = y_parent;
                //subsets[y_parent].Rank += 1;
            }
            else
            {
                subsets[x_parent].Parent = y_parent;
                subsets[y_parent].Rank += 1;
            }
        }

        /// <summary>
        /// Path by compression
        /// </summary>
        /// <param name="subsets"></param>
        /// <param name="v"></param>
        /// <returns></returns>
        private int FindWithPathCompression(Subset[] subsets, int v)
        {
            if (subsets[v].Parent != v)
            {
                subsets[v].Parent = FindWithPathCompression(subsets, subsets[v].Parent);
            }
            return subsets[v].Parent;
        }
    }
}
