using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class SubSort
    {
        public void Sort(int[] a)
        {
            if (a == null || a.Length < 2) return;

            SortHelper(a, 0, a.Length - 1);
        }

        private void SortHelper(int[] a, int s, int l)
        {
            //Find the position of ist mismatch from begin
            int i = s + 1;
            while (i < l && a[i] <= a[i + 1])
            {
                i++;
            }
            if (i == l) return;
            int large = a[i];

            //  Find the position of 1st mismatch from end
            int j = l;
            while (j > i && a[j] >= a[j - 1])
            {
                j--;
            }

            int small = a[j];

            //Update the min and max values between i+1--> to j-1 <---
            for (int x = i + 1; x <= j - 1; x++)
            {
                if (a[x] < small)
                {
                    small = a[x];
                }
                if (a[x] > large)
                {
                    large = a[x];

                }
            }

                // Expand the left in <-- this direction

                while (i >= 0 && a[i] > small)
                {
                    i--;
                }
                if (i == -1)
                {
                    i = 0;
                }

                //Expand the right in ---> direction
                while (j <= l && a[j] < large)
                {
                    j++;
                }
                if (j == l + 1)
                {
                    j = l;
                }

            int p = i + 1;
            int q = j;
                Array.Sort(a,p,q-p+1);
            }
        }
    
}
