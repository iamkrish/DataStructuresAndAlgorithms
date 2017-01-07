using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    public class GraphNode
    {
        public int Key { get; set; }
        public GraphNode Next { get; set; }
        public int EdgeWeight { get; set; }
        public GraphNode(int K, int edgeWeight = 1)
        {
            Key = K;
            EdgeWeight = edgeWeight;
        }
    }

    public class LinkedListofGraphNodes
    {
        public GraphNode Head { get; set; }

        public LinkedListofGraphNodes()
        {
            Head = null;
        }
        public void InsertAtHead(GraphNode k)
        {
            if (k == null) return;
            k.Next = Head;
            Head = k;
        }
    }
}
