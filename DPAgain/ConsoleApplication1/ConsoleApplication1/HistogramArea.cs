using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class HistogramArea
    {
        public int LargestRectangleArea(int[] heights)
        {

            int i = 0;
            Stack<int> st = new Stack<int>();
            int max_area = 0;
            while(i<heights.Length)
            {
                if(st.Count==0 || heights[st.Peek()]<=heights[i])
                {
                    st.Push(i);
                    i++;
                }
                else
                {
                    int height = heights[st.Pop()];
                    int val = 0;
                    if(st.Count==0)
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

            while(st.Count>0)
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
