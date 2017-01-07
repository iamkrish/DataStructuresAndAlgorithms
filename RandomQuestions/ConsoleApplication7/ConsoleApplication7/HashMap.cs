using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication7
{
    class LinkedListNode<K, V> where K :IComparable where V :IComparable
    {
        public K Key;
        public V Value;
        public LinkedListNode<K, V> Next;
        public LinkedListNode<K, V> Previous;

        public LinkedListNode(K key, V value)
        {
            Key = key;
            Value = value;
            Next = null;
            Previous = null;
        }
    }

    class CustomHashMap<K,V> where K :IComparable where V :IComparable
    {       

        private List<LinkedListNode<K, V>> list;
        private int Capacity;

        public CustomHashMap(int n)
        {
            list = new List<LinkedListNode<K, V>>(n);
            Capacity = n;
            for(int i =0; i< list.Count;i++)
            {
                list[i] = null;
            }
        }

        public void Put(K key, V Value)
        {
            LinkedListNode<K, V> n = GetNode(key);
            if(n!=null)
            {
                n.Value = Value;
            }
            else
            {
                LinkedListNode<K, V> node = new LinkedListNode<K, V>(key, Value);
                int index = GetIndex(key);
                if(list[index]!=null)
                {
                    LinkedListNode<K, V> front = list[index];
                    n.Next = front;
                    front.Previous = n;

                }
                else
                {
                    list[index] = node;
                }
            }
        }

        public V Get(K key)
        {
            LinkedListNode<K, V> node = GetNode(key);
            if(node!=null)
            {
                return node.Value;
            }
            return default(V);
        }



        private LinkedListNode<K,V> GetNode(K key)
        {
            int index = GetIndex(key);
            if(list.Count>=index && list[index]!=null)
            {
                LinkedListNode<K,V> n = list[index];
                while(n!=null)
                {
                    if(key.CompareTo(n.Key)==0)
                    {
                        return n;
                    }
                    n = n.Next;

                }
                
            }
            return null;

        }

        private int GetIndex(K key)
        {
            int hash = Math.Abs(key.GetHashCode() % Capacity);
            return hash;
        }

    }
}
