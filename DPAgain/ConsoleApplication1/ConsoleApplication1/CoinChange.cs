using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class CoinChange
    {

        // Each coin can appear any number of times
        public int CombinationSum(int[] s, int requiredSum)
        {
            if (requiredSum == 0) return 1;
            if (s == null || s.Length == 0) return 0;
            if (s.Length == 1)
            {
                if (requiredSum == s[0]) return 1;
                else return 0;
            }
            else
            {
                Array.Sort(s);
                return CombinationsHelper(s, requiredSum);
            }
        }

        private int CombinationsHelper(int[] coins, int requiredSum)
        {
            int[] result = new int[requiredSum + 1];
            result[0] = 1;

            for (int i = 0; i < coins.Length; i++)
            {
                for (int j = coins[i]; j <= requiredSum; j++)
                {
                    // This could be read as  S(i,jnumbers) = S(i,j-1 numbers)+ S(i-c[j])
                    // In RHS, first term is when we exclude the current element
                    // scond term is when we include the current element
                    result[j] = result[j] + result[j - coins[i]];
                }
            }

            return result[requiredSum];
        }

        public int MinCoinsForSum(int[] coins, int amount)
        {
            if (coins == null || coins.Length == 0) return -1;
            if (amount == 0) return -1;

            Array.Sort(coins);
            return MinCoinsForSumHelper(coins, amount);
        }

        private int MinCoinsForSumHelper(int[] coins, int amount)
        {
            int[] result = new int[amount + 1];
            result[0] = 0;
            for (int i = 1; i <= amount; i++)
            {
                result[i] = amount + 1;
            }


            for (int i = 0; i < coins.Length; i++)
            {
                for (int j = coins[i]; j <= amount; j++)
                {
                    result[j] = Math.Min(result[j], 1 + result[j - coins[i]]);
                }
            }
            return result[amount]==amount+1?-1:result[amount];
        }

    }
}
