using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class RankNode
    {
        public int Key;
        public int LeftSize;
        public RankNode left, right;

        public RankNode(int d)
        {
            Key = d;
            LeftSize = 0;
            left = null;
            right = null;
        }

        public void Insert(int val)
        {
            if(val<=Key)
            {
                if(left==null)
                {
                    left = new RankNode(val);
                }
                else
                {
                    left.Insert(val);
                }

                //Increment the count after each insert
                LeftSize++;
            }
            else
            {
                if(right==null)
                {
                    right = new RankNode(val);
                }
                else
                {
                    right.Insert(val);
                }
            }
        }

        // Number of elements less than or equal to x(not including the value x itself)
        public int GetRankNumber(int x)
        {
            if(x==Key)
            {
                return LeftSize;
            }
            else if(x<Key)
            {
                if (left == null) return -1;
                return left.GetRankNumber(x);

            }
            else
            {
                if(right==null)
                {
                    return -1;
                }
                else
                {
                    //Include everything under left subtree while going right
                    return LeftSize + 1 + right.GetRankNumber(x);
                }
            }
        }
    }


    public class OrderTracker
    {
        private RankNode Root;

        public OrderTracker()
        {
            Root = null;
        }

        public void Track(int x)
        {
            if(Root==null)
            {
                Root = new RankNode(x);
            }
            else
            {
                Root.Insert(x);
            }
        }

        public int GetRankNumber(int x)
        {
            if (Root == null) return -1;
            return Root.GetRankNumber(x);
        }

        public void Inorder()
        {
            Inorder(Root);
        }
        private void Inorder(RankNode root)
        {
            if(root!=null)
            {
                Inorder(root.left);
                Console.WriteLine(root.Key);
                Inorder(root.right);
            }
        }

    }

}
