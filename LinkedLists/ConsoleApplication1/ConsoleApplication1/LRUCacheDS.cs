using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class LRUCacheDS
    {
        private DoublyLinkedListNode Head;
        private DoublyLinkedListNode Tail;

        private IDictionary<int, DoublyLinkedListNode> dictionary;

        private int maxCapacity;
        private int currentCapacity;

        public LRUCacheDS(int capacity)
        {
            maxCapacity = capacity;
            Head = null;
            Tail = null;
            dictionary = new Dictionary<int, DoublyLinkedListNode>();
            currentCapacity = 0;
        }

        public int Get(int key)
        {
            if(dictionary.ContainsKey(key))
            {
                DoublyLinkedListNode n = dictionary[key];
                int res = n.Value;
                if(n!=Head)
                {
                    RemoveFromLinkedList(n);
                    InsertAtHead(n);
                    return res;
                }

            }
            return -1;

        }

        public void Set(int key, int value)
        {
            if(dictionary.ContainsKey(key))
            {
                DoublyLinkedListNode n = dictionary[key];
                RemoveFromLinkedList(n);
                InsertAtHead(n);
                currentCapacity++;
            }
            else
            {                
                if(!CanAdd())
                {
                    if(Tail!=null &&!RemoveKey(Tail.Key))
                    {
                        return;
                    }
                }

                DoublyLinkedListNode n = new DoublyLinkedListNode(key);
                n.Value = value;
                InsertAtHead(n);
                dictionary.Add(key,n);
                currentCapacity++;              

            }

            
        }

        private void InsertAtHead(DoublyLinkedListNode node)
        {
            //set the head/tail

            if (Head == null)
            {
                Head = node;
                Tail = Head;
            }
            else
            {
                node.Next = Head;
                Head.Previous = node;
                Head = node;
            }
            
        }


        //Dont remove from dictionary
        public void RemoveFromLinkedList(DoublyLinkedListNode node)
        {
            if(node.Previous!=null)
            {
                node.Previous.Next = node.Next;
            }
            if(node.Next!=null)
            {
                node.Next.Previous = node.Previous;
            }

            if(Head==node)
            {
                Head = node.Next;
            }
            if(Tail==node)
            {
                Tail = node.Previous;
            }           

        }

        public bool RemoveKey(int key)
        {
            if (!dictionary.ContainsKey(key)) return false;
            var n = dictionary[Tail.Key];

            RemoveFromLinkedList(n);
            dictionary.Remove(key);           
            currentCapacity--;
            return true;
        }

        private bool CanAdd()
        {
            return currentCapacity < maxCapacity;
        }
    }

    public class DoublyLinkedListNode
    {
        public int Key;
        public int Value;
        public DoublyLinkedListNode Next;
        public DoublyLinkedListNode Previous;

        public DoublyLinkedListNode(int key)
        {
            Key = key;
            Next = null;
            Previous = null;
            Value = 0;
        }
    }

}
