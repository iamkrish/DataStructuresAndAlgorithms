using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class UnionFind
    {
        public UnionFindNode[] Nodes;

        public UnionFind(int size)
        {
            Nodes = new UnionFindNode[size];
            for(int i =0;i< size;i++)
            {
                Nodes[i] = new UnionFindNode(i);
            }
        }

        public int FindParent(int i)
        {
            if(Nodes[i].Parent!=i)
            {
                Nodes[i].Parent = FindParent(Nodes[i].Parent);
            }
            return Nodes[i].Parent;

        }

        public void UnionByRank(int i,int j)
        {
            int parent_i_index = FindParent(i);
            int parent_j_index = FindParent(j);

            UnionFindNode a = Nodes[parent_i_index];
            UnionFindNode b = Nodes[parent_j_index];

            if(a.Rank>b.Rank)
            {
                b.Parent = a.Parent;
            }
            else if(a.Parent<b.Parent)
            {
                a.Parent = b.Parent;
            }
            else
            {
                a.Rank++;
                b.Parent = a.Parent;
            }
        }

    }

    public class UnionFindNode
    {
        //public int Key;
        public int Parent;
        public int Rank;

        public UnionFindNode(int p)
        {
           // Key = k;
            Parent = p;
            Rank = 0;
        }
    }
}
