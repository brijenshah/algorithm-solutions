using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Solutions.LinkedList
{
    public class Node
    {
        public int Key;
        public int Value;
        public Node Pre;
        public Node Next;

        public Node(int key, int value)
        {
            this.Key = key;
            this.Value = value;
        }
    }

    public class LRUCache
    {
        int capacity;
        Dictionary<int, Node> map = new Dictionary<int, Node>();
        Node head = null;
        Node end = null;

        public LRUCache(int capacity)
        {
            this.capacity = capacity;
        }

        public int get(int key)
        {
            if (map.ContainsKey(key))
            {
                Node n = map[key];
                remove(n);
                setHead(n);
                return n.Value;
            }

            return -1;
        }

        private void remove(Node n)
        {
            if (n.Pre != null)
            {
                n.Pre.Next = n.Next;
            }
            else
            {
                head = n.Next;
            }

            if (n.Next != null)
            {
                n.Next.Pre = n.Pre;
            }
            else
            {
                end = n.Pre;
            }

        }

        private void setHead(Node n)
        {
            n.Next = head;
            n.Pre = null;

            if (head != null)
                head.Pre = n;

            head = n;

            if (end == null)
                end = head;
        }

        public void set(int key, int value)
        {
            if (map.ContainsKey(key))
            {
                Node old = map[key];
                old.Value = value;
                remove(old);
                setHead(old);
            }
            else
            {
                Node created = new Node(key, value);
                if (map.Count >= capacity)
                {
                    map.Remove(end.Key);
                    remove(end);
                    setHead(created);

                }
                else
                {
                    setHead(created);
                }

                map.Add(key, created);
            }
        }
    }

    [TestClass]
    public class TestLRUCache
    {
        [TestMethod]
        [TestCategory("LinkedList")]
        public void LRU_Cache()
        {
            LRUCache cache = new LRUCache(2 /* capacity */ );

            cache.set(1, 1);
            cache.set(2, 2);
            cache.get(1);       // returns 1
            cache.set(3, 3);    // evicts key 2
            cache.get(2);       // returns -1 (not found)
            cache.set(4, 4);    // evicts key 1
            cache.get(1);       // returns -1 (not found)
            cache.get(3);       // returns 3
            cache.get(4);       // returns 4
        }
    }
}
