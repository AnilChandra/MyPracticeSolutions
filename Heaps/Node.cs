using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heaps
{
    public class Node
    {

        public Node left;
        public Node right;
        public Node parent;
        public int data;

        public Node(int data)
        {
            this.data = data;
            left = null;
            right = null;
            parent = null;

        }

    }

   
}
