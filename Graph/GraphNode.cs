using System;
using System.Collections.Generic;
using Heaps;

namespace Graph
{
    class GraphNode
    {

        public class Edge
        {
            public int v { get; set; }
            public int w { get; set; }
            public Edge(int V, int W)
            {
                v = V;
                w = W;
            }
        }

        public int vertices;
        //private List<int>[] adj;
        private List<Edge>[] adj;

        public GraphNode(int v)
        {
            vertices = v;
            //adj = new List<int>[v];
            adj = new List<Edge>[v];
            for (int i = 0; i < v; i++)
            {
                //adj[i] = new List<int>();
                adj[i] = new List<Edge>();
            }
        }
        //public void AddEdge(int c, int v)
         public void AddEdge(int c, int v, int w)
        {
            //adj[c].Add(v);
            adj[c].Add(new Edge(v, w));
        }


        public void TopologicalSort()
        {
            Stack<int> stack = new Stack<int>();
            bool[] visited = new bool[vertices];
            for (int i = 0; i < vertices; i++)
            {

                foreach (Edge e in adj[i])
                {
                    if (visited[e.v] == false)
                    {
                        visited[e.v] = true;
                        stack.Push(e.v);
                    }
                }
                if (!visited[i])
                {
                    visited[i] = true;
                    stack.Push(i);
                }

            }
            while (stack.Count != 0)
            {
                Console.WriteLine(stack.Peek());
                stack.Pop();
            }

        }

        public void DFS()
        {
            bool[] visited = new bool[vertices];

            

            for (int vertex = 1; vertex < vertices; vertex++)
            {
                if (!visited[vertex])
                    DFSUtility(vertex, visited);
            }
        }

        public void DFSUtility(int vertex, bool[] visited)
        {
            visited[vertex] = true;
            Console.WriteLine($"visited {vertex}");

            foreach (Edge e in adj[vertex])
            {
                if (!visited[e.v])
                {
                    DFSUtility(e.v, visited);
                }
            }

        }
        //public void DFSUtility(int vertex, bool[] visited)
        //{
        //    visited[vertex] = true;
        //    Console.WriteLine($"visited {vertex}");

        //    for (int j = 0; j < adj[vertex].Count; j++)
        //    {
        //        if (!visited[adj[vertex][j].v])
        //        {
        //            DFSUtility(adj[vertex][j].v, visited);
        //        }
        //    }

        //}

        bool[] visited = new bool[5];
        public void DFS(int v)
        {
            bool[] visited = new bool[vertices];
            Stack<int> stack = new Stack<int>();
            visited[v] = true;
            stack.Push(v);

            while (stack.Count != 0)
            {
                v = stack.Pop();
                Console.WriteLine("Next ->" + v);
                foreach (Edge edge in adj[v])
                {
                    if (!visited[edge.v])
                    {
                        visited[edge.v] = true;
                        stack.Push(edge.v);
                    }
                }
            }
        
        }

        int[] inTime = new int[10];
        int[] outTime = new int[10];
        int inTimer = 0;
        public void CheckIFTwoNodesAreOnSamePath(bool[] visited, int vertex)
        {

            visited[vertex] = true;
            ++inTimer;
            inTime[vertex] = inTimer;
            for (int j = 0; j < adj[vertex].Count; j++)
            {
                if (!visited[adj[vertex][j].v])
                {
                    CheckIFTwoNodesAreOnSamePath(visited, adj[vertex][j].v);
                }
            }
            ++inTimer;
            outTime[vertex] = inTimer;

        }
        public void Print()
        {
            for (int i = 0; i < inTime.Length; i++)
            {
                Console.WriteLine("InTime : " + inTime[i] + " OutTime: " + outTime[i]);
            }
        }

        public void FindMotherVertex()
        {
            //bool[] visited = new bool[vertices];
            int v = 0;
            for (int i = 0; i < vertices; i++)
            {
                if (!visited[i])
                {
                    visited[i] = true;
                    foreach (Edge e in adj[i])
                    {
                        if (!visited[e.v])
                        {
                            visited[e.v] = true;
                        }
                    }
                    v = i;
                }
            }
            Console.WriteLine(v);

            for (int i = 0; i < vertices; i++)
            {
                visited[i] = false;
            }

            DFS(v);
            for (int i = 0; i < v; i++)
            {
                if (visited[i] == true)
                {
                    Console.WriteLine(v + " is the mother vertex");
                }
            }


        }

        public bool query(int u, int v)
        {
            return ((inTime[u] < inTime[v] && outTime[u] > outTime[v]) ||
                     (inTime[v] < inTime[u] && outTime[v] > outTime[u]));
        }

        public void CycleInDirectedGraph()
        {
            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < vertices; i++)
            {
                if (visited[i] == false)
                {
                    stack.Push(i);
                    visited[i] = true;
                }

                foreach (Edge e in adj[i])
                {

                    if (stack.Contains(e.v))
                    {
                        Console.WriteLine("There is a cycle @ : " + e.v);
                        return;
                    }
                    if (!visited[e.v])
                    {
                        visited[e.v] = true;
                        stack.Push(e.v);
                    }
                }
            }

        }

        public bool IsCyclicUtil(int vertex, bool[] visited, int parent)
        {
            visited[vertex] = true;

            foreach (Edge edge in adj[vertex])
            {
                if (!visited[edge.v])
                {
                    if (IsCyclicUtil(edge.v, visited, vertex))
                        return true;
                }
                else if (edge.v != parent)
                {
                    return true;
                }
            }
            return false;

        }

        public void SumOfDependenciesInGrpah()
        {
            int sum = 0;
            for (int i = 0; i < vertices; i++)
            {
                sum += adj[i].Count;
            }
            Console.WriteLine("Sum of Dependencies is : " + sum);
        }

        public bool CycleInUnDirectedGraph()
        {

            for (int i = 0; i < vertices; i++)
            {
                if (!visited[i])
                    if (IsCyclicUtil(i, visited, -1))
                        return true;
            }
            return false;


        }

        public void BFS(int v)
        {
            bool[] visited = new bool[vertices];
            Queue<int> q = new Queue<int>();
            visited[v] = true;
            q.Enqueue(v);

            while (q.Count !=0)
            {
                v = q.Dequeue();
                Console.WriteLine(v + "-> ");
               
                foreach (Edge e in adj[v])
                {
                 
                    if (!visited[e.v])
                    {
                        visited[e.v] = true;
                        q.Enqueue(e.v);
                    }
                }
             
            }
        }


        static int[] pathRows = {0,0,-1,-1,-1,1,1,1};
        static int[] pathColumns = {-1,1,1,0,-1,-1,0,1};

        static bool NeighbourExits(int [,] matrix, int newRow, int newColumn)
        {
            if ((newRow >=0) && (newRow <matrix.GetLength(0)) && (newColumn >=0) && (newColumn < matrix.GetLength(1)))
            {
                if(matrix[newRow,newColumn]==1)
                return true;
            }
            return false;
        }

        public void DoDFS(int [,]matrix, int i, int j, bool[,] visited)
        {
            if (visited[i,j])
            {
                return;
            }
            visited[i, j] = true;
            int newRow = 0;
            int newColumn = 0;

            for (int l =0; l < pathRows.Length; l++ )
            {
                newRow = pathRows[l];
                for (int m =0; m <pathColumns.Length; m++)
                {
                    newColumn = pathColumns[m];
                    if (newRow == 0 && newColumn == 0)
                    {
                        continue;
                    }
                    if (NeighbourExits(matrix, i+newRow, j+newColumn))
                    {
                        DoDFS(matrix, i + newRow, j + newColumn, visited);
                    }
                }

            }
            
        }
        public int NumberOfIslands(int[,] matrix)
        {
            bool[,] visited = new bool[matrix.GetLength(0),matrix.GetLength(1)];
            int count = 0;
            for (int i=0; i < matrix.GetLength(0); i++)
            {
                for (int j=0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i,j] == 1 && (!visited[i,j]))
                    {
                        count += 1;
                        DoDFS(matrix, i, j, visited);
                    }
                }
            }
            return count;
        }

        public bool CheckIfGraphIsTree()
        {

            if (CheckForCycleinUnDirectedGraph() && CheckForConnectedGraph(0))
            {
                return true;
            }

            return false;
        }
        public bool CheckForCycleinUnDirectedGraph()
        {
            for (int i = 0; i < vertices; i++)
            {
                if (!visited[i])
                {
                    if (CheckCyclicUtil(i, visited, -1))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            return true;
        }
        public bool CheckForConnectedGraph(int v)
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(v);
            visited[v] = true;

            while (stack.Count != 0)
            {
                int pop = stack.Pop();

                foreach (Edge e in adj[pop])
                {
                    if (!visited[e.v])
                    {
                        stack.Push(e.v);
                        visited[e.v] = true;
                    }
                }
            }
            for (int i = 0; i < vertices; i++)
            {
                if (!visited[i])
                    return false;
            }
            return true;
        }

        public bool CheckCyclicUtil(int vertex, bool[] visited, int parent)
        {
            visited[vertex] = true;

            foreach (Edge e in adj[vertex])
            {
                if (!visited[e.v])
                {
                    CheckCyclicUtil(e.v, visited, vertex);
                }
                else if (vertex != parent)
                {
                    return false;
                }
            }
            return true;
        }

        public int Prims(GraphNode g, int startVertex)
        {
            if (startVertex < g.vertices)
            {
                int minCost = 0;
                Node rootNode = new Node(startVertex);
                MaxBinHeap maxHeap = new  MaxBinHeap(rootNode);
                List<bool> visited = new List<bool>(new bool[g.vertices]);
               
                while (maxHeap.count !=0)
                {
                    int vertex = maxHeap.Remove();
                    Edge e = new Edge(vertex,0);
                    if (visited[e.v] == false)
                    {
                        minCost += e.w;
                        visited[vertex] = true;
                        foreach (Edge i in adj[e.v])
                        {
                           
                            if (visited[i.v] == false)
                            {
                                maxHeap.Insert(new Node(i.w));
                            }
                        }
                    }
                    return minCost;
                }
             
            }
            return -1;
        }
        //Kosaraju's algorithm
        public void StronglyConnectedComponents(GraphNode g)
        {


            bool[] visited = new bool[vertices];
                Stack<int> stack = new Stack<int>();
            
                for (int vertex = 0; vertex < vertices; vertex++)
                {
                    if (!visited[vertex])
                        SccDFSUtility(vertex, visited,stack);
                }
            TransPoseGraph(g);
            
        }
        public void SccDFSUtility(int vertex, bool []visited,Stack<int> stack)
        {
            visited[vertex] = true;
            foreach (Edge e in adj[vertex])
            {
                if (!visited[e.v])
                {
                    SccDFSUtility(e.v, visited, stack);
                }
            }
            stack.Push(vertex);
        }
        static GraphNode TransPoseGraph(GraphNode g)
        {

            GraphNode trans = new GraphNode(g.vertices);
            for (int i = 0; i < g.vertices; i++)
            {
                List<Edge> edges = g.GetEdges(i);
                foreach (var edge in edges)
                {
                    trans.AddEdge(edge.v, i, edge.w);
                }
            }
            return trans;

        }

        public List<Edge> GetEdges(int vertex)
        {
            return adj[vertex];
        }

        public void DegreeOfVetrexesOfGraph()
        {
            int count = 0;
            bool[] visited = new bool[vertices];
            for (int i =0; i < vertices; i++)
            {
                foreach (Edge e in adj[i])
                {
                    if(!visited[e.v])
                        count++;
                    visited[e.v] = true;
                    
                }
                Console.WriteLine(count);
                count = 0;
            }
            Console.ReadLine();
        }


    }
}
