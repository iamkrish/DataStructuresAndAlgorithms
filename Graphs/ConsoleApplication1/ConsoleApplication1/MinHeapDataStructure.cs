using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeapDataStructure
{
    internal class MinHeapNode
    {
        public int Vertex { get; set; }
        public int Distance { get; set; }

        public MinHeapNode(int v, int d)
        {
            Vertex = v;
            Distance = d;
        }
    }

    internal class MinHeap
    {
        public int HeapSize { get; set; }
        public int Capacity { get; set; }

        public MinHeapNode[] HeapNodes { get; set; }

        public int[] VertexPositionInHeap { get; set; }

        public MinHeap(int V)
        {
            HeapNodes = new MinHeapNode[V];
            Capacity = V;
            HeapSize = V;
            VertexPositionInHeap = new int[V];
            for (int i = 0; i < V; i++)
            {
                HeapNodes[i] = new MinHeapNode(i, Int32.MaxValue);
                
                VertexPositionInHeap[i] = i;
            }

            //This would be trivial as all the nodes have same distance value
            Heapify(0);
        }

        internal void Heapify(int index)
        {
            int left = 2 * index + 1;
            int right = 2 * index + 2;

            int min_index = index;
            
            if(left<HeapSize && HeapNodes[left].Distance < HeapNodes[min_index].Distance)
            {
                min_index = left;
            }
            if(right< HeapSize && HeapNodes[right].Distance < HeapNodes[min_index].Distance)
            {
                min_index = right;
            }
            if(min_index !=index)
            {
                MinHeapNode smallestNode = HeapNodes[min_index];
                MinHeapNode currentNode = HeapNodes[index];

                //Read this as : Correct position for the node node.Vertex is the r.h.s value.

                //Swap positions
                VertexPositionInHeap[smallestNode.Vertex] = index;
                VertexPositionInHeap[currentNode.Vertex] = min_index;

                //Swap nodes
                MinHeapNode temp = currentNode;
                HeapNodes[index] = HeapNodes[min_index];
                HeapNodes[min_index] = temp;

                // Fix everything below.
                Heapify(min_index);
            }
        }

        internal void DecreaseKey(int vertex, int updatedDistance)
        {
            //Find the position where the vertex can be found in HeapNodes[].
            // Note this position is not the vertex value;
            int vertex_position = VertexPositionInHeap[vertex];

            MinHeapNode node = HeapNodes[vertex_position];
            HeapNodes[vertex_position].Distance = updatedDistance;            
            
            //Fix everything above.
            while(vertex_position > 0 && HeapNodes[(vertex_position-1)/2].Distance > HeapNodes[vertex_position].Distance)
            {
                MinHeapNode parentNode = HeapNodes[(vertex_position - 1) / 2];
                MinHeapNode node1 = HeapNodes[vertex_position];
                //Swap positions of current node and parent node
                // int tempPosition = VertexPositionInHeap[node.Vertex];
                VertexPositionInHeap[node1.Vertex] = (vertex_position-1)/2;
                VertexPositionInHeap[parentNode.Vertex] = vertex_position;

                //Swap the actual nodes
                HeapNodes[(vertex_position - 1) / 2] = node1;
                HeapNodes[vertex_position] = parentNode;

                vertex_position = (vertex_position - 1) / 2;
            }
        }

        internal MinHeapNode ExtractMin()
        {
            if (IsHeapEmpty())
            {
                return null;
            }
            else
            {
                MinHeapNode first = HeapNodes[0];
                MinHeapNode last = HeapNodes[HeapSize - 1];

                VertexPositionInHeap[first.Vertex] = HeapSize-1;
                VertexPositionInHeap[last.Vertex] = 0;  // Move to top

                HeapNodes[0] = last;
                HeapNodes[HeapSize - 1] = first;
                HeapSize--;
                Heapify(0);
                return first;
            }           

        }

        internal bool IsHeapEmpty()
        {
            return HeapSize == 0;
        }

        internal bool IsinMinHeap(int vertex)
        {
            return VertexPositionInHeap[vertex] < HeapSize;
        }
    }
}
