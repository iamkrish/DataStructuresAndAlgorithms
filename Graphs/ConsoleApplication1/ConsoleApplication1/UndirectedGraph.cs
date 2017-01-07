using Graphs;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeapDataStructure;

namespace Graphs.UndirectedGraphs
{
    public class UndirectedGraph
    {
        public int Vertices { get; set; }

        public LinkedListofGraphNodes[] AdjacencyList { get; set; }

        public GraphEdge[] Edges { get; set; }

        private static int _edgeCount = 0;

        public UndirectedGraph()
        {

        }
        public UndirectedGraph(int V)
        {
            this.InitializeGraph(V);
        }

        public UndirectedGraph(int V, int E)
        {
            this.InitializeGraph(V, E);
        }

        private void InitializeGraph(int V)
        {
            this.Vertices = V;
            AdjacencyList = new LinkedListofGraphNodes[Vertices];

            for (int i = 0; i < V; i++)
            {
                AdjacencyList[i] = new LinkedListofGraphNodes();
            }
        }

        private void InitializeGraph(int V, int E)
        {
            InitializeGraph(V);
            Edges = new GraphEdge[E];
            for (int i = 0; i < E; i++)
            {
                Edges[i] = new GraphEdge();
            }
        }

        public void ConstructGraph(string fileName)
        {
            try
            {
                var lines = File.ReadLines(fileName);
                string[] first = lines.First().Split(' ');

                int vertices = Int32.Parse(first[0]);
                int edges = Int32.Parse(first[1]);
                InitializeGraph(vertices, edges);

                foreach (var line in lines.Skip(1))
                {
                    string[] bits = line.Split(' ');
                    int src = Int32.Parse(bits[0]);
                    int dest = Int32.Parse(bits[1]);
                    int weight = 1;

                    if (bits.Length > 2)
                    {
                        weight = Int32.Parse(bits[2]);
                    }

                    AddEdge(src, dest, weight);
                }

            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
            }
        }

        public void AddEdge(int src, int dest, int weight = 1)
        {
            //For undirected graphs, it is symmetric so add it both ways
            GraphNode n1 = new GraphNode(dest, weight);
            AdjacencyList[src].InsertAtHead(n1);

            GraphNode n2 = new GraphNode(src, weight);
            AdjacencyList[dest].InsertAtHead(n2);

            GraphEdge edge = new GraphEdge(weight);
            edge.Source = src;
            edge.Destination = dest;
            Edges[_edgeCount] = edge;
            _edgeCount++;
        }

        public void PrintGraph()
        {
            // Print the adjacency list
            for (int i = 0; i < Vertices; i++)
            {
                GraphNode start = AdjacencyList[i].Head;
                PrintLevel(i, start);
            }

            //PrintEdges();
        }

        public void BreadthFirstTraversal()
        {
            bool[] visited = new bool[Vertices];
            for (int i = 0; i < Vertices; i++)
            {
                if (!visited[i])
                {
                    BreadthFirstTraversalHelper(i, visited);
                }
            }
        }

        public void DepthFirstTraversal()
        {
            bool[] visited = new bool[Vertices];
            for (int i = 0; i < Vertices; i++)
            {
                if (!visited[i])
                {
                    DepthFirstTraversalHelper(i, visited);
                }
            }
        }
        private void BreadthFirstTraversalHelper(int vertex, bool[] visited)
        {
            visited[vertex] = true;
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(vertex);

            while (queue.Count > 0)
            {
                int v = queue.Dequeue();

                GraphNode neighbor = AdjacencyList[v].Head;
                while (neighbor != null)
                {
                    if (!visited[neighbor.Key])
                    {
                        visited[neighbor.Key] = true;
                        queue.Enqueue(neighbor.Key);
                    }
                    neighbor = neighbor.Next;
                }

                Console.WriteLine(v);
            }

        }

        private void DepthFirstTraversalHelper(int vertex, bool[] visited)
        {
            if (visited[vertex])
            {
                return;
            }

            visited[vertex] = true;
            Console.WriteLine(vertex);

            GraphNode neighbor = AdjacencyList[vertex].Head;
            while (neighbor != null)
            {
                DepthFirstTraversalHelper(neighbor.Key, visited);
                neighbor = neighbor.Next;
            }
        }

        public bool HasCycle()
        {
            UnionFind uf = new UnionFind(Vertices);
            for (int i = 0; i < Edges.Length; i++)
            {
                //Process Edge
                int x = Edges[i].Source;
                int y = Edges[i].Destination;

                int x_parent = uf.FindWithPathCompression(x);
                int y_parent = uf.FindWithPathCompression(y);
                if (x_parent == y_parent)
                {
                    //Same parent.  cycle exists
                    return true;
                }
                else
                {
                    uf.UnionByRank(x, y);
                }
            }
            return false;
        }

        public void Bellmanford()
        {
            int[] distance = new int[Vertices];
            int[] parent = new int[Vertices];

            distance[0] = 0;
            for (int i = 1; i < distance.Length; i++)
            {
                distance[i] = Int32.MaxValue;
            }

            parent[0] = 0;
            for (int i = 1; i < parent.Length; i++)
            {
                parent[i] = -1;
            }

            //Relax all edges upto a maximum of V-1 times since any path could have atmost V-1 edges

            for (int i = 0; i < Vertices - 1; i++)
            {
                for (int j = 0; j < Edges.Length; j++)
                {
                    int sourceVertex = Edges[j].Source;
                    int destinationVertex = Edges[j].Destination;
                    int weight = Edges[j].Weight;

                    if (distance[destinationVertex] > distance[sourceVertex] + weight)
                    {
                        distance[destinationVertex] = distance[sourceVertex] + weight;
                        parent[destinationVertex] = sourceVertex;
                    }
                }
            }

            // DO one final pass to see if there is a negative-edge cycle
            bool hasNegativeCycle = false;
            for (int i = 0; i < Edges.Length; i++)
            {
                int sourceVertex = Edges[i].Source;
                int destinationVertex = Edges[i].Destination;
                int weight = Edges[i].Weight;

                if (distance[destinationVertex] > distance[sourceVertex] + weight)
                {
                    hasNegativeCycle = true;
                    break;
                }
            }

            if (!hasNegativeCycle)
            {
                for (int i = 0; i < Vertices; i++)
                {
                    PrintParentPath(parent, i);
                    Console.WriteLine();
                }
            }
        }

        private void PrintParentPath(int[] parent, int vertex)
        {
            if (parent[vertex] == vertex)
            {
                Console.Write("Parent => " + vertex + " : ");
                return;
            }
            PrintParentPath(parent, parent[vertex]);
            Console.Write(vertex + "  ");
        }

        // Greedy algorithm
        public void Kruskal_MST()
        {
            //Sort edges in the non-increasing order of weights
            Array.Sort(Edges);
            GraphEdge[] result = new GraphEdge[Edges.Length];
            int edge = 0;
            UnionFind uf1 = new UnionFind(Edges.Length);
            for (int i = 0; i < Edges.Length; i++)
            {
                int x = Edges[i].Source;
                int y = Edges[i].Destination;

                if (uf1.FindWithPathCompression(x) != uf1.FindWithPathCompression(y))
                {
                    result[edge++] = Edges[i];
                    uf1.UnionByRank(x, y);
                }
            }
            Console.WriteLine("Kruskal MST");
            for (int i = 0; i < edge; i++)
            {
                Console.WriteLine(result[i].Source + "-> " + result[i].Destination + "-> " + result[i].Weight);
            }
            // Process each edge and add it to the MST only if it does not form a cycle.
            //Save the MST in an array of GraphEdges and print the array

        }

        public void DijkstraAlgorithm(int sourceVertex)
        {
            MinHeap minHeap = new MinHeap(Vertices);
            int[] distanceTable = new int[Vertices];

            //Set all distances to max value initially
            for (int i = 0; i < distanceTable.Length; i++)
            {
                distanceTable[i] = Int32.MaxValue;
            }

            //Set source vertex's distance as 0;

            minHeap.DecreaseKey(sourceVertex, 0);
            distanceTable[sourceVertex] = 0;

            while (minHeap.HeapSize > 0)
            {
                //Extract min
                MinHeapNode minNode = minHeap.ExtractMin();
                Console.WriteLine("Min value extraxted: " + minNode.Vertex);

                //Look for the node's neighbors in adjacency list
                LinkedListofGraphNodes neighbors = AdjacencyList[minNode.Vertex];
                GraphNode p = neighbors.Head;
                while (p != null)
                {
                    if (minHeap.IsinMinHeap(p.Key) && minNode.Distance != Int32.MaxValue)
                    {
                        int new_distance = minNode.Distance + p.EdgeWeight;

                        if (distanceTable[p.Key] > new_distance)
                        {
                            minHeap.DecreaseKey(p.Key, new_distance);
                            distanceTable[p.Key] = new_distance;
                        }
                    }

                    p = p.Next;
                }
            }

            PrintDistanceTable(distanceTable);
        }

        private void PrintLevel(int vertex, GraphNode start)
        {
            Console.Write(vertex + ": ");
            GraphNode p = start;
            while (p != null)
            {
                Console.Write(p.Key + " ");
                p = p.Next;
            }
            Console.WriteLine();
        }

        public int NumberOfIslands(int[,] matrix)
        {
            int m = matrix.GetLength(0);
            int n = matrix.GetLength(1);
            bool[,] visited = new bool[m, n];
            int numberOfIslands = 0;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (matrix[i, j] != 0 && !visited[i, j])
                    {
                        numberOfIslands++;
                        IslandHelper(matrix, visited, i, j,m,n);
                    }
                }
            }
            return numberOfIslands;
        }

        private void IslandHelper(int[,] matrix, bool[,] visited, int row_index, int col_index,int M, int N)
        {
            visited[row_index, col_index] = true;
            //IList<Neighbor> neighbors = GetNeighbors(matrix, row_index, col_index);
            int[] rowShifts = { -1, -1, -1, 0, 0, 0, 1, 1, 1 };
            int[] colShifts = { -1, 0, 1, -1, 0, 1, -1, 0, 1 };

            for(int i =0; i< 8;i++)
            {
                if(CanVisitThisNeighbor(matrix,visited,row_index+rowShifts[i], col_index+colShifts[i],M,N))
                {
                    IslandHelper(matrix, visited, row_index + rowShifts[i], col_index + colShifts[i], M, N);
                }
            }
        }

        private List<Neighbor> GetNeighbors(int[,] matrix, int row_index, int col_index)
        {
            // get the 8 surrounding neighbors
            int m = matrix.GetLength(0);
            int n = matrix.GetLength(1);

            //int top_left;
            //int top_middle;
            //int top_right;
            //int middle_left;
            //int middle_right;
            //int bottom_left;
            //int bittom_middle;
            //int bottom_right;

            List<Neighbor> neigbors = new List<Neighbor>();
            if (col_index - 1 >= 0)
            {
                if (row_index - 1 >= 0 && matrix[row_index - 1, col_index - 1] == 1)
                {
                    Neighbor top_left = new Neighbor(row_index - 1, col_index - 1);
                    neigbors.Add(top_left);
                }

                if (row_index - 1 >= 0 && matrix[row_index - 1, col_index] == 1)
                {
                    Neighbor top_centre = new Neighbor(row_index - 1, col_index);
                    neigbors.Add(top_centre);
                }

                if (matrix[row_index, col_index - 1] == 1)
                {
                    Neighbor middle_left = new Neighbor(row_index, col_index - 1);
                    neigbors.Add(middle_left);
                }

                if (row_index + 1 < m && matrix[row_index + 1, col_index - 1] == 1)
                {
                    Neighbor bottom_left = new Neighbor(row_index + 1, col_index - 1);
                    neigbors.Add(bottom_left);
                }

                if (row_index + 1 < m && matrix[row_index + 1, col_index - 1] == 1)
                {
                    Neighbor bottom_centre = new Neighbor(row_index + 1, col_index);
                    neigbors.Add(bottom_centre);
                }
            }

            if (col_index + 1 < n)
            {
                if (row_index + 1 < m && matrix[row_index + 1, col_index + 1] == 1)
                {
                    Neighbor top_right = new Neighbor(row_index + 1, col_index + 1);
                    neigbors.Add(top_right);
                }

                if (matrix[row_index, col_index + 1] == 1)
                {
                    Neighbor middle_right = new Neighbor(row_index, col_index + 1);
                    neigbors.Add(middle_right);
                }

                if (row_index + 1 < m && matrix[row_index + 1, col_index + 1] == 1)
                {
                    Neighbor bottom_right = new Neighbor(row_index + 1, col_index + 1);
                    neigbors.Add(bottom_right);
                }
            }

            return neigbors;
        }

        private bool CanVisitThisNeighbor(int[,] array, bool[,] visited, int row, int col, int M, int N)
        {
            if ((row >= 0 && row < M) &&
                (col >= 0 && col < N) &&
                (array[row, col] == 1) &&
                (!visited[row, col]))
            {
                return true;
            }
            return false;
        }
        private void PrintEdges()
        {
            for (int i = 0; i < Edges.Length; i++)
            {
                Console.WriteLine("Edge Details : ===>  " + Edges[i].Source + " " + Edges[i].Destination + " " + Edges[i].Weight);
            }
        }







        private void PrintDistanceTable(int[] distances)
        {
            for (int i = 0; i < distances.Length; i++)
            {
                Console.WriteLine($"{i  }:{distances[i]}");
            }
        }
    }

    class Neighbor
    {
        public int Row { get; set; }
        public int Col { get; set; }
        public Neighbor(int r, int c)
        {
            Row = r;
            Col = c;
        }
    }
}
