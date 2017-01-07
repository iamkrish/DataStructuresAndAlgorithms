using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            QuickSort qs = new QuickSort();
            int[] a = new int[] { 7,4,2,6,1,5,3};
           // qs.Sort(a, 0, a.Length - 1);

            QuickSelect select = new QuickSelect();

            int x = select.KthSmallest(a, 0, a.Length-1, 4);

        }
    }
}
