using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {


            //OrderTracker ot = new OrderTracker();
            //ot.Track(20);
            //ot.Track(15);
            //ot.Track(25);
            //ot.Inorder();
            //int x = ot.GetRankNumber(20);

            TernarySearchTrees tst = new TernarySearchTrees();
            tst.Insert("hut");
            tst.Insert("hat");
            tst.Insert("hits");
            tst.Insert("hit");
            tst.Traversal();

            //bool f = tst.Search("hit");

            BinarySearchTrees bst = new BinarySearchTrees();
            bst.Insert(5);
            bst.Insert(3);
            bst.Insert(8);

            ArrayInformationOfBST aob = new ArrayInformationOfBST();
            var all = aob.ArrayTreeSequence(bst.Root);

            bst.Insert(2);
            bst.Insert(8);
            //bst.Insert(1);
            //Node p = bst.Search(bst.Root,1);
            //Node q = bst.Search(bst.Root,4);
            //Node lcaa = bst.LowestCommonAncestor(bst.Root,p, q);

            bst.ZigZag(bst.Root);
            //SingleLinkedList sl = new SingleLinkedList();
            //sl.InsertAtEnd(1);
            //sl.InsertAtEnd(2);
            //sl.InsertAtEnd(3);
            //sl.InsertAtEnd(4);
            //sl.InsertAtEnd(5);

            //sl.Print();
            //var tree = bst.ConvertSLLToBST(sl.Head);
            
            bst.Insert(7);
            bst.Insert(4);
            bst.Insert(11);
            bst.Insert(6);
            //bst.Insert(5);
            //bst.Insert(8);
            bst.Insert(2);
            bst.Insert(1);
            bst.Insert(3);
            bst.Insert(2);

            bst.PathSum(bst.Root, 16);
            // bst.Insert(10, isRecursive: true);



            //bst.Mirror();
            //bst.FixInorderSuccessor();
            // bst.ConvertBinaryTreeToDLL();
            // bst.PrintBSTInorder();
            // bst.UpsideDown();

            // bst.PrintLevelOrderWithNewLine();

            //bst.ConnectNodesAtlevel();
            // string s = bst.serialize(bst.Root);

            // Node n = bst.deserialize(s);

            //string t = @"9,3,4,#,#,1,#,#,2,#,6,#,#";
            // bool d = bst.IsValidSerialization(t);

            bst.Flatten(bst.Root);
            Console.ReadLine();
        }

        /**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
       
    }
}
