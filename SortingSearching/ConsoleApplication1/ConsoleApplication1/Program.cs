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
           // Stock st = new Stock();
            //var pro = st.MaxProfit(new int[] { 6,1,3,2,4,7 });
            
            CountingSort();
            Console.ReadLine();

        }

        static void CountingSort()
        {
            //int[] a = { -3, -4, 0, 1, 3, 2, -3 };
            //int[] a = {4,4,2,2,1,0,3 };
            int[] a = { -8, -3, -1, -8, -2, -2, -2 };
            int[] b = new int[] { 1, 4, 3, 2, 1, 4, 6, 9 };
            int min_value = 1;
            int max_value = 9;
            CountingSort(b, min_value, max_value);
            PrintArray(b);
        }

        static void CountingSort(int[] a, int min_value, int max_value)
        {
            int[] count = new int[max_value - min_value + 1];
            int read;
            for (read = 0; read < a.Length; read++)
            {
                int correct_index = a[read] - min_value;
                count[correct_index] += 1;
            }

            int write = 0;
            read = 0;
            while (read < count.Length && write < a.Length)
            {
                int orginal_value = read + min_value;
                int times = count[read];
                while (times > 0)
                {
                    a[write++] = orginal_value;
                    times--;
                }
                read++;
            }
        }

        static void PrintArray(int[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                Console.WriteLine(a[i]);
            }
        }
    }
}
