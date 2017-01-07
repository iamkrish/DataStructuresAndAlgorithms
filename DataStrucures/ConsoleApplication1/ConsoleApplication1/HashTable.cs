using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class HashTable<K,V>
    {
        private class LinkedListNode<K,V>
        {
            public K Key;
            public V Value;

            public LinkedListNode<K, V> Next;
            public LinkedListNode<K, V> Prev;

            public LinkedListNode(K key, V value)
            {
                Key = key;
                Value = value;
                Next = null;
                Prev = null;
            }

        }

        IList<LinkedListNode<K, V>> list;

        public HashTable(int capacity)
        {

            list = new List<LinkedListNode<K, V>>(capacity);
            
            foreach( var l in list)
            {
                list.Add(null);
            }
        }

        public void Put(K key, V value)
        {
            LinkedListNode<K, V> node = GetNodeForKey(key);
            if(node!=null)
            {
                node.Value = value;
                return;
            }
            else
            {
                int index = GetKey(key);

                LinkedListNode<K,V> ln = new LinkedListNode<K,V>(key, value);

                LinkedListNode<K, V> currentHead = list[index];
                if(currentHead!=null)
                {
                    ln.Next = currentHead;
                    currentHead.Prev = ln;
                }
                list[index] = ln;

            }
        }

        public void Delete(K Key)
        {
            LinkedListNode<K, V> node = GetNodeForKey(Key);
            if(node!=null)
            {
                if(node.Prev!=null)
                {
                    node.Prev.Next = node.Next;
                }
                else
                {
                    int index = GetKey(Key);
                    list[index] = node.Next;
                }
                if(node.Next!=null)
                {
                    node.Next.Prev = node.Prev;
                }                
            }
        }

        private LinkedListNode<K,V> GetNodeForKey(K key)
        {
            int index = GetKey(key);
            LinkedListNode<K, V> node = list[index];
            while(node!=null)
            {
                if(node.Key.Equals(key))
                {
                    return node;
                }
                node = node.Next;
            }
            return null;

        }

        private int GetKey(K key)
        {
            return Math.Abs(key.GetHashCode() % list.Count);
        }
    }
}
