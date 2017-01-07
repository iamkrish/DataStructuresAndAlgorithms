using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinglyLinkedLists
{
    internal class Node
    {
        public int Key;
        public Node Next { get; set; }
        public Node(int k)
        {
            Key = k;
            Next = null;
        }
    }

    class SLL
    {
        private Node _head;
        public Node Head
        {
            get
            {
                return _head;
            }
        }

        public SLL()
        {
            _head = null;
        }

        public Node InsertAtHead(int k)
        {
            Node n = new Node(k);
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

        public Node InsertAtEnd(int k)
        {
            Node n = new Node(k);
            if (_head == null)
            {
                _head = n;
            }
            else
            {
                Node p = _head;
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
            Node p = _head;
            while (p != null)
            {
                Console.WriteLine(p.Key);
                p = p.Next;
            }
        }
        public void Reverse()
        {
           // Reverse(ref _head);
           Node p =  Reverse2(Head);
            while(p!=null)
            {
                Console.WriteLine(p.Key);
                p = p.Next;
            }
        }
        private void Reverse(ref Node _head)
        {
            if (_head == null)
            {
                return;
            }

            // Save the current node( and thus its next node)
            Node first = _head;

            //Manipulate the rest and reverse
            Node rest = first.Next;
            if (rest == null)
            {
                return;
            }
            Reverse(ref rest);

            //Add the current node after its next node that we saved via first (1 ->2->1)

            first.Next.Next = first;

            // remove the double link
            first.Next = null;

            //Update the final head
            _head = rest;
        }

        private Node Reverse2(Node head)
        {
            if(head == null || head.Next == null)
            {
                return head;
            }

            //Node rest = head.Next;
            Node rev = Reverse2(head.Next);
            head.Next.Next = head;
            head.Next = null;

            return rev;
           
        }

        public Node SortedMerge(ref Node h1, ref Node h2)
        {
            if (h1 == null && h2 == null) return null;
            if (h1 == null) return h2;
            if (h2 == null) return h1;

            Node result = null;
            SortedMerge2(ref h1, ref h2, ref result);
            return result;
        }

        public Node RecursiveSortedMerge(Node a, Node b)
        {
            if (a == null && b == null) return null;
            if (a == null) return b;
            if (b == null) return a;
            else
            {
                Node result;
                if(a.Key<= b.Key)
                {
                    result = a;
                    a.Next = RecursiveSortedMerge(a.Next, b);
                }
                else
                {
                    result = b;
                    b.Next = RecursiveSortedMerge(b.Next, a);
                }
                return result;
                
            }
        }

        public bool IsPalindrome(Node head)
        {
            if (head == null) return true;
            if (head.Next == null) return true;

            Node slow = head;
            Node fast = head;
            while (fast.Next != null && fast.Next.Next != null)
            {
                slow = slow.Next;
                fast = fast.Next.Next;
            }
            //Node p = null;
            Node p = slow.Next;
            //slow.next=null;


            slow = head;
            Reverse(ref p);

            while (p != null)
            {
                if (slow.Key != p.Key) return false;
                p = p.Next;
                slow = slow.Next;
            }

            return true;
        }

        //Without using duummy node
        private void SortedMerge(ref Node h1, ref Node h2, ref Node result)
        {
            if (h1.Key <= h2.Key)
            {
                InsertAtTail(ref result, ref h1);
            }
            else
            {
                InsertAtTail(ref result, ref h2);
            }
            Node current = result;
            while (true)
            {
                if (h1 == null)
                {
                    current.Next = h2;
                    break;
                }
                else if (h2 == null)
                {
                    current.Next = h1;
                    break;
                }
                else
                {
                    Node curr = current.Next;
                    if (h1.Key <= h2.Key)
                    {
                        InsertAtTail(ref curr, ref h1);

                    }
                    else
                    {
                        InsertAtTail(ref curr, ref h2);

                    }
                    current.Next = curr;
                    current = curr;
                }
            }
            
        }

        //Using Dummy Node
        private void SortedMerge2(ref Node h1, ref Node h2, ref Node result)
        {
            Node dummy = new Node(Int32.MinValue);
            Node current = dummy;
            while (true)
            {
                if (h1 == null)
                {
                    current.Next = h2;
                    break;
                }
                else if (h2 == null)
                {
                    current.Next = h1;
                    break;
                }
                else
                {
                    Node curr = current.Next;
                    if (h1.Key <= h2.Key)
                    {
                        InsertAtTail(ref curr, ref h1);

                    }
                    else
                    {
                        InsertAtTail(ref curr, ref h2);

                    }
                    current.Next = curr;
                    current = curr;
                }
            }
            result = dummy.Next;
        }

        public Node MergeKLists(Node[] lists)
        {

            if (lists == null) return null;

            if (lists.Length == 0) return null;

            if (lists.Length == 1) return lists[0];

            Node result = MergeKLists(lists, 0, lists.Length - 1);
            return result;
        }

        private Node MergeKLists(Node[] lists, int start, int end)
        {
            if (end > start) return null;
            if (start == end)
            {
                
                    return lists[start];
            }
            else
            {
                int mid = start + ((end - start) / 2);
                Node leftResult = MergeKLists(lists, start, mid);
                Node rightResult = MergeKLists(lists, mid + 1, end);

                Node result = MergeLists(leftResult, rightResult);
                return result;

            }
        }

        private Node MergeLists(Node n1, Node n2)
        {
            if (n1 == null && n2 == null) return null;

            if (n1 == null) return n2;
            if (n2 == null) return n1;

            Node result;

            if (n1.Key <= n2.Key)
            {
                result = n1;
                result.Next = MergeLists(n1.Next, n2);
            }
            else
            {
                result = n2;
                result.Next = MergeLists(n1, n2.Next);
            }
            return result;

        }

        private void InsertAtTail(ref Node newHead, ref Node oldHead)
        {
            Node temp = oldHead;
            oldHead = oldHead.Next;
            temp.Next = newHead;
            newHead = temp;
        }

        public Node KthReverse(int k)
        {
            return KReverse(ref _head, k);
        }

        public Node KthReverseAlternateMethod(Node head, int k)
        {
            return KRev(head, k);
        }
       

        private Node KRev(Node head, int k)
        {

            if (head == null)
            {
                return null;
            }

            //Try to get k+1th node;

            Node p = head, p1 = head;

            int count = 0;
            while (p != null && count < k - 1)
            {
                count++;
                p = p.Next;
            }

            if (p == null) return p1;

            Node rest = KRev(p.Next, k);
            p.Next = null;

            Reverse(ref p1, ref p);
            p.Next = rest;
            return p1;


        }

        private void Reverse(ref Node head, ref Node end)
        {
            Node p = head;
            //Node temp1= head;
            end = head;
            Node tail = null, temp = null;
            while (p != null)
            {
                temp = p.Next;
                p.Next = tail;
                tail = p;
                p = temp;
            }
            
            head=tail;
            //end = temp1;
        }




        public Node Add2Lists(Node a, Node b)
        {
            Node s = Add2Lists(a, b, 0);
            Reverse(ref s);
            return s;
        }

        public Node Add2ListsForward(Node a, Node b)
        {
            int bal = 0;
            Node s = Add2ListsForward(a, b, ref bal);
            if(bal>0)
            {
                Node n = new Node(bal);
                n.Next = s;
                s = n;
            }
            //Reverse(ref s);
            return s;
        }
        private Node KReverse(ref Node head, int k)
        {
            if(head == null|| k == 0) return null;
            if (head.Next == null) return head;

            Node KBeg = KthNodeFromBeg(ref head, k);
            Reverse(ref head);
            
            if(KBeg!=null)
            {
                //Find the kth node from beginning
                Node p = head;
                int count = 0;
                while (p != null)
                {
                    count++;
                    if (count == k)
                    {
                        break;
                    }
                    p = p.Next;
                }

                p.Next = KReverse(ref KBeg, k);
            }
            return head;
        }

        private Node KthNodeFromBeg(ref Node start, int k)
        {
            Node p = start;
            Node res = null;
            int count = 0;
            while(p!=null)
            {
                count++;
                if(count == k)
                {
                    res = p.Next;
                    p.Next = null;
                    return res; ;
                }
                p = p.Next;
            }
            return null;
        }

        private Node Add2Lists(Node head1, Node head2,int bal)
        {
            if (head1 == null && head2 == null)
            {
                if(bal > 0)
                {
                    Node n = new Node(bal);
                    return n;
                }
                else
                {
                    return null;
                }
            }

            int sum, remainder, quoitent;
            Node result = null;

            if (head1 == null)
            {
                sum = head2.Key + bal;
                remainder = sum % 10;
                quoitent = sum / 10;
                result = new Node(remainder);
                result.Next = Add2Lists(null, head2.Next, quoitent);
                
            }

            else if(head2 == null)
            {
                sum = head1.Key + bal;
                remainder = sum % 10;
                quoitent = sum / 10;
                result = new Node(remainder);
                result.Next = Add2Lists(head1.Next, null, quoitent);
            }
            
            else
            {
                sum = head1.Key + head2.Key + bal;
                remainder = sum % 10;
                quoitent = sum / 10;
                result = new Node(remainder);
                result.Next = Add2Lists(head1.Next, head2.Next, quoitent);
            }
                       
            return result;
        }



        private Node Add2ListsForward(Node head1, Node head2, ref int bal)
        {
            if(head1==null && head2 == null)
            {
                return null;
            }

            Node prevResult;
            int sum, remainder;
            Node result = null;
            if (head1 == null)
            {
                prevResult = Add2ListsForward(null, head2.Next, ref bal);
                sum = head2.Key + bal;
                remainder = sum % 10;
                bal = sum / 10;

                result = new Node(remainder);
                result.Next = prevResult;
            }

            else if (head2 == null)
            {
                prevResult = Add2ListsForward(head1.Next, null, ref bal);
                sum = head1.Key + bal;
                remainder = sum % 10;
                bal = sum / 10;

                result = new Node(remainder);
                result.Next = prevResult;
            }

            else
            {
                prevResult = Add2ListsForward(head1.Next, head2.Next, ref bal);
                sum = head1.Key + head2.Key+ bal;
                remainder = sum % 10;
                bal = sum / 10;

                result = new Node(remainder);
                result.Next = prevResult;
            }           
            return result;
        }

        public Node GetIntersectionNode(Node headA, Node headB)
        {
            if (headA == null || headB == null) return null;
            if (headA == headB) return headA;
            if (headA.Next == headB)
            {
                return headB;
            }
            else if (headB.Next == headA) return headA;

            else
            {
                int l1 = GetLength(headA);
                int l2 = GetLength(headB);

                Node p1 = headA;
                Node p2 = headB;

                if (l1 > l2)
                {
                    //Move l1 forward by l1-l2 steps
                    p1 = MoveForward(headA, l1 - l2);
                }
                else if (l2 > l1)
                {
                    //Move l2 forward by l2-l1 steps

                    p2 = MoveForward(headB, l2 - l1);
                }

                while (p1 != null && p2 != null)
                {
                    if (p1 == p2) return p1;
                    p1 = p1.Next;
                    p2 = p2.Next;
                }
                return null;
            }
        }

        private int GetLength(Node n)
        {
            int count = 0;
            Node p = n;
            while (p != null)
            {
                count++;
                p = p.Next;
            }
            return count;
        }

        private Node MoveForward(Node head, int count)
        {
            Node p = head;
            int c = 0;
            while (p != null)
            {
                if (c == count)
                {
                    return p;
                }
                c++;
                p = p.Next;
            }
            return null;
        }

        public Node OddEvenList(Node head)
        {

            if (head == null || head.Next == null || head.Next.Next == null) return head;

            Node p1 = head;
            Node p2 = head.Next;
            Node connect = p2;

            while (p1 != null && p2 != null)
            {
                Node t = p2.Next;
                if (t == null) break;
                //p2= p1.next;
                p1.Next = p2.Next;
                p1 = p1.Next;
                //p1.Next = p2;
                p2.Next = p1.Next;
                p1.Next = p2;
                p2 = p2.Next;
            }
            p1.Next = connect;
            return head;
        }
    }
}
