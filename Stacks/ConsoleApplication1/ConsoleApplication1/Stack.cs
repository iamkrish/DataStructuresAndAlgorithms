using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class CustomStack
    {
        private Node top1;
        private Node top2;

        public CustomStack()
        {
            top1 = null;
            top2 = null;
        }

        public void Push(int x)
        {
            Node n = new Node(x);

            if(top1==null)
            {
                top1 = n;
            }
            else
            {
                n.Next = top1;
                top1 = n;
            }

            if(top2 == null)
            {
                top2 = n;
            }
            else
            {
                if(x< top2.Key)
                {
                    Node n2 = new Node(x);
                    n2.Next = top2;
                    top2 = n;
                }
            }
        }

        public int Pop()
        {
            if(top1==null)
            {
                return -1;
            }
            else
            {
                
                Node n1 = top1;
                int val = n1.Key;
                top1 = top1.Next;
                n1=null;

                if(top2.Key == val)
                {
                    Node n2 = top2;
                    n2 = null;
                    top2 = top2.Next;
                }

                return val;
            }
        }

        public int Peek()
        {
            if(top1==null)
            {
                return -1;
            }
            return top1.Key;
        }

        public int Min()
        {
            if (top2 == null) return -1;
            return top2.Key;
        }
    }

    public class Node
    {
        public int Key { get; set; }
        public Node Next { get; set; }
        public Node(int k)
        {
            Key = k;
        }
    }
}
