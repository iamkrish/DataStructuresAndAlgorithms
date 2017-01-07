using System;
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
           
            SubSort s = new SubSort();
            int[] a = new int[] { 1, 2, 4, 7, 10, 11, 7, 3,25, 12, 6, 15, 16, 18, 19, 22, 23 };
            //s.Sort(a);

            //KthOrder k = new KthOrder();

            //int[] b = new int[] { 3, 2, 1, 5, 6, 4 };
            //var i =  k.FindKthLargest(b, 3);
            //i = k.FindKthLargest(b, 2);
            //i = k.FindKthLargest(b, 4);

            MaxInSequence ms = new MaxInSequence();
            int[] c = new int[] { -8,3,-2,4,-10,20,-8,-5 };
            int sum = ms.MaxSumSubArray(c);
            Console.ReadLine();
        }
    }
}
