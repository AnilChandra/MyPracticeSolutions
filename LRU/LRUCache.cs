using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LRU
{
    class LRUCache
    {
        DoublyLinkedList pageList;
        Dictionary<int, Node> pageMap;
        int cacheSize;

        public LRUCache(int cacheSize)
        {
            this.cacheSize = cacheSize;
            this.pageList = new DoublyLinkedList(cacheSize);
            this.pageMap = new Dictionary<int, Node>();

        }
        public void accessPage(int pageNumber)
        {
            Node pageNode = null;
            // If page is present in the cache, move the page to the start of list
            if (pageMap.ContainsKey(pageNumber))
            {
                pageNode = pageMap[pageNumber];
                pageList.movePageToHead(pageNode);
            }
            else
            {
                //If the list is full remove the tail from the doublyLinkedList
                // and the map
                if (pageList.getCurrentSize() == pageList.getCacheSize())
                {
                    pageMap.Remove(pageList.getTail().getPage());
                }
                pageNode= pageList.addPageToList(pageNumber);
                pageMap.Add(pageNumber,pageNode);
            }

        }

        public void printCacheState()
        {
            pageList.printList();
        }
    }
}
