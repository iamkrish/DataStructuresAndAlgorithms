using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SinglyLinkedLists;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            //RandomNodeList rnl = new RandomNodeList();
            //rnl.InsertAtHead(4);
            //rnl.InsertAtHead(3);
            //rnl.InsertAtHead(2);
            //rnl.InsertAtHead(1);

            //// 1->3
            //rnl.Head.Random = rnl.Head.Next.Next;

            //// 2 -> 2
            //rnl.Head.Next.Random = null;

            //// 3 -> 4
            //rnl.Head.Next.Next.Random = rnl.Head.Next.Next.Next;

            ////4-1

            //rnl.Head.Next.Next.Next.Random = rnl.Head.Next;

            //var what = rnl.CopyRandomList(rnl.Head);

            LRUCacheDS c = new LRUCacheDS(2);
            IList<int> res = new List<int>();

            //c.Set(2, 1);
            //c.Set(1, 1);
            //c.Get(2);
            //c.Set(4, 1);
            //c.Get(1);
            //c.Get(2);

            //c.Set(1, 1);
            //res.Add(c.Get(2));
            //c.Set(4, 1);
            //res.Add(c.Get(1));
            //res.Add(c.Get(2));
            //c.Set(1, 100);
            //c.Set(2, 200);
            //c.Set(3, 300);
            //c.Set(4, 400);
            //c.Set(5, 500);

            //c.Set(6, 600);
            //c.Get(3);
            //c.Set(4, 4000);

            SLL sl1 = new SLL();
            sl1.InsertAtHead(0);
            sl1.InsertAtEnd(1);
           // sl1.InsertAtEnd(2);
            //sl1.InsertAtEnd(3);
            //sl1.InsertAtEnd(4);
            //sl1.InsertAtEnd(3);
            //sl1.InsertAtEnd(2);
            //sl1.InsertAtEnd(1);

            bool pall = sl1.IsPalindrome(sl1.Head);

            //sl1.InsertAtEnd(8);
            var what = sl1.KthReverseAlternateMethod(sl1.Head, 3);
            var p = sl1.OddEvenList(sl1.Head);
            //sl1.InsertAtEnd(6);
            //sl.Print();
            //sl1.Reverse();

            SLL sl2 = new SLL();
            sl2.InsertAtHead(2);
            sl2.InsertAtEnd(5);
            sl2.InsertAtEnd(6);
            sl2.InsertAtEnd(7);

            Node h1 = sl1.Head;
            Node h2 = sl2.Head;

            SLL sl3 = new SLL();

           // SLL a = new SLL();
           // a.InsertAtHead(3);
           // a.InsertAtHead(6);
           // a.InsertAtHead(5);

           // SLL b = new SLL();
           //// b.InsertAtHead(2);
           // b.InsertAtHead(4);
           // b.InsertAtHead(8);

           // SLL c = new SLL();
           // Node h = c.Add2Lists(a.Head, b.Head);

            SLL a = new SLL();
            a.InsertAtEnd(9);
            a.InsertAtEnd(9);
            a.InsertAtEnd(9);

            SLL b = new SLL();
            b.InsertAtEnd(0);
            b.InsertAtEnd(0);
            b.InsertAtEnd(2);

            //SLL c = new SLL();
            //Node h = c.Add2ListsForward(a.Head, b.Head);

            //while (h!=null)
            //{
            //    Console.WriteLine(h.Key);
            //    h = h.Next;
            //}

            Queue<int> q = new Queue<int>();
            //q.Enqueue(null);
            //Node res = sl3.SortedMerge(ref h1, ref h2);
            // Node merged = sl1.SortedMerge(sl1.Head, sl2.Head);

            //Node result = sl3.RecursiveSortedMerge(sl1.Head, sl2.Head);
            //sl1.Print();

            // Node res = sl1.KthReverse(3);

            IList<Node> lists = new List<Node>();
            SLL s_a = new SLL();
            SLL s_b = new SLL();
            s_b.InsertAtHead(1);
            lists.Add(s_a.Head);
            lists.Add(s_b.Head);

            SLL s_c = new SLL();
            //  Node n0=s_c.MergeKLists(lists.ToArray<Node>());
            IList<string> l = new List<string>();

            SLL list1 = new SLL();
            list1.InsertAtHead(5);
            list1.InsertAtEnd(6);
            list1.InsertAtEnd(7);
            list1.InsertAtEnd(8);
            list1.InsertAtEnd(9);

            SLL list2 = new SLL();
            list2.InsertAtEnd(1);
            list2.InsertAtEnd(2);
            list2.InsertAtEnd(3);
            list2.InsertAtEnd(4);
            list2.Head.Next.Next.Next.Next = list1.Head;

            var node = list1.GetIntersectionNode(list1.Head, list2.Head);
            Console.ReadLine();
        }
    }
}
