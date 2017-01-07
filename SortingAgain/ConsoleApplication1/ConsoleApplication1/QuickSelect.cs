using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class QuickSelect
    {
        public int KthLargest(int[] a, int l, int h, int k)
        {
            return KthLargestHelper(a, l, h, a.Length - k - 1);
        }

        private int KthLargestHelper(int[] a, int l, int h , int k)
        {
            while(l<=h)
            {
                int rp = Helper.RandomPartition(a, l, h);
                if (rp == k) return rp;
                if(rp>k)
                {
                    return KthLargestHelper(a, l, rp, k);
                }
                else
                {
                    return KthLargestHelper(a, rp + 1, h, k);
                }
            }
            return -1;
        }

        public int KthSmallest(int[] a, int l, int h, int k)
        {
            return KthSmallestHelper(a, l, h, k-1);
        }

        private int KthSmallestHelper(int[] a, int l, int h, int k)
        {
            if (l <= h)
            {
                int rp = Helper.RandomPartition(a, l, h);
                if (rp == k) return rp;
                if(rp>k)
                {
                    // Search left
                    return KthSmallestHelper(a, l, rp-1, k);
                }
                else
                {
                    return KthSmallestHelper(a, rp + 1, h, k - rp);
                }
            }
            return -1;
        }


    }
}
