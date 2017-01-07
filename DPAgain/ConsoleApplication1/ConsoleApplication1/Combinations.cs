using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class Combinations
    {
        //With Same number being used more than once in the combo
        public IList<IList<int>> UniqueCombinationsSum(int[] a, int sum)
        {
            IList<IList<int>> res = new List<IList<int>>();
            if (a == null || a.Length == 0) return res;
            //if (a.Length == 1)
            //{
            //    if (sum == a[0])
            //    {
            //        res.Add(new List<int>() { a[0] });

            //    }
            //    return res;
            //}
            Array.Sort(a);
            IList<int> subList = new List<int>();

            UniqueCombinationsSumHelper(a, sum, 0, subList, res);
            return res;
        }

        private void UniqueCombinationsSumHelper(int[] a, int sum, int index, IList<int> list, IList<IList<int>> res)
        {
            if (sum == 0)
            {
                IList<int> newlist = new List<int>(list);
                res.Add(newlist);
                return;
            }

            for (int i = index; i < a.Length; i++)
            {
                if (sum < a[i])
                {
                    return;
                }
                if (list.Count > 0 && a[i] < list[list.Count - 1])
                {
                    continue;
                }
                list.Add(a[i]);
                UniqueCombinationsSumHelper(a, sum - a[i], index, list, res);
                list.RemoveAt(list.Count - 1);
            }
        }

        public IList<IList<int>> UniqueCombinationsSumNoRepeat(int[] a, int sum)
        {
            IList<IList<int>> res = new List<IList<int>>();
            if (a == null || a.Length == 0) return res;
            if (a.Length == 1)
            {
                if (sum == a[0])
                {
                    res.Add(new List<int>() { a[0] });

                }
                return res;
            }
            Array.Sort(a);

            IList<int> subList = new List<int>();
            IDictionary<int, bool> history = new Dictionary<int, bool>();

            UniqueCombinationsSumNoRepeatHelper(a, sum, 0, subList, res);
               

            return res;
        }

        private void UniqueCombinationsSumNoRepeatHelper(int[] a, int sum, int index, IList<int> list, IList<IList<int>> res)
        {
           
            if (sum == 0)
            {
                // Note: Cannot just add the existing list as further changes will overwrite the result
                IList<int> newlist = new List<int>(list);
                res.Add(newlist);
                return;
            }



            for (int i = index; i < a.Length; i++)
            {
                if (sum < a[i])
                {
                    return;
                }

                if(i>index && a[i] == a[i-1])
                {
                    //do not break.. we could have other combinations that inludes this index and beyond
                    continue;
                }
                list.Add(a[i]);
                UniqueCombinationsSumNoRepeatHelper(a, sum - a[i], i + 1, list, res);
                list.RemoveAt(list.Count - 1);
            }
        }

        public IList<IList<int>> UniqueCombinationsKNumbersSumToN(int k, int n)
        {
            IList<IList<int>> res = new List<IList<int>>();
            if (n == 0 || k == 0) return res;
            if (k > n) return res;

            int[] a = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            IList<int> subList = new List<int>();

            UniqueCombinationsKNumbersSumToNHelper(a, n, k, 0, subList, res);



            return res;
        }

        private void UniqueCombinationsKNumbersSumToNHelper(int[] a, int sum, int k, int index, IList<int> list, IList<IList<int>> res)
        {
            if (sum == 0)
            {
                // Note: Cannot just add the existing list as further changes will overwrite the result

                if (list.Count == k)
                {
                    IList<int> newlist = new List<int>(list);
                    res.Add(newlist);
                }

                return;
            }

            for (int i = index; i < a.Length; i++)
            {

                if (list.Count == k || sum < a[i])
                {
                    return;
                }

                list.Add(a[i]);
                UniqueCombinationsKNumbersSumToNHelper(a, sum - a[i], k, i + 1, list, res);
                list.RemoveAt(list.Count - 1);
            }

        } 

        public IList<IList<int>> CombinationsNK(int k, int n)
        {
            IList<IList<int>> res = new List<IList<int>>();
            if (k > n || n < 1) return null;


            IList<int> subList = new List<int>();

            CombinationsNKHelper(k, 1, n, subList, res);

            return res;
        }

        private void CombinationsNKHelper(int k, int index, int n, IList<int> list, IList<IList<int>> res)
        {
            if (list.Count == k)
            {
                // Note: Cannot just add the existing list as further changes will overwrite the result
                IList<int> newlist = new List<int>(list);
                res.Add(newlist);
                return;
            }

            for (int i = index; i <= n; i++)
            {

                list.Add(i);
                CombinationsNKHelper(k, i + 1, n, list, res);
                list.RemoveAt(list.Count - 1);
            }

        }

        public IList<IList<int>> Subsets(int[] nums)
        {
            IList<IList<int>> res = new List<IList<int>>();
            res.Add(new List<int>());

            if (nums == null || nums.Length == 0) return res;
            if (nums.Length == 1)
            {
                res.Add(new List<int>(nums[0]));
                return res;
            }

            IList<int> subRes = new List<int>();
            Helper(nums, 0, subRes, res);
            return res;
        }

        private void Helper(int[] nums, int index, IList<int> subRes, IList<IList<int>> res)
        {
            //if(index==nums.Length) return;


            for (int i = index; i < nums.Length; i++)
            {
                subRes.Add(nums[i]);

                var temp = new List<int>(subRes);
                res.Add(temp);
                if (i < nums.Length-1)
                {
                    Helper(nums, i+ 1, subRes, res);
                }

                subRes.RemoveAt(subRes.Count-1);
            }
        }
    }
}
