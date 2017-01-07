using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class Combinations
    {
        public IList<IList<int>> PrintAllCombinations(int[] a)
        {
            IList<IList<int>> res = new List<IList<int>>();

            res.Add(new List<int>());
            if (a == null || a.Length == 0) return res;
            if(a.Length==1)
            {
                res.Add(new List<int>() { a[0] });
                return res;
            }

            IList<int> sub = new List<int>();
            PrintCombinationsHelper(a, 0, sub, res);
            return res;
        }

        private void PrintCombinationsHelper(int[] a, int index, IList<int> sub, IList<IList<int>> res)
        {
            
            for(int i = index;i<a.Length;i++)
            {
                sub.Add(a[i]);
                res.Add(new List<int>(sub));

                if(i<a.Length-1)
                {
                    PrintCombinationsHelper(a, i + 1, sub, res);
                }

                // Remove the last element at the end of iteration
                sub.RemoveAt(sub.Count - 1);
            }
        }


        public IList<IList<int>> PrintAllCombinationsDuplicates(int[] a)
        {
            IList<IList<int>> res = new List<IList<int>>();

            res.Add(new List<int>());
            if (a == null || a.Length == 0) return res;
            if (a.Length == 1)
            {
                res.Add(new List<int>() { a[0] });
                return res;
            }

            Array.Sort(a);
            IList<int> sub = new List<int>();
            PrintCombinationsDuplicatesHelper(a, 0, sub, res);
            return res;
        }

        private void PrintCombinationsDuplicatesHelper(int[] a, int index, IList<int> sub, IList<IList<int>> res)
        {

            for (int i = index; i < a.Length; i++)
            {
                // This can only happen at a given level between 2 successive iterations(cant compare between 2 different levels)
                if(i>index && a[i]==a[i-1])
                {
                    continue;
                }
                sub.Add(a[i]);
                res.Add(new List<int>(sub));

                if (i < a.Length - 1)
                {
                    PrintCombinationsDuplicatesHelper(a, i + 1, sub, res);
                }

                // Remove the last element at the end of iteration
                sub.RemoveAt(sub.Count - 1);
            }
        }
    }
}
