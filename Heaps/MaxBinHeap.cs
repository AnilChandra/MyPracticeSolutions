using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// In Max Heap parent node is always greater than equal to its child node
namespace Heaps
{
    public class MaxBinHeap
    {
        Node root;
        Node insert_pos;
        public int count = 0;

        public MaxBinHeap(Node node)
        {
            root = node;
            insert_pos = node;
            count++;
        }

        public void Insert(Node n)
        {
            if (insert_pos.left == null)
            {
                insert_pos.left = n;
                n.parent = insert_pos;
                //Balance heap to get MAX node at the top
                Balanceheap(n);
                return;
            }
            else
            {
                insert_pos.right = n;
                n.parent = insert_pos;

                AdjustInsertPosition();
                //Balance heap to get MAX node at the top
                Balanceheap(n);

            }
            count++;
        }
        private void Balanceheap(Node n)
        {
            while (n.parent != null)
            {
                if (n.parent.data < n.data)
                {
                    int temp = n.data;
                    n.data = n.parent.data;
                    n.parent.data = temp;
                   // n = n.parent; // is this step needed ?

                }
                else
                {
                    break;
                }

            }
        }
        private void AdjustInsertPosition()
        {
            Node node;
            Queue<Node> q = new Queue<Node>();
            q.Enqueue(root);

            while (q.Count > 0)
            {
                node = q.Dequeue();

                if (node.left != null)
                {
                    q.Enqueue(node.left);
                }
                else
                {
                    insert_pos = node;
                    break;
                }

                if (node.right != null)
                {
                    q.Enqueue(node.right);
                }
                else
                {
                    insert_pos = node;
                    break;
                }
            }
        }

        public int Remove()
        {

            Node n = new Node(root.data);
            Queue<Node> q = new Queue<Node>();
            q.Enqueue(root);

            //This loop is to get the last node so that it can be inserted in 
            //place of the ROOT : This is because root will be removed as part
            //of 1st node in Heap and we need to replace with the last added node
            //in the Heap
            while (q.Count != 0)
            {
                n = q.Dequeue();

                if (n.left != null)
                    q.Enqueue(n.left);
                if (n.right != null)
                    q.Enqueue(n.right);
            }
            int retVal = root.data;
            root.data = n.data;
            count--;

            //This condition is for ROOT node beeing the node to be removed
            //in which case parent will be null
            if (n.parent == null)
            {
                retVal = root.data;
                root = null;
                insert_pos = null;
                return retVal;
            }
            //if the node replacing the root is in the left i.e.
            //the last node to be added to Heap is in the left, we set
            //that to null
            if (n.parent.left == n)
            {
                n.parent.left = null;
            }
            //if the node replacing the root is in the right i.e.
            //the last node to be added to Heap is in the right, we set
            //that to null
            else
            {
                n.parent.right = null;
            }

            //Once we made sure that we have retrived the value to be returned
            //as part of MaxHeap, we need to Heapify i.e. we need to get the MAX node
            //at the top of the Heap
            Heapify();

            return retVal;
        }

        public void Heapify()
        {

            Node compare;
            Node pointer = root;

            while (true)
            {
                if (pointer.left == null)
                    break;
                if (pointer.right == null)
                    compare = pointer.left;

                else
                {
                    if (pointer.left.data >= pointer.right.data)
                    {
                        compare = pointer.left;
                    }
                    else
                    {
                        compare = pointer.right;
                    }

                }
                if (pointer.data < compare.data)
                {
                    int tempData = pointer.data;
                    pointer.data = compare.data;
                    compare.data = tempData;
                    pointer = compare;
                }
                else
                {
                    break;
                }
            }

        }
        public void PrintHeap()
        {

            Node node;
            Queue<Node> q = new Queue<Node>();
            q.Enqueue(root);
            while (q.Count !=0)
            {
                node = q.Dequeue();
                if (node == null)
                    return;
                Console.WriteLine(node.data);

                if (node.left != null)
                    q.Enqueue(node.left);
                if (node.right != null)
                    q.Enqueue(node.right);
            }
        }
    }
}
