using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class ArrayInformationOfBST
    {
        public List<List<int>> ArrayTreeSequence(Node n)
        {
            if(n==null)
            {
                return new List<List<int>>();
            }

            List<List<int>> left = ArrayTreeSequence(n.Left);
            List<List<int>> right = ArrayTreeSequence(n.Right);

            List<int> rootList = new List<int>() { n.Key };
            
            List<List<int>> result = new List<List<int>>();
            result.Add(rootList);
            foreach(var leftList in left)
            {
                foreach(var rightList in right)
                {
                    List<List<int>> combinations = StichLists(leftList, rightList, rootList);
                    result.AddRange(combinations);
                }
            }

            return result;
        }

        private List<List<int>> StichLists(List<int> left, List<int> right, List<int> rootList)
        {
            List<List<int>> stichedResults = new List<List<int>>();            

           

            List<int> combo1 = new List<int>();
            combo1.AddRange(rootList);
            combo1.AddRange(left);
            combo1.AddRange(right);

            List<int> combo2 = new List<int>();
            combo2.AddRange(rootList);            
            combo1.AddRange(right);
            combo1.AddRange(left);

            stichedResults.Add(combo1);
            stichedResults.Add(combo2);

            return stichedResults;
        }

    }
}
