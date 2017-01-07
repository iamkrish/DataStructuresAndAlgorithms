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
            int[] a = { 3, 1, 5, 2, 6, 4, 9, 10, 7 };

            // int len = LongestIncreasingSubSequence(a);
            // Console.WriteLine(len);

            //LCS lcs = new LCS();

            //string s1 = "ABCDFCDF";
            //string s2 = "ABECDFCBCDFCDF";
            ////int lcs_length = lcs.LCSRecursive(s1.ToCharArray(), s2.ToCharArray(), 0, 0);
            //int lcs_length = lcs.LCDDynamicPrograming(s1.ToCharArray(), s2.ToCharArray());
            // Console.WriteLine(lcs_length);


            //CoinChange c = new CoinChange();

            //int[] coins = { 1,2,3 };
            //int required_sum = 4;

            //int ways = c.DPMemoGetCoins(coins, required_sum);
            //Console.WriteLine(ways);

            int[] inp = new int[] { 3, 1, 5, 2, 6, 4, 9, 10, 7, 8 };
            var b = LIS(inp);
            Console.ReadLine();
        }

        static int LongestIncreasingSubSequence(int[] input)
        {
            if (input == null || input.Length == 0) return 0;
            if (input.Length == 1) return 1;

            int[] increasingSubsequence = new int[input.Length + 1];
            int[] parent = new int[input.Length];
            for (int k = 0; k < parent.Length; k++)
            {
                parent[k] = Int32.MinValue;
            }

            int len = 1;
            increasingSubsequence[0] = input[0];
            int i = 1;

            while (i < input.Length)
            {
                if (input[i] > increasingSubsequence[len - 1])
                {
                    increasingSubsequence[len] = input[i];
                    parent[i] = increasingSubsequence[len - 1];
                    len++;
                }
                else
                {
                    int index = CelingIndex(input, 0, len - 1, input[i]);
                    increasingSubsequence[index] = input[i];
                    if (index > 0)
                    {
                        parent[i] = increasingSubsequence[index - 1];
                    }
                }
                i++;
            }

            int end = input.Length - 1;
            while (end > 0)
            {
                Console.WriteLine(input[end]);

                int parentValue = parent[end];
                end = parentValue;
            }

            return len;
        }

        static int CelingIndex(int[] a, int start, int end, int Key)
        {
            while (end - start > 1)
            {
                int mid = start + (end - start) / 2;
                if (a[mid] <= Key)
                {
                    start = mid;
                }
                else
                {
                    end = mid;
                }
            }
            return end;
        }

        static int LIS(int[] input)
        {
            int[] lis = new int[input.Length];
            int[] parent = new int[input.Length];
            for(int i =0; i< parent.Length;i++)
            {
                parent[i] = Int32.MinValue;
            }

            int len = 1;
            lis[0] = input[0];
            parent[0] = 0;
            IDictionary<int, IList<int>> mapping = new Dictionary<int, IList<int>>();
            int max_length = len;

            mapping.Add(1, new List<int>() { 0 });
            for (int i = 1; i < input.Length; i++)
            {
                if (input[i] > lis[len - 1])
                {
                    parent[i] = i - 1;
                    lis[len] = input[i];
                    len++;

                }
                else
                {
                    int replace_index = CelingIndex(lis, 0, len - 1, input[i]);
                    lis[replace_index] = input[i];

                    if(parent[replace_index]>=0)
                    {
                        parent[i] = parent[replace_index];
                       // parent[replace_index] = Int32.MinValue;
                    }
                    
                }
                if (len >= max_length)
                {
                    max_length = len;
                    if (mapping.ContainsKey(max_length))
                    {
                        mapping[len].Add(i);
                    }
                    else
                    {
                        mapping.Add(max_length, new List<int>() { i });
                    }
                }

            }

            Console.WriteLine("Max length is " + max_length);

            foreach (int index in mapping[max_length])
            {
                int start = index;

                while (start > 0)
                {
                    Console.WriteLine(input[start]);
                    start = parent[start];
                   
                }

                Console.WriteLine("Next sequence..........");
            }
            return max_length;
        }
    }
}
