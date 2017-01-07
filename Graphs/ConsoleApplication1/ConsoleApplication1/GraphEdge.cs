using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    public class GraphEdge: IComparable
    {
        public int Source { get; set; }
        public int Destination { get; set; }
        public int Weight { get; set; }

        public GraphEdge()
        {
            Weight = 1;
        }

        public GraphEdge(int w)
        {
            Weight = w;
        }
        public int CompareTo(object other)
        {
            if (other == null) return -1;
            GraphEdge p = other as GraphEdge;
            if (p == null) return -1;
            if (this.Weight < p.Weight) return -1;
            if (this.Weight > p.Weight) return 1;
            else return 0;
        }
    }
}
