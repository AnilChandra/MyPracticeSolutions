using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LRU
{
    class Node
    {

        public Node next;
        public Node prev;
        int pageNumber;

        public Node(int pageNumber)
        {
            this.pageNumber = pageNumber;
        }

        public int getPage()
        {
            return pageNumber;
        }

    }
}
