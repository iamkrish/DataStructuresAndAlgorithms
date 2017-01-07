using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Graphs.UndirectedGraphs;
using Graphs.DirectedGraphs;

namespace Graphs
{
    class Program
    {
        static void Main(string[] args)
        {
            AlienDictionary ad = new AlienDictionary();
            string[] words = new string[]
            {"wrt","wrf","er","ett","rftt"};
            string order = ad.AlienOrder(words);



            bool TESTING_UDIRECTED_GRAPH = true;

            if (TESTING_UDIRECTED_GRAPH)
            {

                UndirectedGraph g = new UndirectedGraph();
                //string path = @"C:\Code\Graphs\ConsoleApplication1\ConsoleApplication1\Inputs\UndirectedGraphWithCycle.txt";
                string path = @"C:\Code\Graphs\ConsoleApplication1\ConsoleApplication1\DjikstrasUndirectedInput.txt";



                g.ConstructGraph(path);

                //Traversals:
                // g.BreadthFirstTraversal();

               // g.DepthFirstTraversal();

                // Cycle Detection


                //g.PrintGraph();
                //g.ConstructGraph(@"C:\Code\Graphs\ConsoleApplication1\ConsoleApplication1\DjikstrasUndirectedInput.txt");

                //bool hasCycle = g.HasCycle();
                //Console.WriteLine(hasCycle);
                //g.PrintGraph();
               // g.DijkstraAlgorithm(0);

                int[,] array = new int[,] 
                                 {{1, 1, 1, 1, 1},
                                 {1, 1, 1, 1, 1},
                                 {1, 1, 1, 1, 1},
                                 {1, 1, 1, 0, 0 },
                                 {1, 1, 1, 0, 1}};

                int numberOfIslands = g.NumberOfIslands(array);
                Console.WriteLine(numberOfIslands);

            }

            else
            {
                DirectedGraph directedgraph = new DirectedGraph();
                string path1 = @"C:\Code\Graphs\ConsoleApplication1\ConsoleApplication1\Inputs\BellmanFord.txt";
                directedgraph.ConstructGraph(path1);
                // directedgraph.PrintGraph();

                //directedgraph.BreadthFirstTraversal();
                //directedgraph.DepthFirstTraversal();
                //bool hasCycle = directedgraph.DetectCycle();
                //Console.WriteLine(hasCycle);

                //Cycle Detection
                //int cycles = directedgraph.DetectCycles2();
                //Console.WriteLine("No of cycles :" + cycles);
                //int scc = directedgraph.KosarajuSCC();
                //Console.WriteLine("Number of connected components is " + scc);

                //directedgraph.GetArticulationPoints();

                //directedgraph.TarjanScc();

                directedgraph.BellmanFord();

            }


            Console.ReadLine();
        }
    }
}
