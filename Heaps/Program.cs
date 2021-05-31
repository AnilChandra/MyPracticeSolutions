using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heaps
{
    class Program
    {
        static MaxBinHeap SampleTree()
        {
            Node root = new Node(45);
            MaxBinHeap heap = new MaxBinHeap(root);
            //MinBinHeap heap = new MinBinHeap(root);
            heap.Insert(new Node(55));
            heap.Insert(new Node(67));
            heap.Insert(new Node(47));
            return heap;
        }

        static void Main(string[] args)
        {


            MaxBinHeap heap = SampleTree();
            //MinBinHeap heap = SampleTree();
            Console.WriteLine("\r\nDFS -->"); heap.PrintHeap();
            Console.ReadLine();

            //heap.Insert(new Node(60));
            //heap.Insert(new Node(81));
            //heap.Insert(new Node(51));
            //Console.WriteLine("\r\nDFS -->"); heap.PrintHeap();

            //heap.Insert(new Node(95));
            //Console.WriteLine("\r\nDFS --> "); heap.PrintHeap();
            //Console.ReadLine();
            heap.Remove();
            Console.WriteLine("\r\nDFS --> "); heap.PrintHeap();
            //Console.ReadLine();
            heap.Remove();
            heap.Remove();
            heap.Remove();
            Console.WriteLine("\r\nDFS --> "); heap.PrintHeap();
            Console.ReadLine();
        }
    }
}
