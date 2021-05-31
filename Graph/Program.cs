using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    class Program
    {
        static void Main(string[] args)
        {


            //GraphNode g = new GraphNode(7);
            //g.AddEdge(1, 2, 10);
            //g.AddEdge(1, 3, 30);
            //g.AddEdge(2, 3, 12);
            //g.AddEdge(2, 4, 13);
            //g.AddEdge(2, 5, 15);
            //g.AddEdge(3, 5, 16);
            //g.AddEdge(4, 6, 17);
            //g.AddEdge(4, 5, 18);
            //g.AddEdge(5, 2, 91);
            //g.AddEdge(5, 3, 18);
            //g.AddEdge(5, 4, 54);
            //g.AddEdge(5, 6, 78);
            //g.AddEdge(6, 4, 89);
            //g.AddEdge(6, 5, 45);

            //g.DFS(1);
            //Console.WriteLine("**************");
            //g.DFS();
            //////g.BFS(1);
            //Console.ReadLine();

            //int[,] matrix = { {1,0,1,0,1},
            //{1,1,0,0,0},
            //{0,1,0,1,1}};
            //g.NumberOfIslands(matrix);

            //GraphNode g = new GraphNode(4);
            //There is an un - connected node
            //g.AddEdge(1, 0,12);
            //g.AddEdge(2, 1,11);
            //g.AddEdge(3, 4,13);
            //g.AddEdge(4, 0,14);

            //All connected and with a cycel
            //g.AddEdge(0, 1,11);
            //g.AddEdge(0, 2, 11);
            //g.AddEdge(1, 2, 11);
            //g.AddEdge(2, 0, 11);
            //g.AddEdge(2, 3, 11);
            //g.AddEdge(3, 3, 11);



            //g.DFS(); //Recursive
            //Console.WriteLine("********");
            //g.DFS(2); //Non-Recursive
            //Console.ReadLine();


            //GraphNode g = new GraphNode(6);
            //g.AddEdge(5, 2, 15);
            //g.AddEdge(5, 0, 11);
            //g.AddEdge(4, 0, 12);
            //g.AddEdge(4, 1, 13);
            //g.AddEdge(2, 3, 15);
            //g.AddEdge(3, 1, 16);

            //g.TopologicalSort();
            //Console.ReadLine();

            //GraphNode g = new GraphNode(10);
            //g.AddEdge(1, 2,12);
            //g.AddEdge(1, 3,14);
            //g.AddEdge(3, 6,18);
            //g.AddEdge(2, 4,16);
            //g.AddEdge(2, 5,15);
            //g.AddEdge(5, 7,16);
            //g.AddEdge(5, 8,17);
            //g.AddEdge(5, 9,11);
            //bool[] visited = new bool[10];
            //g.CheckIFTwoNodesAreOnSamePath(visited, 1);
            //g.Print();
            //Console.ReadLine();

            //GraphNode g = new GraphNode(7);
            //g.AddEdge(0, 1);
            //g.AddEdge(0, 2);
            //g.AddEdge(1, 3);
            //g.AddEdge(4, 1);
            //g.AddEdge(6, 4);
            //g.AddEdge(5, 6);
            //g.AddEdge(5, 2);
            //g.AddEdge(6, 0);
            //g.FindMotherVertex();
            //Console.ReadLine();

            //GraphNode g = new GraphNode(4);
            //g.AddEdge(0, 1);
            //g.AddEdge(0, 2);
            //g.AddEdge(1, 2);
            //g.AddEdge(2, 0);
            //g.AddEdge(2, 3);
            //g.AddEdge(3, 3);
            //g.CycleInDirectedGraph();
            //Console.ReadLine();

            //GraphNode g = new GraphNode(5);
            //g.AddEdge(0, 1);
            //g.AddEdge(1, 0);

            //g.AddEdge(0, 2);
            //g.AddEdge(2, 0);

            //g.AddEdge(2, 3);
            //g.AddEdge(3, 2);

            //g.AddEdge(3, 4);
            //g.AddEdge(4, 3);

            //g.AddEdge(4, 2);
            //g.AddEdge(2, 4);

            //g.CycleInUnDirectedGraph();
            //Console.ReadLine();

            //GraphNode g = new GraphNode(4);
            //g.AddEdge(0, 2);
            //g.AddEdge(0, 3);
            //g.AddEdge(1, 3);
            //g.AddEdge(2, 3);

            //g.SumOfDependenciesInGrpah();
            //Console.ReadLine();

            //Kosaraju's Algorithm Strongly connected components
            //GraphNode g = new GraphNode(4);
            //g.AddEdge(0, 1, 1);
            //g.AddEdge(1, 2, 2);
            //g.AddEdge(2, 3, 2);
            //g.AddEdge(3, 0, 3);

            //g.StronglyConnectedComponents(g);


            GraphNode g = new GraphNode(10);
            g.AddEdge(1, 4, 1);
            g.AddEdge(4, 1, 2);
            g.AddEdge(1, 2, 2);
            g.AddEdge(2, 1, 3);
            g.AddEdge(2, 3, 1);
            g.AddEdge(3, 2, 2);
            g.AddEdge(3, 4, 2);
            g.AddEdge(4, 3, 3);
            g.AddEdge(4, 5, 1);
            g.AddEdge(5, 4, 2);
            g.AddEdge(3, 5, 2);
            g.AddEdge(5, 3, 3);
            g.DegreeOfVetrexesOfGraph();

        }
    }
}
