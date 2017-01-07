using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication4
{
    class Program
    {
        static void Main(string[] args)
        {
            //Solution s = new Solution();
            //char[,] a = new char[,] { { '0','1','0'},
            //                           { '1','0','1'},
            //                           {'0','1','0'} };
            //int p = s.NumIslands(a);


            Permutations p = new Permutations();
            //var results = p.VaildParenthesis(3);

            //var kperm = p.GetKthPerm(3, 3);

            MatrixStuff ms = new MatrixStuff();
            int[,] a = new int[,] { { 1, 2, 3, 4 } };
            //ms.PrintSpiral(a, 3,3);

            DPStuff d = new DPStuff();
            int[] coins = new int[] { 1, 2, 5 };
            int v = d.coinChange(coins, 11);
            //d.MinDistance("boy", "good");

            //int x = d.NumberOfWaysNSteps(9);
            Console.ReadLine();
        }
    }

    public class Solution
    {
        public int NumIslands(char[,] grid)
        {

            int Rows = grid.GetLength(0);
            int Cols = grid.GetLength(1);
            return DFS(grid, Rows, Cols);
        }

        private bool IsSafe(char[,] input, bool[,] visited, int row, int col, int Rows, int Cols)
        {
            if (row >= 0 && row < Rows && col >= 0 && col < Cols && input[row, col] == '1' && visited[row, col] == false)
            {
                return true;
            }
            else
            {
                return false;

            }
        }

        private void DFSHelper(char[,] input, bool[,] visited, int row, int col, int Rows, int Cols)
        {
            visited[row, col] = true;
            int[] rowPos0 = new int[] { -1, -1, -1, 0, 0, 1, 1, 1 };
            int[] colPos0 = new int[] { -1, 0, 1, -1, 1, -1, 0, 1 };

            int[] rowPos = new int[] { -1, 0, 0, 1 };
            int[] colPos = new int[] { 0, -1, 1, 0 };


            for (int i = 0; i < 4; i++)
            {
                if (IsSafe(input, visited, row + rowPos[i], col + colPos[i], Rows, Cols))
                {
                    DFSHelper(input, visited, row + rowPos[i], col + colPos[i], Rows, Cols);
                }
            }
        }

        private int DFS(char[,] input, int Rows, int Cols)
        {

            bool[,] visited = new bool[Rows, Cols];
            int connected = 0;
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    if (!visited[i, j] && input[i, j] == '1')
                    {
                        DFSHelper(input, visited, i, j, Rows, Cols);
                        connected++;
                    }

                }
            }

            return connected;
        }
    }

    public class Permutations
    {
        public IList<string> VaildParenthesis(int count)
        {
            char[] output = new char[count * 2];
            IList<string> results = new List<string>();
            ValidParenthesisHelper(count, count, 0, output, results);

            return results;
        }

        private void ValidParenthesisHelper(int left_available, int right_available, int recur_len, char[] output, IList<string> results)
        {
            if (left_available < 0 || right_available < left_available)
            {
                // Invalid combo return;
                return;
            }
            else if (right_available == 0 && 0 == left_available)
            {
                results.Add(new string(output));
                return;
            }
            else
            {
                if (left_available > 0)
                {
                    output[recur_len] = '(';
                    ValidParenthesisHelper(left_available - 1, right_available, recur_len + 1, output, results);
                }
                if (right_available > left_available)
                {
                    output[recur_len] = ')';
                    ValidParenthesisHelper(left_available, right_available - 1, recur_len + 1, output, results);
                }
            }

        }

        public IList<string> GetUniquePermutations(char[] a)
        {
            IList<string> results = new List<string>();
            GetUniquePermHelper(a, a.Length, 0, results);
            return results;
        }

        //public IList<string> AvoidDuplicatePerms(char[] a)
        //{
        //    Array.Sort(a);
        //    IList<string> results = new List<string>();
        //    AvoidDuplicatePermHelper(a, a.Length, 0, results);
        //    return results;
        //}

        public IList<string> GetPermutations2(char[] a)
        {
            IDictionary<char, int> d = GetDictionary(a);

            IList<string> results = new List<string>();
            char[] output = new char[a.Length];
            GetPermutations2Helper(a, d, output, a.Length, 0, results);
            return results;
        }

        private void GetPermutations2Helper(char[] a, IDictionary<char, int> d, char[] output, int len, int rec_len, IList<string> results)
        {
            if (rec_len == len)
            {
                results.Add(new string(output));
                return;
            }

            //IList<char> keys = d.Keys;
            foreach (char key in d.Keys.ToList())
            {
                if (d[key] > 0)
                {
                    d[key]--;
                    output[rec_len] = key;
                    GetPermutations2Helper(a, d, output, len, rec_len + 1, results);
                    d[key]++;
                }
            }

        }


        private void GetUniquePermHelper(char[] a, int len, int rec_len, IList<string> results)
        {
            if (rec_len == len - 1)
            {
                results.Add(new string(a));
                return;
            }

            for (int i = rec_len; i <= len - 1; i++)
            {
                swap(a, i, rec_len);
                GetUniquePermHelper(a, len, rec_len + 1, results);
                swap(a, i, rec_len);
            }
        }

        //private void AvoidDuplicatePermHelper(char[] a, int len, int rec_len, IList<string> results)
        //{
        //    if (rec_len == len - 1)
        //    {
        //        results.Add(new string(a));
        //        Console.WriteLine(a);
        //        return;
        //    }

        //    for (int i = rec_len; i < len; i++)
        //    {
        //        if(i!=rec_len && a[i] == a[i-1])
        //        {
        //            continue;
        //        }
        //        swap(a, i, rec_len);
        //        AvoidDuplicatePermHelper(a, len, rec_len + 1, results);
        //        swap(a, i, rec_len);
        //    }
        //}

        private void swap(char[] a, int i, int j)
        {
            char temp = a[i];
            a[i] = a[j];
            a[j] = temp;
        }

        private void MovetoFront(int[] a, int i, int j)
        {
            int temp = a[j];
            int l = j;
            while (l > i)
            {
                a[l] = a[l - 1];
                l--;
            }
            a[l] = temp;
        }

        private IDictionary<char, int> GetDictionary(char[] s)
        {
            IDictionary<char, int> d = new Dictionary<char, int>();

            foreach (char c in s)
            {
                if (d.ContainsKey(c))
                {
                    d[c] += 1;
                }
                else
                {
                    d.Add(c, 1);
                }
            }
            return d;
        }

        public IList<int> GetKthPerm(int n, int k)
        {
            int[] nums = new int[n];
            for (int i = 0; i < n; i++)
            {
                nums[i] = i + 1;
            }
            return Helper(n, k - 1, nums);
        }

        private IList<int> Helper(int n, int k, int[] nums)
        {
            IList<int> result = new List<int>();
            int i = 0;
            int index = k / factorial(n - 1);
            while (i < nums.Length - 1)
            {

                MovetoFront(nums, 0 + i, index + i);
                result.Add(nums[i]);

                k = k - ((index) * (factorial(n - 1)));
                n = n - 1;
                index = k / factorial(n - 1);

                i++;
            }
            result.Add(nums[nums.Length - 1]);
            return result;
        }

        private int factorial(int n)
        {
            if (n < 2) return 1;
            int result = 1;
            int i = 2;
            while (i <= n)
            {
                result = result * i;
                i++;
            }
            return result;
        }
    }

    public class Stocks
    {
        public void MaxProfitDays(int[] nums)
        {
            int[] result = new int[2] { -1, -1 };
        }
        public int MaxProfit(int[] prices, int[] result)
        {
            if (prices == null || prices.Length == 0)
            {
                return 0;
            }

            int min_cost = Int32.MaxValue;
            int max_profit = 0;

            int buy1 = -1, sell1 = -1, by2 = -1, sell2 = -1;
            for (int i = 0; i < prices.Length; i++)
            {
                //max_profit = Math.Max(max_profit, prices[i] - min_cost);
                //min_cost = Math.Min(min_cost, prices[i]);

                if (prices[i] - min_cost > max_profit)
                {
                    if (sell1 == -1)
                    {
                        sell1 = i;
                    }

                    max_profit = prices[i] - min_cost;
                }

                if (prices[i] < min_cost)
                {
                    min_cost = prices[i];

                    if (buy1 == -1)
                    {
                        buy1 = i;
                    }
                }
            }

            return max_profit;
        }
    }

    public class MatrixStuff
    {

        public void PrintSpiral(int[,] a, int r, int c)
        {
            int rs = 0, re = r-1;
            int cs = 0, ce = c-1;

            int min = Math.Min(r, c);
            int x = min % 2;
            int count = 0;
            if (x == 0)
            {
                count = x;
            }
            else
            {
                count = x + 1;
            }

            int i, j;
            //for (int k = 0; k < count; k++)
            //{
                
            //}
            while(rs<re && cs<ce)
            {
                for (i = cs; i <= ce; i++)
                {
                    Console.WriteLine(a[rs, i]);
                }

                for (i = rs + 1; i <= re; i++)
                {
                    Console.WriteLine(a[i, ce]);
                }

                for (i = ce - 1; i >= rs; i--)
                {
                    Console.WriteLine(a[re, i]);
                }


                for (i = re - 1; i > rs; i--)
                {
                    Console.WriteLine(a[i, cs]);
                }
                rs++;
                cs++;
                re--;
                ce--;
            }

        }
    }

    public class DPStuff
    {
        public int MinDistance(string word1, string word2)
        {

            if (word1 == null && word2 == null) return 0;
            if (word1 == null) return word2.Length;
            if (word2 == null) return word1.Length;

            int[] prev = new int[word2.Length + 1];
            int[] current = new int[word2.Length + 1];

            for (int i = 0; i < prev.Length; i++)
            {
                prev[i] = i;
            }

           
            int min = 0;
            for (int i = 1; i < word1.Length; i++)
            {

                for (int j = 1; j < word2.Length; j++)
                {
                    if (word1[i-1] != word2[j-1])
                    {
                        min = 1 + Math.Min(prev[j-1], Math.Min(prev[j],current[i-1]));
                        //rows[i] = min;
                        current[j] = min;
                    }
                    else
                    {
                        min = prev[i - 1];
                    }
                }

                prev = current;
            }

            return min;
        }

        public int NumberOfWaysNSteps(int n)
        {
            if (n < 0) return 0;
            if (n == 0) return 1;
            else
            {
                return NumberOfWaysNSteps(n - 3)+ NumberOfWaysNSteps(n-2);
                //return count;
            }
        }

        public int coinChange(int[] coins, int amount)
        {
            if (amount == 0) return 0;

            int[] dp = new int[amount + 1];
            dp[0] = 0; // do not need any coin to get 0 amount
            for (int i = 1; i <= amount; i++)
                dp[i] = Int32.MaxValue;

            for (int i = 0; i <= amount; i++)
            {
                foreach(int coin in coins)
                {
                    if (i + coin <= amount)
                    {
                        if (dp[i] == Int32.MaxValue)
                        {
                            dp[i + coin] = dp[i + coin];
                        }
                        else {
                            dp[i + coin] = Math.Min(dp[i + coin], dp[i] + 1);
                        }
                    }
                }
            }

            if (dp[amount] >= Int32.MaxValue)
                return -1;

            return dp[amount];
        }
    }
}
