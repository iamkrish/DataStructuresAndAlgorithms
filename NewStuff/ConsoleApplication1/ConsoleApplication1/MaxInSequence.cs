using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class MaxInSequence
    {
        public int MaxSumSubArray(int[] nums)
        {
            if (nums == null || nums.Length == 0) return Int32.MinValue;

            int maxSum = 0;
            var x =  HelperSum(nums, ref maxSum);
            return maxSum;
        }

        private int[] HelperSum(int[] nums, ref int maxSum)
        {
            int[] indexes = new int[2];

            int cs = nums[0], ms = nums[0];
            int s1 = 0, s2 = -1, e1 = 0, e2 = -1;

            for (int i = 1; i < nums.Length; i++)
            {
                if(cs+nums[i]>cs)
                {
                    if(s1==-1)
                    {
                        s1 = i;
                        e1 = i;
                    }
                    else
                    {
                        if(i==e1+1)
                        {
                            e1 = i;
                        }
                        else
                        {
                            if(s2==-1)
                            {
                                s2 = i;
                                e2 = i;
                            }
                            else
                            {
                                e2 = i;
                            }
                        }
                    }
                }

                cs = Math.Max(cs + nums[i], nums[i]);

                if(cs>ms)
                {
                    if(s2!=-1)
                    {
                        s1 = s2;
                        e1 = e2;
                        s2 = -1;
                        e2 = -1;
                        ms = cs;
                    }
                }
               
            }

            indexes[0] = s1;
            indexes[1]=e1;
            maxSum = ms;
            return indexes;
        }
    }
}
