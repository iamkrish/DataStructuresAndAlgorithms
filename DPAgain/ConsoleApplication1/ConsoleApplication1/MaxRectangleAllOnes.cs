using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class MaxRectangleAllOnes
    {
        public int MaximalRectangle(char[,] matrix)
        {

            if (matrix == null || matrix.Length == 0) return 0;

            int m = matrix.GetLength(0);
            int n = matrix.GetLength(1);

            int[] table = new int[n];
            int max_area = 0;

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (matrix[i, j] == '0')
                    {
                        table[j] = 0;
                    }
                    else
                    {
                        table[j] += 1;
                    }
                }

                max_area = Math.Max(max_area, LargestRectangleArea(table));

            }

            return max_area;

        }

        public int LargestRectangleArea(int[] heights)
        {

            int i = 0;
            Stack<int> st = new Stack<int>();
            int max_area = 0;
            while (i < heights.Length)
            {
                if (st.Count == 0 || heights[st.Peek()] <= heights[i])
                {
                    st.Push(i);
                    i++;
                }
                else
                {
                    int height = heights[st.Pop()];
                    int val = 0;
                    if (st.Count == 0)
                    {
                        val = height * i;
                    }
                    else
                    {
                        val = height * (i - st.Peek() - 1);
                    }

                    max_area = Math.Max(max_area, val);

                    //Do not increment i here
                }
            }

            while (st.Count > 0)
            {
                int height = heights[st.Pop()];
                int val = 0;
                if (st.Count == 0)
                {
                    val = height * i;
                }
                else
                {
                    val = height * (i - st.Peek() - 1);
                }

                max_area = Math.Max(max_area, val);

            }

            return max_area;
        }

    }
}
