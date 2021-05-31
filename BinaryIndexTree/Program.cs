using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/**
 
 * Write a program to implement fenwick or binary indexed tree
 * 
 * A Fenwick tree or binary indexed tree is a data structure providing efficient methods
 * for calculation and manipulation of the prefix sums of a table of values.
 * 
 * Space complexity for fenwick tree is O(n)
 * Time complexity to create fenwick tree is O(nlogn)
 * Time complexity to update value is O(logn)
 * Time complexity to get prefix sum is O(logn)
 * 
 */
namespace BinaryIndexTree
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = { 2, 1, 1, 3, 2, 3,
                    4, 5, 6, 7, 8, 9};
            FenwickTree ft = new FenwickTree();
            int [] binaryIndexedTree =ft.createTree(input);

            for(int i=0; i < binaryIndexedTree.Length; i++)
            {
                Console.Write("Index > " + i + " :  ");
                Console.WriteLine( binaryIndexedTree[i]);
            }
            
            //int sum = ft.getSum(binaryIndexedTree,5);
            Console.WriteLine("Sum is : " + ft.getSum(binaryIndexedTree, 5));
            

            input[3] += 6;
            ft.updateBinaryIndexedTree(binaryIndexedTree,6,3);
            //int deltaSum = ft.getSum(binaryIndexedTree, 5);
            Console.WriteLine("Updated Sum is : " + ft.getSum(binaryIndexedTree, 5));
            Console.ReadLine();
        }
    }
}
