using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class LRUCache
    {
        private IDictionary<int, DllNode> dic;

        private int Capacity;

        private DllNode Head, Tail;

        public LRUCache(int capacity)
        {
            Capacity = capacity;
            dic = new Dictionary<int, DllNode>(Capacity);
            Head = null;
            Tail = null;
        }

        public int Get(int key)
        {
            if(!dic.ContainsKey(key))
            {
                return -1;
            }

            DllNode n = dic[key];
            if(n!=Head)
            {
                RemoveFromLinkedList(n);
                AddToFront(n);
            }
            return n.Value;

        }

        private void RemoveFromLinkedList(DllNode n)
        {
            if (n == null) return;
            if (n.Prev != null)
            {
                n.Prev.Next = n.Next;
            }
            if (n.Next != null)
            {
                n.Next.Prev = n.Prev;
            }

            if(n==Tail)
            {
                Tail = n.Prev;
            }
            if(n==Head)
            {
                Head = n.Next;
            }
        }

        private void AddToFront(DllNode n)
        {
            if (n == null) return;            
            if(Head == null)
            {
                Head = n;
                Tail = n;
            }
            else
            {
                Head.Prev = n;
                n.Next = Head;
                Head = n;
            }           
        }

        //Insert or Update
        public void Set(int key, int value)
        {
            DllNode n = null;
            if(dic.ContainsKey(key))
            {
                n = dic[key];
                RemoveKey(key);
            }

            n = new DllNode(key, value);

            //Add it back to the head;
            if (dic.Count==Capacity)
            {
                // Remove least recently used
                bool b = RemoveKey(Tail.Key);
                if(b)
                {
                    dic.Add(key, n);
                    AddToFront(n);
                }
            }
            else
            {
                dic.Add(key, n);
                AddToFront(n);
            }
        }

        public bool RemoveKey(int key)
        {
            if(!dic.ContainsKey(key))
            {
                return false;
            }

            DllNode n = dic[key];
            RemoveFromLinkedList(n);

            dic.Remove(key);
            return true;
        }

    }

    public class DllNode
    {
        public int Key;
        public int Value;

        public DllNode Next;
        public DllNode Prev;

        public DllNode(int k, int v)
        {
            Key = k;
            Value = v;
            Next = null;
            Prev = null;
        }

    }

}
