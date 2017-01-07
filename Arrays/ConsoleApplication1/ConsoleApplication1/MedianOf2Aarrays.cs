using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class MedianOf2Arrays
    {
        public int GetMedian(int[] a, int[] b)
        {
            //int len = a.Length;

            return MedianHelper(a, b, 0, a.Length - 1, 0, b.Length - 1);
        }

        private int MedianHelper(int[] a, int[] b, int l1, int r1, int l2, int r2)
        {
            if (l1 > r1) return 0;
            if (l1 == r1)
            {
                return (a[l1] + b[l2]) / 2;
            }

            if (r1 - l1 == 1)
            {
                return (Math.Max(a[l1], b[l2]) + Math.Min(a[r1], b[r2])) / 2;
            }

            int m1 = Median(a, l1, r1);
            int m2 = Median(b, l2, r2);

            int size = (r1 - l1 + 1);
            if (m1 == m2) return m1;
            if (m1 < m2)
            {
                if (size % 2 == 0)
                {
                    return MedianHelper(a, b, size / 2 - 1, r1, l2, size / 2 - 1);
                }
                else
                {
                    return MedianHelper(a, b, size / 2, r1, l2, size / 2);
                }
            }
            else
            {
                if (size % 2 == 0)
                {
                    return MedianHelper(a, b, l1, size / 2 - 1, size / 2 - 1, r2);
                }
                else
                {
                    return MedianHelper(a, b, l1, size / 2-2, size / 2, r2);
                }
            }

        }

        private int Median(int[] a, int l, int r)
        {

            int size = r - l + 1;
            //int mid = l + (r - l) / 2;
            if (size % 2 == 0)
            {
                return (a[size/2 - 1] + a[size/2]) / 2;
            }
            else
            {
                return a[size/2 - 1];
            }
        }
    }
}
