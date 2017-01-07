
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class SubsetSum
    {


        public bool SubSetSumExists(int[] a, int target_sum, int m)
        {
            // int max_sum = 16;
            int[,,] table = new int[a.Length, target_sum + 1, m + 1];

            for (int i = 0; i < a.Length; i++)
            {
                for (int j = 0; j <= target_sum; j++)
                {
                    for (int k = 0; k <= m; k++)
                    {
                        table[i, j, k] = -1;
                        //if (i == 0 && j == 0 && k == 0)
                        //{
                        //    table[i, j, k] = 1;
                        //}

                        //// Zero sum with 
                        //if (i == 0 && j == 0)
                        //{
                        //    table[i, j, k] = 1;
                        //}

                        //// Dont take any element and sum =0
                        //if (j == 0 && k == 0)
                        //{
                        //    table[i, j, k] = 1;
                        //}

                        //if (k == 0)
                        //{
                        //    table[i, j, k] = 0;
                        //}

                    }
                }
            }

            return dfs2(table, a, target_sum, 0, 0, m);

        }

        private bool dfs(int[,,] table, int[] a, int target_sum, int i, int current_sum, int k)
        {

            if (current_sum == target_sum && k == 0)
            {
                table[i, target_sum, k] = 1;
                return true;
            }

            if (i < a.Length && current_sum < target_sum)
            {
                if (table[i, current_sum, k] != -1)
                {
                    if (table[i, current_sum, k] == 0) return false;
                    return true;
                }

                bool x = dfs(table, a, target_sum, i + 1, current_sum, k) ||
                                         dfs(table, a, target_sum, i + 1, current_sum + a[i], k - 1);
                if (x)
                {
                    table[i, current_sum, k] = 1;
                }
                else
                {
                    table[i, current_sum, k] = 0;
                }
                return x;
            }

            return false;
        }

        private bool dfs2(int[,,] table, int[] a, int target_sum, int i, int current_sum, int k)
        {

            if (current_sum == target_sum && k == 0)
            {
                table[i, target_sum, k] = 1;
                return true;
            }

            if (table[i, current_sum, k] != -1)
            {
                if (table[i, current_sum, k] == 1) return true;
                else return false;
            }

            for (int l = 0; l < a.Length; l++)
            {
                for (int m = 0; m < target_sum; m++)
                {
                    for (int n = 0; n < k; n++)
                    {
                        bool x = dfs2(table, a, target_sum, i + 1, current_sum + a[l], k - 1) || dfs2(table, a, target_sum, i + 1, current_sum, k);
                        if (x) table[l, m, n] = 1;
                        else table[l, m, n] = 0;
                        return x;
                    }
                }
            }
            return false;
        }


    }



}
