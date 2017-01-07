using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public static class Helper
    {
        public static  int RandomPartition(int[] a, int l, int h)
        {            
            int n = h - l + 1;
            Random r = new Random();
            int random_index = r.Next(n);
            swap(a, random_index, h);
            return Partition(a, l, h);
        }

        public static int Partition(int[] a, int l, int h)
        {
            int i = l;
            int j = l - 1;
            int pivot = a[h];
            while (i < h)
            {
                if (a[i] <= pivot)
                {
                    j++;
                    swap(a, i, j);
                }
                i++;
            }
            swap(a, j + 1, h);
            return j + 1;
        }

        public static void swap(int[] a, int i, int j)
        {
            int temp = a[i];
            a[i] = a[j];
            a[j] = temp;
        }
    }
}
