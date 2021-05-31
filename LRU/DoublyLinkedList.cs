using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LRU
{
    class DoublyLinkedList
    {
        Node head;
        Node tail;
        int currentSize;
        int cacheSize;

        public DoublyLinkedList(int cacheSize)
        {
            this.cacheSize = cacheSize;
            this.currentSize = 0;
        }

        public int getCacheSize()
        {
            return cacheSize;
        }

        public Node getTail()
        {
            return tail;
        }

        public Node addPageToList(int pageNumber)
        {
            Node pageNode = new Node(pageNumber);
            if (head == null)
            {
                head = pageNode;
                tail = pageNode;
                currentSize = 1;
                return pageNode;
            }
            else if (currentSize < cacheSize)
            {
                currentSize++;
            }
            else
            {
                tail = tail.prev;
                tail.next = null;
            }
            
                pageNode.next = head;
                head.prev = pageNode;
                head = pageNode;
                return pageNode;
           
        }

        public int getCurrentSize()
        {
            return currentSize;        
        }

        public void movePageToHead(Node pageNode)
        {
            if (pageNode == null || pageNode == head)
                return;
            //This If condition is to find a NEW Tail Node as the PREVIOUSLY
            // designated Tail Node will have 
            // to become NEW Head and we need a replacement of PREVIOUS (Old)Tail Node ,
            //which will be nothing but the previous node of the original tail
            if (pageNode == tail)
            {
                tail = tail.prev;
                tail.next = null;
            }

            Node previous = pageNode.prev;
            Node nextNode = pageNode.next;

            previous.next = nextNode; 

            //This IF condition will set the nextNode only if it is not NULL
            // if it is NULL then there is no action and previous line of code
            // would have taken care of this
            if(nextNode != null)
            nextNode.prev = previous;
            
            pageNode.prev = null;
            pageNode.next = head; 
            head.prev = pageNode; 
            head = pageNode; 
        }

        public void printList()
        {
            if (head == null)
                return;
            Node temp = head;
            while (temp != null)
            {
                Console.WriteLine(temp.getPage());
                temp = temp.next;
            }
        }
    }
}
