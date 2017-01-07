using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class KthOrder
    {
        public int FindKthLargest(int[] nums, int k)
        {
            if (nums == null || nums.Length == 0) return Int32.MaxValue;
            if (nums.Length < k) return Int32.MaxValue;
            if (k < 0) return -1;

            //Kth largest = n-k smallest
            k = nums.Length - k;
            return KL(nums, 0, nums.Length - 1, k);
        }

        private int KL(int[] a, int l, int h, int k)
        {
            if (l > h) return -1;
            int pivot = RandomPartition(a, l, h);
            if (pivot == k) return a[pivot];
            if (pivot < k)
            {
                //Go right
                return KL(a, pivot + 1, h, k);
            }
            else
            {
                // Go Left
                return KL(a, l, pivot - 1, k);
            }
        }

      

        private int RandomPartition(int[] a, int l, int h)
        {

            Random r = new Random();
            int x = r.Next(l, h);

            int i = l;
            int j = l - 1;

            swap(a, h, x);
            while (i < h)
            {
                if (a[i] <= a[h])
                {
                    j++;
                    swap(a, j, i);
                }
                i++;

            }
            swap(a, j + 1, h);
            return j + 1;
        }

        private void swap(int[] a, int i, int j)
        {
            int temp = a[i];
            a[i] = a[j];
            a[j] = temp;
        }
    }
}
