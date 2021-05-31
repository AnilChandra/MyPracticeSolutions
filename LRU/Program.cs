using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LRU
{
    class Program
    {
        static void Main(string[] args)
        {
            int cacheSize = 4;
            LRUCache cache = new LRUCache(cacheSize);
            cache.accessPage(4);
            //cache.printCacheState();
            cache.accessPage(3);
            //cache.printCacheState();
            cache.accessPage(31);
            //cache.printCacheState();
            cache.accessPage(13);
            //cache.printCacheState();

            //Now pagenumber: 4 should be removed as cache size exceeds 4
            cache.accessPage(99);
            cache.printCacheState();

            //As pagenumber: 31 already exists it should move to Head
            cache.accessPage(3);
            cache.printCacheState();
            Console.ReadLine();
        }
    }
}
