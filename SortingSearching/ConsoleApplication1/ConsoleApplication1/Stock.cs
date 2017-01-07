using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class Stock
    {
        public int MaxProfit(int[] prices)
        {
            if (prices == null || prices.Length == 0) return 0;

            if (prices.Length == 1) return 0;

            int min = prices[0];
            int max_profit = 0;

            int result = 0;
            for (int i = 1; i < prices.Length; i++)
            {
                if (prices[i] <= min)
                {
                    result += max_profit;
                    min = prices[i];
                    max_profit = 0;
                    //continue;
                }
                else
                {

                    max_profit = Math.Max(max_profit, prices[i] - min);
                }


            }
            result += max_profit;
            return result;
        }
    }
}
