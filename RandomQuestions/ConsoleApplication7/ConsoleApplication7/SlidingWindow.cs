using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication7
{
   
    public class SlidingWindow
    {
        public int[] MaxSlidingWindow(int[] nums, int k)
        {
            if (nums == null || nums.Length == 0)
            {
                return new int[0];
            }
            IList<int> list = new List<int>();
            int[] result = new int[nums.Length - k + 1];
            int write = 0;
            //IList<int> results = new List<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (list.Count > 0 && i - list[0] == k)
                {
                    list.RemoveAt(0);
                }

                while (list.Count > 0 && list[list.Count - 1] < nums[i])
                {
                    list.RemoveAt(list.Count - 1);
                }

                list.Add(i);
                if(i+1>=k)
                {
                    result[i+1-k] = nums[list[0]];
                }
                

            }

            return result;

        }
    }
}
