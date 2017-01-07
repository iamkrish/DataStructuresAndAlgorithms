using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class PaintHouses
    {
        public int MinCost(int[,] costs)
        {
            if (costs == null || costs.Length == 0) return 0;

            int r = 0, b = 0, g = 0, rr = 0, bb = 0, gg = 0;
            for (int i = 0; i < costs.GetLength(0); i++)
            {
                rr = r;
                bb = b;
                gg = g;
                r = costs[i, 0] + Math.Min(bb, gg);
                b = costs[i, 1] + Math.Min(rr, gg);
                g = costs[i, 2] + Math.Min(rr, bb);
            }

            return Math.Min(r, Math.Min(b, g));
        }

        public int MinCostII(int[,] costs)
        {
            if (costs == null || costs.Length == 0) return 0;

            int m = costs.GetLength(0);
            int n = costs.GetLength(1);
            int[] current = new int[n];
            int[] prev = new int[n];

            int min = 0, min_index = 0, second_min = 0, second_min_index = 0;
            int min1 = 0, min_index1 = 0, second_min1 = 0, second_min_index1 = 0;
            for (int i = 0; i < m; i++)
            {
                min1 = Int32.MaxValue;
                min_index1 = -1;

                second_min1 = Int32.MaxValue;
                second_min_index1 = -1;

                int current_value = 0;

                for (int j = 0; j < n; j++)
                {
                    if (j == min_index)
                    {
                        current_value = costs[i, j] + second_min;
                    }
                    else
                    {
                        current_value = costs[i, j] + min;
                    }


                    if (min1 == -1 || current_value < min1)
                    {
                        second_min1 = min1;
                        second_min_index1 = min_index1;
                        min1 = current_value;
                        min_index1 = j;
                    }

                    else if (second_min1 == -1 || current_value < second_min1)
                    {
                        second_min1 = current_value;
                        second_min_index1 = j;
                    }
                }

                min = min1;
                second_min = second_min1;
                min_index = min_index1;
                second_min_index = second_min_index1;

            }

            return min;

        }
    }
}
