using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Permutations
    {
        // Input has distinct numbers
        public IList<IList<int>> GetPermutations(int[] nums)
        {
            IList<IList<int>> res = new List<IList<int>>();
            if (nums == null || nums.Length == 0) return res;
            if (nums.Length == 1)
            {
                res.Add(new List<int>() { nums[0] });
                return res;
            }

            IList<int> sub = new List<int>();
            GetPermutationsHelper(nums, 0, res);
            return res;

        }

        // Notice that we dont need a seperate list to hold each result.. we get this by swapping
        private void GetPermutationsHelper(int[] nums, int index, IList<IList<int>> res)
        {
            if (index == nums.Length)
            {
                IList<int> l = new List<int>();
                for (int i = 0; i < nums.Length; i++)
                {
                    l.Add(nums[i]);
                }
                res.Add(l);
                return;
            }

            for (int i = index; i < nums.Length; i++)
            {
                if (index != i)
                {
                    swap(nums, i, index);
                }
                GetPermutationsHelper(nums, index + 1, res);
                if (index != i)
                {
                    swap(nums, i, index);
                }
            }
        }



        public IList<string> GetPermutationsUpperAndLower(char[] nums)
        {
            IList<string> res = new List<string>();
            if (nums == null || nums.Length == 0) return res;
            if (nums.Length == 1)
            {
                res.Add(new string(nums));
                return res;
            }

            //IList<int> sub = new List<int>();
            GetPermutationsHelperUpperAndLower(nums, 0, res);
            return res;

        }

        private void GetPermutationsHelperUpperAndLower(char[] nums, int index, IList<string> res)
        {
            if (index == nums.Length)
            {
                res.Add(new string(nums));
                return;
            }

            for (int i = index; i < nums.Length; i++)
            {
                swap(nums, i, index);
                GetPermutationsHelperUpperAndLower(nums, index + 1, res);
                swap(nums, i, index);
                nums[i] = (char)(nums[i] - 32);

                swap(nums, i, index);
                GetPermutationsHelperUpperAndLower(nums, index + 1, res);
                swap(nums, i, index);

                nums[i] = (char)(nums[i] + 32);
            }
        }

        public IList<IList<int>> GetPermutationsDuplicates(int[] nums)
        {
            IList<IList<int>> res = new List<IList<int>>();
            if (nums == null || nums.Length == 0) return res;
            if (nums.Length == 1)
            {
                res.Add(new List<int>() { nums[0] });
                return res;
            }

            //Add keys to dictionary
            IDictionary<int, int> dic = new Dictionary<int, int>();

            foreach (int i in nums)
            {
                if (!dic.ContainsKey(nums[i]))
                {
                    dic.Add(nums[i], 0);
                }
                dic[nums[i]]+=1;
            }

            int[] sub = new int[nums.Length];
            GetPermutationsDuplicatesHelper(res, dic, sub, 0, nums.Length);
            return res;

        }

        private void GetPermutationsDuplicatesHelper(IList<IList<int>> res, IDictionary<int, int> dic, int[] sub, int level, int n)
        {
            if (level == n)
            {
                IList<int> l = new List<int>(sub);
                res.Add(l);
                return;
            }

            IList<int> keys = dic.Keys.ToList();
            foreach (int key in keys)
            {
                if (dic[key] > 0)
                {
                    dic[key]--;
                    sub[level] = key;
                    GetPermutationsDuplicatesHelper(res, dic, sub, level + 1, n);
                    dic[key]++;
                }

            }
        }

        private void swap(int[] a, int i, int j)
        {
            int tmp = a[i];
            a[i] = a[j];
            a[j] = tmp;
        }

        private void swap(char[] a, int i, int j)
        {
            char temp = a[i];
            a[i] = a[j];
            a[j] = temp;
        }

    }
}
