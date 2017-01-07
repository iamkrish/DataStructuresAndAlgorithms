using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    internal class LinkedListNode
    {
        public LinkedListNode Previous { get; set; }
        public LinkedListNode Next { get; set; }
        public int Key { get; set; }

        public LinkedListNode(int k)
        {
            Key = k;
            Next = null;
            Previous = null;
        }
    }

    internal class DoublyLinkedList
    {
        public LinkedListNode Head { get; set; }
        public LinkedListNode Tail { get; set; }

        public DoublyLinkedList()
        {
            Head = null;
            Tail = null;
        }

    }

    internal class SingleLinkedList
    {
        public LinkedListNode Head;

        public SingleLinkedList()
        {
            Head = null;
        }

        public void InsertAtEnd(int k)
        {
            LinkedListNode n = new LinkedListNode(k);
            if(Head == null)
            {
                Head = n;
            }
            else
            {
                LinkedListNode p = Head;
                while(p.Next!=null)
                {
                    p = p.Next;
                }
                p.Next = n;
            }
        }

        public void Print()
        {
            LinkedListNode p = Head;
            while(p!=null)
            {
                Console.WriteLine(p.Key);
                p = p.Next;
            }
        }

        
    }
}