using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
   
    public class JumpGame
    {
        public int Jump(int[] nums)
        {
            if (nums == null || nums.Length == 0) return Int32.MinValue;
            if (nums.Length == 1) return 0;

            int[] table = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                table[i] = Int32.MaxValue;
            }
            table[0] = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                int min_val;
                if (i == 0)
                {
                    min_val = 0;
                }
                else
                {
                    min_val = Math.Min(table[i], table[i - 1] + 1);
                }

                table[i] = min_val;
                int offset = i + nums[i];
                if (offset > nums.Length - 1)
                {
                    offset = nums.Length - 1;
                }
                table[offset] = Math.Min(table[offset], 1 + table[i]);
            }

            return table[nums.Length - 1];

        }
    }
}
