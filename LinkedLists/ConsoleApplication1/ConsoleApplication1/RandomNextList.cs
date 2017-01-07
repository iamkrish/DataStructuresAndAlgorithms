using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    internal class RandomNode
    {
        public int Key;
        public RandomNode Next { get; set; }
        public RandomNode Random { get; set; }
        public RandomNode(int k)
        {
            Key = k;
            Next = null;
            Random = null;
        }
    }

    class RandomNodeList
    {
        private RandomNode _head;
        public RandomNode Head
        {
            get
            {
                return _head;
            }
        }

        public RandomNodeList()
        {
            _head = null;
        }

        public RandomNode InsertAtHead(int k)
        {
            RandomNode n = new RandomNode(k);
            if (_head == null)
            {
                _head = n;
            }
            else
            {
                n.Next = _head;
                _head = n;
            }
            return _head;
        }

        public RandomNode InsertAtEnd(int k)
        {
            RandomNode n = new RandomNode(k);
            if (_head == null)
            {
                _head = n;
            }
            else
            {
                RandomNode p = _head;
                while (p.Next != null)
                {
                    p = p.Next;
                }
                p.Next = n;
            }
            return _head;
        }

        public void Print()
        {
            RandomNode p = _head;
            while (p != null)
            {
                Console.WriteLine(p.Key);
                p = p.Next;
            }
        }

        public RandomNode CopyRandomList(RandomNode head)
        {

            if (head == null) return head;

            RandomNode p1 = head;

            //Add copy
            while (p1 != null)
            {
                RandomNode n = new RandomNode(p1.Key);
                n.Next = p1.Next;
                p1.Next = n;
                p1 = n.Next;
            }

            //Fix random nodes
            p1 = head;
            while (p1 != null && p1.Next != null)
            {
                if (p1.Random == null)
                {
                    p1.Next.Random = null;
                }
                else
                {
                    p1.Next.Random = p1.Random.Next;

                }
                p1 = p1.Next.Next;

            }

            //Fix next pointers
            p1 = head;
            RandomNode head2 = p1.Next;
            while (p1 != null && p1.Next!=null)
            {
                RandomNode temp = p1.Next;
                p1.Next = temp.Next;
                p1 = temp;
            }
            return head2;
        }
    }
      
}
