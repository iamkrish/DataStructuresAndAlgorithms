using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    internal class Node
    {
        // Why mark the properties of internal class as public
        // http://stackoverflow.com/questions/9302236/why-use-a-public-method-in-an-internal-class/9302642#9302642

        public int Key { get; set; }

        public Node Left { get; set; }

        public Node Right { get; set; }

        public Node Inorder { get; set; }

        public Node Next { get; set; }

        public Node(int k)
        {
            Key = k;
            Left = null;
            Right = null;
            Inorder = null;
            Next = null;
        }
    }

    internal class BinarySearchTrees
    {
        public Node Root { get; private set; }

        public BinarySearchTrees()
        {
            Root = null;
        }

        public void Insert(int val, bool isRecursive = false)
        {
            if (!isRecursive)
            {
                InsertIterative(val);
            }
            else
            {
                Root = InsertRecursive(Root, val);
            }
        }

        public void PrintBSTInorder()
        {
            PrintBSTInorder(Root);
        }

        public void Mirror()
        {
            if (Root == null) return;
            if(Root.Left == null && Root.Right == null)
            {
                Console.WriteLine(Root.Key);
                return;
            }

            Node mirrorRoot = MirrorHelper(Root);
            PrintBSTInorder(mirrorRoot);

        }

        public void  UpsideDown()
        {
            Root = UpsideDown(this.Root);
            this.PrintBSTInorder();

        }

        public Node ConvertSLLToBST(LinkedListNode head)
        {
            if (head == null) return null;
            int len = GetLength(head);
            return ConvertSLLHelper(ref head, 0, len-1);
        }
        private Node ConvertSLLHelper(ref LinkedListNode head, int s, int e)
        {
            if(s>e)
            {
                return null;
            }
         
            int m = s + (e - s) / 2;
            Node l = ConvertSLLHelper(ref head, s, m - 1);
            Node parent = new Node(head.Key);
            parent.Left = l;
            head = head.Next;
            parent.Right = ConvertSLLHelper(ref head, m + 1, e);
            return parent;
        }

        private int GetLength(LinkedListNode head)
        {
            LinkedListNode p = head;
            int count = 0;
            while(p!=null)
            {
                count++;
                p = p.Next;
            }
            return count;
        }
        private Node UpsideDown(Node root)
        {
            if(root == null)
            {
                return null;
            }

            if(root.Left == null && root.Right == null)
            {
                return root;
            }

            Node left = UpsideDown(root.Left);
            Node right = UpsideDown(root.Right);

            //Get the right most node for the left subtree
            Node p = left;
            while(p.Right!=null)
            {
                p = p.Right;
            }
            p.Left = right;
            p.Right = root;
            root.Left = root.Right = null;
            root = left;
            return root;

        }

        public void FixInorderSuccessor()
        {
            if (Root == null) return;
            if (Root.Left == null && Root.Right == null) return;
            Node inorder = null;
            FixInorderSuccessorHelper(Root, ref inorder);
            PrintBSTInorderModified(Root);
        }

        public IList<IList<int>> ZigZag(Node root)
        {
            IList<IList<int>> res = new List<IList<int>>();
            PrintZigZag(root, res);
            return res;
        }

        public void PrintZigZag(Node root, IList<IList<int>> results)
        {
            if (root == null) return;

            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(root);
            int level = 0;
            while (queue.Count > 0)
            {
                int size = queue.Count;
                IList<int> res = new List<int>();
                for (int i = 0; i < size; i++)
                {
                    Node n = queue.Dequeue();
                    if(level%2==0)
                    {
                        res.Add(n.Key);
                    }
                    else
                    {
                        res.Insert(0, n.Key);
                    }
                   

                    if (n.Left != null)
                    {
                        queue.Enqueue(n.Left);
                    }

                    if (n.Right != null)
                    {
                        queue.Enqueue(n.Right);
                    }


                }
                level++;

                results.Add(res);
            }

        }

        public void PrintLevelOrderWithNewLine()
        {
            if (Root == null) return;
            if(Root.Left == null && Root.Right == null)
            {
                Console.WriteLine(Root.Key + "  ");
                return ;
            }
            Node p = Root;
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(p);
            queue.Enqueue(null);

            while(queue.Count>0)
            {
                Node n = queue.Dequeue();

                if(n == null)
                {
                    //End of level
                    Console.WriteLine();

                    if(queue.Count>0)
                    {
                        queue.Enqueue(null);
                    }
                }

                else
                {
                    Console.Write(n.Key + "  ");
                    if (n.Left != null) queue.Enqueue(n.Left);
                    if (n.Right != null) queue.Enqueue(n.Right);
                }
            }

        }
        public void ConnectNodesAtlevel()
        {
            if (Root == null) return;
            if (Root.Left == null && Root.Right == null)
            {
                Console.WriteLine(Root.Key + "  ");
                return;
            }
            Node p = Root;
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(p);
            queue.Enqueue(null);

            Node temp = null;
            while (queue.Count > 0)
            {
                Node n = queue.Dequeue();
                
                if (n == null)
                {
                    //End of level
                    Console.WriteLine();

                    temp = null;
                    if (queue.Count > 0)
                    {
                        queue.Enqueue(null);
                    }
                }

                else
                {
                    //Console.Write(n.Key + "  ");
                    if(temp == null)
                    {
                        temp = n;
                    }
                    else
                    {
                        temp.Next = n;
                        temp = n;
                    }
                    if (n.Left != null) queue.Enqueue(n.Left);
                    if (n.Right != null) queue.Enqueue(n.Right);
                }
            }

        }

        
        public void ConvertBinaryTreeToDLL()
        {
            if (Root == null) return;


            if (Root.Left == null && Root.Right == null) return;
            Node inoderSuccesor = null;
            BinaryTreeToDLLHelper(Root, ref inoderSuccesor);

            if(Root!=null)
            {
                Node p = Root;
                while(p.Left!=null)
                {
                    p = p.Left;
                }
                while(p!=null)
                {
                    Console.WriteLine(p.Key);
                    p = p.Right;
                }
            }

        }

        private void BinaryTreeToDLLHelper(Node root, ref Node inorderSuccesor)
        {
            if(root!=null)
            {
                BinaryTreeToDLLHelper(root.Left, ref inorderSuccesor);
                if(inorderSuccesor != null)
                {
                    inorderSuccesor.Right = root;
                    root.Left = inorderSuccesor;
                }
                inorderSuccesor = root;
                BinaryTreeToDLLHelper(root.Right, ref inorderSuccesor);
                
            }
        }

        private void FixInorderSuccessorHelper(Node root, ref Node inroderSuccessor)
        {
            if(root!=null)
            {
                FixInorderSuccessorHelper(root.Left, ref inroderSuccessor);
                if(inroderSuccessor != null)
                {
                    inroderSuccessor.Inorder = root;
                }
                inroderSuccessor = root;
                FixInorderSuccessorHelper(root.Right, ref inroderSuccessor);
            }
        }
        private Node MirrorHelper(Node root)
        {
            if (root != null)
            {
                MirrorHelper(root.Left);
                MirrorHelper(root.Right);
                Node temp = root.Left;
                root.Left = root.Right;
                root.Right = temp;
            }
            return root;
        }

        private void InsertIterative(int val)
        {
            Node temp = new Node(val);
            if (Root == null)
            {
                Root = temp;
            }
            else
            {
                Node current = Root;
                Node previous = null;
                while (current != null)
                {
                    if (val <= current.Key)
                    {
                        previous = current;
                        current = current.Left;
                    }
                    else
                    {
                        previous = current;
                        current = current.Right;
                    }
                }
                if (previous != null)
                {
                    if (temp.Key <= previous.Key)
                    {
                        previous.Left = temp;
                    }
                    else
                    {
                        previous.Right = temp;
                    }
                }
            }
        }

        /// Other option is using ref. However cannot pass ref for proprties in C# 
        private Node InsertRecursive(Node root, int val)
        {
            if (root == null)
            {
                root = new Node(val);
                return root;
            }
            else
            {
                if (val <= root.Key)
                {
                    root.Left = InsertRecursive(root.Left, val);
                }
                else
                {
                    root.Right = InsertRecursive(root.Right, val);
                }
                return root;
            }
        }
        private void PrintBSTInorder(Node root)
        {
            if (root != null)
            {
                PrintBSTInorder(root.Left);
                Console.WriteLine(root.Key);                               
                PrintBSTInorder(root.Right);
            }
        }

        private void PrintBSTInorderModified(Node root)
        {
            if (root != null)
            {
                PrintBSTInorderModified(root.Left);
                Console.WriteLine(root.Key);
                if (root.Inorder != null)
                {
                    Console.WriteLine("Inorder successor : " + root.Inorder.Key);
                }
                PrintBSTInorderModified(root.Right);
            }
        }

        public string serialize(Node root)
        {
            StringBuilder sb = new StringBuilder();
            SerializeHelper(root, sb);
            string s = sb.ToString();
            return s;
        }

        public Node Search(Node root, int val)
        {
            if (root == null) return null;
            if (root.Key == val) return root;
            else if(root.Key<val)
            {
                return Search(root.Right, val);
            }
            else
            {
                return Search(root.Left, val);
            }
        }
        public Node LowestCommonAncestor(Node root, Node p, Node q)
        {
            if (root == null) return null;
            if (p == null && q == null) return null;
            if (p == null) return q;
            if (q == null) return p;

            if (p.Key > q.Key)
            {
                Node temp = p;
                p = q;
                q = temp;

            }

            while (root != null)
            {
                if (root == p || root == q) return root;
                if (p.Key <= root.Key && root.Key <= q.Key) return root;
                if (root.Key == p.Key || root.Key == q.Key) return root;
                if (root.Key < p.Key)
                {
                    root = root.Left;
                }
                else
                {
                    root = root.Right;
                }

            }
            return null;

        }

        private void SerializeHelper(Node root, StringBuilder sb)
        {
            if (root == null)
            {
                sb.Append("~");
                sb.Append(' ');
                return;
            }

            
            SerializeHelper(root.Right, sb);
            SerializeHelper(root.Left, sb);
            sb.Append(root.Key);
            sb.Append(' ');
            
        }

        // Decodes your encoded data to tree.
        public Node deserialize(string data)
        {
            if (string.IsNullOrEmpty(data))
            {
                return null;
            }

            string[] tokens = data.Trim().Split(' ');
            int index = tokens.Length - 1;
            return DeserializeHelper(tokens, ref index);
        }

        private Node DeserializeHelper(string[] tokens, ref int i)
        {
            if (i <0)
            {
                return null;
            }
            if (tokens[i] == "~")
            {
                return null;
            }

            Node n = new Node(Int32.Parse(tokens[i]));
            i--;
            n.Left = DeserializeHelper(tokens, ref i);
            i--;
            n.Right = DeserializeHelper(tokens, ref i);
            return n;

        }

        public bool IsValidSerialization(string preorder)
        {

            if (String.IsNullOrEmpty(preorder)) return true;

            if (preorder[0] == '#')
            {
                if (preorder.Length == 1) return true;
                else return false;
            }
            else
            {
                string[] tokens = preorder.Split(',');
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < tokens.Length; i++)
                {
                    sb.Append(tokens[i]);

                }

                string correctString = sb.ToString();
                int index = 0;
                int refIndex = 0;
                return IsValid(correctString, index, ref refIndex, correctString.Length);
            }
        }

        private bool IsValid(string preorder, int index, ref int refIndex, int len)
        {
            if (refIndex >= len) return false;

            if (preorder[refIndex] == '#') return true;


            refIndex = refIndex+1;
            bool left = IsValid(preorder, index + 1, ref refIndex, len);

            if (!left) return false;

           // if (refIndex == len - 1) return false;

            refIndex = refIndex + 1;
            bool right = IsValid(preorder, index + 1, ref refIndex, len);

            if (!right) return false;

            if(index ==0)
            {
                if (refIndex == len - 1) return true;
                else return false;
            }

            if (refIndex < len - 1)
            {
                refIndex = refIndex + 1;
                bool x = IsValid(preorder, index + 2, ref refIndex, len);
                return x;
            }
            return true;
           

        }

        public IList<int> InorderTraversal(Node root)
        {
            IList<int> result = new List<int>();
            if (root == null)
            {
                return result;
            }
            if (root.Left == null && root.Right == null)
            {
                result.Add(root.Key);
                return result;
            }

            Stack<Node> stack = new Stack<Node>();

            InorderHelper(root, stack, result);
            return result;

        }

        private void InorderHelper(Node root, Stack<Node> stack, IList<int> result)
        {
            
            while (root != null)
            {
                while (root != null && root.Left != null)
                {
                    stack.Push(root);
                    root = root.Left;
                }
                result.Add(root.Key);
                if(root.Right!=null)
                {
                    root = root.Right;
                }
                else
                {
                    while (stack.Count > 0)
                    {
                        root = stack.Pop();
                        result.Add(root.Key);
                        if(root.Right!=null)
                        {
                            break;
                        }
                    }
                    if(root.Right!=null)
                    {
                        root = root.Right;
                    }
                    else
                    {
                        if (stack.Count == 0) break;
                    }
                    
                }

                
            }
        }

        public void Flatten(Node root)
        {
            Node result = null;
            Flatten(root, ref result);
        }

        private void Flatten(Node root, ref Node result)
        {
            if (root == null) return;
            Node temp = root.Right;
            Flatten(root.Left, ref result);
            if(result==null)
            {
                result = root;
                return;
            }
            //result = root;
            root.Right = result;
            result.Right = temp;
            Flatten(temp, ref result);
            //return root;
        }

        public IList<IList<int>> PathSum(Node root, int sum)
        {
            IList<IList<int>> results = new List<IList<int>>();

            if (root == null) return results;

            IList<int> subResult = new List<int>();
            int index = 0;
            Helper(root, results, index, subResult, sum);
            return results;

        }

        private void Helper(Node root, IList<IList<int>> results, int index, IList<int> subResult, int sum)
        {
            if (root == null)
            {
                return;
            }

            if(root.Left == null && root.Right  == null)
            {
                if(sum==root.Key)
                {
                    subResult.Add(root.Key);
                    results.Add(subResult);
                    subResult.RemoveAt(subResult.Count - 1);
                }
                
                return;
            }


            subResult.Add(root.Key);
            //index++;
            Helper(root.Left, results, index + 1, subResult, sum - root.Key);
            Helper(root.Right, results, index + 1, subResult, sum - root.Key);
            subResult.RemoveAt(subResult.Count - 1);           

        }
    }

    
}
