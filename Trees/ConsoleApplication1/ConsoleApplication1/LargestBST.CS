using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
       /**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
    public class LargestBST
    {
        internal int LargestBSTSubtree(Node root)
        {


            if (root == null) return 0;
            if (root.Left == null && root.Right == null) return 1;
            int count = 0;
            Largest(root, ref count);
            return count;
        }

        private bool Largest(Node root, ref int count)
        {
            if (root == null)
            {
                return true;
            }

            if (root.Left == null && root.Right == null)
            {
                count = count + 1;
                return true;
            }

            int lc = 0, rc = 0;
            bool left = Largest(root.Left, ref lc);
            bool right = Largest(root.Right, ref rc);

            if (left && right)
            {
                count = lc + rc;
                if (root.Left != null && root.Right != null && root.Key >= root.Left.Key && root.Key <= root.Right.Key)
                {
                    count = count + 1;
                }
                return true;
            }

            else if (left)
            {
                count = lc;
                return true;
            }
            else if (right)
            {
                count = rc;
                return true;
            }
            return false;
        }
    }
}
