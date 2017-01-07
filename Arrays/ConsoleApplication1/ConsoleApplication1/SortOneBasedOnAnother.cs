using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class SortOneBasedOnAnother
    {


        public void Sort(char[] A, int[] B)
        {
            if (A == null || B == null || A.Length < 2 || B.Length < 2) return;

            int i = 0;
            while(i<A.Length)
            {
                while(B[i]!=i)
                {
                    Swap(A, i, B[i]);
                    Swap(B, i, B[i]);
                }
                i++;
            }

        }

        private void Swap<T>(T[] inp, int i, int j)
        {
            T temp = inp[i];
            inp[i] = inp[j];
            inp[j] = temp;
        }

        public IDictionary<int, int> map = new Dictionary<int, int>();
        public void Sort2(int[] a, int[] b)
        {

            if (a == null || b == null || a.Length < 2 || b.Length < 2) return;
            for(int i =0;i<b.Length;i++)
            {
                map.Add(b[i], i);
            }

            Array.Sort(a, new CustomComparator());

        }

        class CustomComparator : IComparer<int>
        {
            IDictionary<int, int> map = new SortOneBasedOnAnother().map;    
            public int Compare(int a, int b)
            {
                if (map.ContainsKey(a) && map.ContainsKey(b))
                {
                    return map[a] - map[b];
                }
                else if (map.ContainsKey(a)) return -1;
                else if (map.ContainsKey(b)) return 1;
                else return a - b;
             }
        }

    }

   
   
}
