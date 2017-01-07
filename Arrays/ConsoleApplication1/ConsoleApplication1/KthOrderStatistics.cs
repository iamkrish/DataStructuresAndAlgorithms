using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class KthOrderStatistics
    {
        public int KthSmallestIn2Arrays(int[] a, int[] b, int k)
        {
            //k==1 => elemen at index 0

            return KthSmallest2ArraysHelper(a, b, 0, a.Length - 1, 0, b.Length - 1, k-1);
        }

        private int KthSmallest2ArraysHelper(int[] a, int[] b, int l1, int r1, int l2, int r2, int k)
        {
            if (l1 > r1)
            {
                // array a has zero elements
                return b[l2+k-1];
            }
            else if (l2 > r2)
            {
                return a[l1+k-1];
            }
            else
            {
                int mid1 = l1 + (r1 - l1) / 2;
                int mid2 = l2 + (r2 - l2) / 2;

                if (mid1 + mid2 < k)
                {
                    // Eleminate half of the array whose mid value is smaller

                    if (a[mid1] >b[mid2])
                    {
                        return KthSmallest2ArraysHelper(a, b, l1, r1, mid2 + 1, r2, k - mid2 - 1);
                        

                    }
                    else
                    {
                        return KthSmallest2ArraysHelper(a, b, mid1 + 1, r1, l2, r2, k - mid1 - 1);
                    }
                }
                else
                {

                    //Eliminate that half of array whose value is bigger
                    if (a[mid1] > b[mid2])
                    {
                        return KthSmallest2ArraysHelper(a, b, l1, mid1 - 1, l2, r2, k);
                    }
                    else
                    {
                        return KthSmallest2ArraysHelper(a, b, l1, r1, l2, mid2 - 1, k);
                    }

                }

            }



        }
    }
}
