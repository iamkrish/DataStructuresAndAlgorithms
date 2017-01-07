using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Graphs;
namespace Graphs.DirectedGraphs
{

    public class DirectedGraph
    {
        public int Vertices { get; set; }

        public GraphEdge[] Edges { get; set; }

        public LinkedListofGraphNodes[] AdjacencyList { get; set; }

        private static int _edgeCount = 0;

        private static int time = 0;
        public DirectedGraph()
        {

        }
        public DirectedGraph(int V)
        {
            this.InitializeGraph(V);
        }

        public DirectedGraph(int V, int E)
        {
            this.InitializeGraph(V, E);
        }

        public DirectedGraph(DirectedGraph g)
        {
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

            //Arrays in .NET are objects on heap. So the reference is passed by value. So no need of ref.
            //Since we can have more than 1 connected components;
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


        // Using the node states
        public bool DetectCycles2()
        {
            bool[] visited = new bool[Vertices];
            int[] state = new int[Vertices];

            bool hasCycle = false;
            for (int i = 0; i < Vertices; i++)
            {
                if (!visited[i])
                {
                    hasCycle = DetectCycles2Helper(i, visited, state);
                }
            }
            return hasCycle;
        }


        #region Strongly Connected Components

        #region Kosaraju

        /*
        Intuition: The number of Strongly conencted components can be obtained by using DFS traversal.
        If we choose the the right vertex to start the traversal, it would return a forest of trees( each tree corresponding to 1 scc)
        If not, it might end up retturning only 1 tree.
        
        Condition:
        So the logic is the end time of a border node that belongs to an SCC will always be after the end time of a node
        that belongs to another SCC to which the first node has an outwards link

        So in Step1, we do a DFS and store all the neigbors of a node recursively before we store the starting node
        Now if we transpose, the Adjacency list, the above condition should still hold true.
        Visiting the transposed adjacency list according to the order of popped nodes in stack will give us the correct number of SCC.
         */
        public int KosarajuSCC()
        {
            bool[] visited = new bool[Vertices];
            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < Vertices; i++)
            {
                if (!visited[i])
                {
                    GetTraversalOrder(i, visited, stack);
                }
            }

            DirectedGraph transpose = GetTransposeGraph();

            //Clear all visited nodes
            for (int i = 0; i < Vertices; i++)
            {
                visited[i] = false;
            }

            int scc = 0;
            while (stack.Count > 0)
            {
                int value = stack.Pop();
                if (!visited[value])
                {
                    Console.WriteLine("Scc component is :");
                    DFSTraversalHelper(transpose, value, visited);
                    scc++;
                }
                Console.WriteLine();
            }
            return scc;
        }

        private void GetTraversalOrder(int i, bool[] visited, Stack<int> stack)
        {
            visited[i] = true;
            GraphNode neigbor = AdjacencyList[i].Head;

            while (neigbor != null)
            {
                if (!visited[neigbor.Key])
                {
                    GetTraversalOrder(neigbor.Key, visited, stack);
                }
                neigbor = neigbor.Next;
            }
            stack.Push(i);
        }

        private DirectedGraph GetTransposeGraph()
        {
            DirectedGraph transpose = new DirectedGraph();
            transpose.InitializeGraph(Vertices);

            for (int i = 0; i < Vertices; i++)
            {
                GraphNode neighbor = AdjacencyList[i].Head;
                while (neighbor != null)
                {
                    GraphNode node = new GraphNode(i);
                    transpose.AdjacencyList[neighbor.Key].InsertAtHead(node);
                    neighbor = neighbor.Next;
                }
            }
            return transpose;
        }

        private void DFSTraversalHelper(DirectedGraph g, int i, bool[] visited)
        {
            visited[i] = true;
            Console.Write(i + " ");
            GraphNode neighbor = g.AdjacencyList[i].Head;
            while (neighbor != null)
            {
                if (!visited[neighbor.Key])
                {
                    DFSTraversalHelper(g, neighbor.Key, visited);
                }
                neighbor = neighbor.Next;
            }
        }
        #endregion


        #region Tarjan
        public void TarjanScc()
        {
            time = 0;
            bool[] visited = new bool[Vertices];
            Stack<int> stack = new Stack<int>();
            bool[] presentInStack = new bool[Vertices];
            int[] discoveryTimes = new int[Vertices];
            for(int i =0; i<discoveryTimes.Length;i++)
            {
                discoveryTimes[i] = -1;
            }
            int[] lowValue = new int[Vertices];
            for(int i =0; i< Vertices;i++)
            {
                if(discoveryTimes[i]==-1)
                {
                    TarjanSccHelper(i, visited, presentInStack, stack, discoveryTimes, lowValue);
                    Console.WriteLine();
                }
            }
        }

        public void TarjanSccHelper(int u, bool[] visited, bool[] presentInStack, Stack<int> stack, int[] discoveryTimes, int[] lowValues)
        {
            
            visited[u] = true;
            stack.Push(u);
            presentInStack[u] = true;
            discoveryTimes[u] = lowValues[u] = ++time;
            GraphNode v = AdjacencyList[u].Head;
            while (v != null)
            {
                if (!visited[v.Key])
                {
                    TarjanSccHelper(v.Key, visited, presentInStack, stack, discoveryTimes, lowValues);
                    lowValues[u] = Math.Min(lowValues[u], lowValues[v.Key]);
                }

                // Back edge
                else if(presentInStack[v.Key])
                {
                    lowValues[u] = Math.Min(lowValues[u], discoveryTimes[v.Key]);
                }
                v = v.Next;
            }

            //If head node found
            if(discoveryTimes[u] == lowValues[u])
            {
                Console.WriteLine("Representative of this SCC : " + u + " ");
                while (stack.Peek() != u)
                {
                    int val = stack.Pop();
                    presentInStack[val] = false;
                    Console.Write("             " + val + "  ");
                }
                Console.WriteLine();
                if(stack.Peek() == u)
                {
                    stack.Pop();
                    presentInStack[u] = false;                    
                }
            }
        }
        #endregion



        public void GetArticulationPoints()
        {

            bool[] visited = new bool[Vertices];
            int[] parent = new int[Vertices];

            for (int i = 0; i < Vertices; i++)
            {
                parent[i] = -1;
            }

            int[] discoveryTime = new int[Vertices];
            int[] lowValue = new int[Vertices];
            bool[] ArticulationPoint = new bool[Vertices];

            for (int i = 0; i < Vertices; i++)
            {
                if (!visited[i])
                {
                    DetermineArticulationPoints(i, visited, parent, discoveryTime, lowValue, ArticulationPoint);
                }
            }

            for (int i = 0; i < ArticulationPoint.Length; i++)
            {
                if (ArticulationPoint[i])
                {
                    Console.WriteLine(i);
                }
            }

        }

        private void DetermineArticulationPoints(int u, bool[] visited, int[] parent, int[] discoveryTime, int[] lowValue, bool[] articulationPoint)
        {
            visited[u] = true;
            discoveryTime[u] = lowValue[u] = ++time;
            int children = 0;
            GraphNode v = AdjacencyList[u].Head;

            while (v != null)
            {
                if (!visited[v.Key])
                {
                    children++;
                    parent[v.Key] = u;
                    DetermineArticulationPoints(v.Key, visited, parent, discoveryTime, lowValue, articulationPoint);

                    if (parent[u] == -1 && children >= 2)
                    {
                        // u is root node for the graph
                        // It should be an articulation point
                        articulationPoint[u] = true;
                    }

                    else if (parent[u] != -1 && lowValue[v.Key] >= discoveryTime[u])
                    {
                        // u is an articulation point
                        articulationPoint[u] = true;
                    }

                    lowValue[u] = Math.Min(lowValue[u], lowValue[v.Key]);
                }

                else
                {
                    if (v.Key != parent[u])
                    {
                        //This is the case when the descendant node 'v' of u has a backedge
                        // to an ancestor of u. Lets call this ancestor as 't'. At this point, t='v'
                        // At this point we could update the lowValue[u] to be  Math.Min(lowValue[u], lowValue[v.Key]);
                        // But lowValue[v.Key] could have been updated by another subtree. So if we do the above, we would
                        // also end up updating the lowValue[u] of one subtree with another subtree. This is not what we want.
                        // We need to compare Math.Min(lowValue[u], discoveryTime[v.Key]) to get the correct value;

                        // Refer to C:\Code\Graphs\ConsoleApplication1\ConsoleApplication1\Images\Graph_Disc_Low.jpg
                        // In this image, consider when you first move from F->G->C backedge. This updates the lowValue[F] to 3
                        // Next if you move from F->H->I->J->F, then lowValue[J] could be 3 if we consider the first scenario.
                        // We want lowValue[J] to be 6 which is the discoveryTiime of F.

                        lowValue[u] = Math.Min(lowValue[u], discoveryTime[v.Key]);
                    }
                }

                v = v.Next;
            }
        }
        #endregion

        public void BellmanFord()
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
                    Console.Write("Vertex: " + i + "===> parent :" + parent[i]);
                    Console.WriteLine();
                }
            }
        }
       

        private void BreadthFirstTraversalHelper(int index, bool[] visited)
        {
            Queue<int> q = new Queue<int>();
            q.Enqueue(index);
            while (q.Count > 0)
            {
                int val = q.Dequeue();
                Console.WriteLine("Dequeued val is " + val);
                GraphNode start = AdjacencyList[val].Head;
                while (start != null)
                {
                    if (!visited[start.Key])
                    {
                        visited[start.Key] = true;
                        q.Enqueue(start.Key);
                    }
                    start = start.Next;
                }
            }
        }

        private void DepthFirstTraversalHelper(int i, bool[] visited)
        {
            if (visited[i]) return;

            visited[i] = true;
            Console.WriteLine(i);

            GraphNode start = AdjacencyList[i].Head;
            while (start != null)
            {
                DepthFirstTraversalHelper(start.Key, visited);
                start = start.Next;
            }
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

        private bool DetectCycles2Helper(int vertex, bool[] visited, int[] state)
        {
            visited[vertex] = true;
            state[vertex] = (int)Color.Grey;

            GraphNode neighbor = AdjacencyList[vertex].Head;

            while (neighbor != null)
            {
                if (!visited[neighbor.Key] && DetectCycles2Helper(neighbor.Key, visited, state))
                {
                    return true;
                }
                else if (state[neighbor.Key] == (int)Color.Grey)
                {
                    return true;
                }
                neighbor = neighbor.Next;
            }

            state[vertex] = (int)Color.Black;
            return false;
        }

        private bool DetectCyclesHelper(int vertex, bool[] visited, bool[] recursionStack)
        {
            visited[vertex] = true;
            recursionStack[vertex] = true;

            GraphNode neighbor = AdjacencyList[vertex].Head;

            while (neighbor != null)
            {
                if (!visited[neighbor.Key] && DetectCyclesHelper(neighbor.Key, visited, recursionStack))
                {
                    return true;
                }
                else if (recursionStack[neighbor.Key])
                {
                    return true;
                }
                neighbor = neighbor.Next;
            }
            recursionStack[vertex] = false;
            return false;
        }

        private enum Color
        {
            White = 0,
            Grey = 1,
            Black = 2
        };

    }
}
