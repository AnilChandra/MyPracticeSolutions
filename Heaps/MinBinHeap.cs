using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heaps
{
    public class MinBinHeap
    {

        Node root;
        Node insert_pos;

        public MinBinHeap(Node node)
        {
            root = node;
            insert_pos = node;
        }

        public void Insert(Node n)
        {
            if (insert_pos.left == null)
            {

                insert_pos.left = n;
                n.parent = insert_pos;
                Balance(n);
                return;
            }
            else
            {
                insert_pos.right = n;
                n.parent = insert_pos;
                AdjustInsertPosition();
                Balance(n);
            }
        }

        private void Balance(Node n)
        {
            while (n.parent != null)
            {
                if (n.parent.data > n.data)
                {
                    int temp = n.data;
                    n.data = n.parent.data;
                    n.parent.data = temp;
                    n = n.parent;
                }
                else
                    break;
            }
            
        }
        private void AdjustInsertPosition()
        {
            Node n;
            Queue<Node> q = new Queue<Node>();
            q.Enqueue(root);
            while (q.Count !=0)
            {
                n = q.Dequeue();

                if (n.left != null)
                {
                    q.Enqueue(n.left);
                }
                else
                {
                    insert_pos = n;
                    break;
                }
                if (n.right != null)
                {
                    q.Enqueue(n.right);
                }
                else
                {
                    insert_pos = n;
                    break;
                }
            }

        }

        public void PrintHeap()
        {

            Node node;
            Queue<Node> q = new Queue<Node>();
            q.Enqueue(root);
            while (q.Count != 0)
            {
                node = q.Dequeue();
                Console.WriteLine(node.data);

                if (node.left != null)
                    q.Enqueue(node.left);
                if (node.right != null)
                    q.Enqueue(node.right);
            }
        }

    }
}
