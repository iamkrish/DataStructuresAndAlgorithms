using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    internal class CoinChange
    {
        // For recursion we can divide it into 2 subsets
        // Set contains atleast one mth element
        // Set does not contain the mth element

        // Note m represents the number of elemens we are looking at and not index
        public int GetCoinCombinationsForSum(int[] a, int m, int n)
        {
            if (n == 0) return 1; // If we need a sum of 0, we dont have to include any coins. That is 1 combination
            if (n < 0) return 0;
            if (m <= 0 && n >= 1) return 0; // We need a sum of atleast 1 and we have 0 or less coins

            return GetCoinCombinationsForSum(a, m - 1, n) + GetCoinCombinationsForSum(a, m, n - a[m - 1]);
        }

        public int DPGetCoinCombinations(int[] a, int required_sum)
        {
            int m = a.Length;
            int n = required_sum;
            int[,] table = new int[m, n + 1];

            for (int i = 0; i < m; i++)
            {
                table[i, 0] = 1;
            }

            for (int i = 0; i < m; i++)
            {
                for (int j = 1; j <= n; j++)
                {

                    //Include the elements till i
                    int x = (j - a[i] < 0 ? 0 : table[i, j - a[i]]);

                    //Exclude i.. so look at all elements from o .. i-1
                    int y = (i == 0 ? 0 : table[i - 1, j]);

                    table[i, j] = x + y;
                }
            }
            return table[m - 1, n];
        }

        public int DPMemoGetCoins(int[] a, int required_sum)
        {
            //Dictionary<int, int> memo = new Dictionary<int, int>();
            int[] memo = new int[required_sum + 1];
            for (int i = 0; i < memo.Length; i++)
            {
                memo[i] = -1;
            }
            return DPMemoHelper(a, memo, required_sum, a.Length);
        }

        private int DPMemoHelper(int[] a, int[] memo, int required_sum, int numberOfCoins)
        {
            if (required_sum == 0) return 1;
            if (numberOfCoins < 0) return 0;
            if (numberOfCoins == 0  && required_sum > 0) return 0;

            if (memo[required_sum] != -1)
            {
                return memo[required_sum];
            }
            else
            {
                int result = DPMemoHelper(a, memo, required_sum, numberOfCoins - 1) + DPMemoHelper(a, memo, required_sum - a[numberOfCoins-1], numberOfCoins);
                memo[required_sum] = result;
            }

            return memo[required_sum];
        }
    }
}
