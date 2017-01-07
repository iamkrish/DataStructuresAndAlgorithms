using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class QuickSort
    {
        public void Sort(int[] a, int l , int h)
        {
            if(l<h)
            {
                int rp = Helper.RandomPartition(a, l, h);
                Sort(a, l, rp - 1);
                Sort(a, rp + 1, h);
            }
        }

        
    }
}
