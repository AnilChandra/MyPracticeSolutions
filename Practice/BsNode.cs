using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    class BsNode
    {
        private int data;
        private BsNode left;
        private BsNode right;


        
        public int GetData()
        {
            return data;
        }
        public void SetData(int data)
        {
            this.data = data;
        }

        public BsNode GetLeft()
        {
            return left;
        }
        public void SetLeft(BsNode left)
        {
            this.left = left;
        }

        public BsNode GetRight()
        {
            return right;
        }
        public void SetRight(BsNode right)
        {
            this.right = right;
        }

        public BsNode(int data)
        {
            this.data = data;
        }

    }

    class Node
    {
        private string key;
        private string value;

        private Node prev;
        private Node next;

        public Node(string key, string value)
        {
            this.key = key;
            this.value = value;
              
        }

        internal string getValue()
        {
            throw new NotImplementedException();
        }

        internal void SetValue(string value)
        {
            throw new NotImplementedException();
        }

        internal string GetKey()
        {
            throw new NotImplementedException();
        }
    }

    public class LRUCache
    {
        private Dictionary<string, Node> map;
        private int capacity;
        private Node head = null;
        private Node tail = null;

        public LRUCache(int capacity)
        {
            this.capacity = capacity;
            map = new Dictionary<string, Node>();
        }


        public string Get(string key)
        {
            if (!map.ContainsKey(key))
            {
                return null;
            }
            Node node = map[key];
            DeleteFromList(node);
            SetListHead(node);

            return node.getValue();

        }

        public void Put(string key, string value)
        {
            if (map.ContainsKey(key))
            {
                Node node = map[key];
                node.SetValue(value);
                DeleteFromList(node);
                SetListHead(node);
            }
            else
            {
                if (map.Count >= capacity)
                {
                    map.Remove(tail.GetKey());
                    DeleteFromList(tail);
                }

                Node node = new Node(key,value);
                map.Add(key,node);
                SetListHead(node);
            }
        }

        private void DeleteFromList(Node node)
        {
            throw new NotImplementedException();
        }

        private void SetListHead(Node node)
        {
            throw new NotImplementedException();
        }
    }

    public class TokenBucket
    {
        private long bucketSize;
        private long refillRate;

        private double currentBucketSize;
        private long lastRefillTimeStmap;

        public TokenBucket(long bucketSize, long refillRate)
        {
            this.bucketSize = bucketSize;
            this.refillRate = refillRate;

            currentBucketSize = bucketSize;
            lastRefillTimeStmap = System.DateTime.Now.Second;
        }

        public bool AllowRequests(int tokens)
        {
            refill();

            if (currentBucketSize >= tokens)
            {
                currentBucketSize -= tokens;
                return true;
            }

            return false;
        }

        private void refill()
        {
            long now = System.DateTime.Now.Second;
            double tokensToAdd = (now - lastRefillTimeStmap) * refillRate;
            currentBucketSize = Math.Min(currentBucketSize + tokensToAdd, bucketSize);
            lastRefillTimeStmap = now;
        }
    }
    

}
