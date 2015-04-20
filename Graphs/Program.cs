using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    class Program
    {


        public class Neighbor
        {

            //public int VertexNumber;
            //Neighbor next;
            public LinkedList<int> Neighbors;
        
        }
        public class Vertex
        {
            public String Name;
            public Neighbor AdjList;
        
        }

        Vertex[] AdjLists;
             
        
        public void PrintGraph(Vertex[] AdjLists)
        {

            for (int i = 0; i < AdjLists.Length; i++ )
            {
                Console.Write(AdjLists[i].Name + " : ");

                foreach (var value in AdjLists[i].AdjList.Neighbors)
                {
                    Console.Write(value + " ");
                }
                Console.WriteLine();
            }
        
        }

        public void DFS(int v, bool[] visited, Vertex[] AdjLists)
        {

            
            
            for (int i = 0; i < v; i++ )
                visited[i] = true;


            for (int i = 0; i < AdjLists.Length; i++)
            {
                Console.Write(AdjLists[i].Name + " : ");

                
                foreach (var value in AdjLists[i].AdjList.Neighbors)
                {

                    if (!visited[value])
                    {
                        Console.Write(value + " ");
                        DFS(value, visited, AdjLists);
                    }
                    
                }
                
               
                Console.WriteLine();
            }

            
        
        }

        static void Main(string[] args)
        {


            Neighbor NeighborofV0 = new Neighbor();
            NeighborofV0.Neighbors = new LinkedList<int>();

            NeighborofV0.Neighbors.AddLast(1);
            NeighborofV0.Neighbors.AddLast(3);

            Vertex v0 = new Vertex();
            v0.Name ="Anil";
            v0.AdjList = NeighborofV0;


            Neighbor NeighborofV1 = new Neighbor();
            NeighborofV1.Neighbors = new LinkedList<int>();
            NeighborofV1.Neighbors.AddFirst(0);
            NeighborofV1.Neighbors.AddLast(2);
            NeighborofV1.Neighbors.AddLast(4);

            Vertex v1 = new Vertex();
            v1.Name = "Sam";
            v1.AdjList = NeighborofV1;


            Neighbor NeighborofV2 = new Neighbor();
            NeighborofV2.Neighbors = new LinkedList<int>();
            NeighborofV2.Neighbors.AddFirst(1);
            
            Vertex v2 = new Vertex();
            v2.Name = "Sean";
            v2.AdjList = NeighborofV2;


            Neighbor NeighborofV3 = new Neighbor();
            NeighborofV3.Neighbors = new LinkedList<int>();
            NeighborofV3.Neighbors.AddFirst(0);

            Vertex v3 = new Vertex();
            v3.Name = "Ajay";
            v3.AdjList = NeighborofV3;


            Neighbor NeighborofV4 = new Neighbor();
            NeighborofV4.Neighbors = new LinkedList<int>();
            NeighborofV4.Neighbors.AddFirst(1);
            NeighborofV4.Neighbors.AddFirst(3);

            Vertex v4 = new Vertex();
            v4.Name = "Mira";
            v4.AdjList = NeighborofV4;

           
            Vertex[] AdjLists = {v0,v1,v2,v3,v4};


            Program p = new Program();
            p.PrintGraph(AdjLists);
            Console.ReadLine();

            int v = 4;
            bool[] visited = new bool[4];
            p.DFS(v, visited, AdjLists);


           
           
            
        }
    }
}
