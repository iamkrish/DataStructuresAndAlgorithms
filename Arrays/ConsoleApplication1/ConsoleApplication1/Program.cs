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
            Solution sl = new Solution();
            int x =sl.FindCelebrity(2);

            RandomClass rand = new RandomClass();
            
            int[] a = new int[] { 3, 37, 21, 99, 107 };
            rand.Shuffle(a);
            rand.GenerateRandomSetOfMelements(a, 3);

            MedianOf2Arrays m2a = new MedianOf2Arrays();
            int[] x1 = new int[] { 1, 12, 15, 26, 38, 46 };
            int[] x2 = new int[] { 2, 13, 17, 30, 45, 60 };
            int m2ares=m2a.GetMedian(x1, x2);

            KthOrderStatistics kos = new KthOrderStatistics();
            int[] one = new int[] { 1, 4, 6, 7, 10 };
            int[] two = new int[] { 3, 5, 8 };
            int kthsmallest = kos.KthSmallestIn2Arrays(one, two, 7);


            char[] A = new char[] { 'C', 'D', 'E', 'F', 'G' };
            int[] B = new int[] { 4, 3, 1, 0, 2 };


            SortOneBasedOnAnother sba = new SortOneBasedOnAnother();
            //sba.Sort(A, B);

            int[] c = new int[] { 2, 1, 2, 5, 7, 1, 9, 3, 6, 8, 8 };
            int[] d = new int[] { 2, 1, 8, 3 };

            sba.Sort2(c, d);
            Print(c);

            Console.ReadLine();
        }

        static void Print(int[] A)
        {
            for (int i = 0; i < A.Length; i++)
            {
                Console.WriteLine(A[i]);
            }
        }
    }
}
