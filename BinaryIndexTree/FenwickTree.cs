using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace BinaryIndexTree
{
    public class FenwickTree
    {
        /**
        * Creating tree is like updating Fenwick tree for every value in array
       */
        public int[] createTree(int []input)
        {
            int [] binaryIndexedTree = new int[input.Length+1];
            for (int i=1; i <= input.Length; i++)
            {
                updateBinaryIndexedTree(binaryIndexedTree, input[i-1] ,i);
            }
            return binaryIndexedTree;
        }
        /**
       * Start from index+1 if you updating index in original array. Keep adding this value 
       * for next node till you reach outside range of tree
       */
        public void updateBinaryIndexedTree(int [] binaryIndexedTree,int value, int index)
        {
            while (index < binaryIndexedTree.Length)
            {
                binaryIndexedTree[index] = binaryIndexedTree[index] + value;
                index = getNext(index);
            }
        }
        /**
         * To get next
        * 1) 2's complement of get minus of index
        * 2) AND this with index
        * 3) Add it to index
        */
        private int getNext(int index)
        {
            return index += (index & -index);
        }

        /**
        * Start from index+1 if you want prefix sum 0 to index. Keep adding value
        * till you reach 0
        */
        public int getSum(int [] binaryIndexedTree,int index)
        {
            int sum = 0;
            index = index + 1;
            while (index > 0)
            {
                sum = sum + binaryIndexedTree[index];
                index = getParent(index);
            }
            return sum;
        }

        /**
        * To get parent
        * 1) 2's complement to get minus of index
        * 2) AND this with index
        * 3) Subtract that from index
        */

        private int getParent(int index)
        {
            return index -= (index & -index);
        }
    }
}
