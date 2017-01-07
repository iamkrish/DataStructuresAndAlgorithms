using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication7
{
    class Program
    {
        static void Main(string[] args)
        {

            Roman roman = new Roman();
            int roman_value=roman.RomanToInt("DCXXI");
            HashSet<int> hs = new HashSet<int>();
            hs.Add(1);
            hs.Add(2);
            hs.Add(3);
            bool xr= hs.Remove(hs.FirstOrDefault());

            //string s1 = "hello ";


            MultiplyStrings ms = new MultiplyStrings();
            string multiply = ms.Multiply("15", "18");
            CoursePrerequisites2 cpr = new CoursePrerequisites2();
            int[,] courses = new int[,]
            { { 0, 1 }, { 3, 1 }, { 1, 3 }, { 3, 2 }


            };
            var order=cpr.FindOrder(4, courses);
            

            IntervalMerge im = new IntervalMerge();
            Interval i1 = new Interval(1, 4);
            Interval i3 = new Interval(6, 9);
            Interval i2 = new Interval(10, 12);
            
            IList<Interval> intervals = new List<Interval>();
            intervals.Add(i1);
            intervals.Add(i3);
            intervals.Add(i2);

            Interval i4 = new Interval(2, 11);
            //var x = im.Merge(intervals);

            var x = im.InsertAndMerge(intervals, i4);

            SlidingWindow sw = new SlidingWindow();
            int[] stream = new int[] { 7,2,4};

            var r = sw.MaxSlidingWindow(stream, 2);

            Solution3 s3 = new Solution3();
            s3.ReverseWords(" this is  blue  ");
            Solution s = new Solution();
            int[] a = new int[] { 10, 15, 20, 0, 5 };
          //  int i = s.Search(a, 5);

            Solution2 s2 = new Solution2();
            string[] tok = new string[] { "1", "2", "*", "3", "+" };
            s2.EvalRPN(tok);
            Console.ReadLine();
        }
    }

    public class Solution
    {
        public int Search(int[] nums, int target)
        {
            if (nums == null || nums.Length == 0) return -1;
            if (nums.Length == 1)
            {
                if (nums[0] == target) return 0;
                else return -1;
            }
            int res = Helper(nums, 0, nums.Length - 1, target);

            if (res != -1)
            {
                while (res >= 0 && nums[res] == target)
                {
                    res--;
                }
                return res + 1;
            }

            return res;
        }

        private int Helper(int[] a, int l, int r, int target)
        {
            if (l > r)
            {
                return -1;
            }
            int m = l + (r - l) / 2;
            if (a[m] == target)
            {

                return m;
            }

            // Left side sorted
            if (a[l] < a[m])
            {
                if (a[l] <= target && target < a[m])
                {
                    return Helper(a, l, m - 1, target);
                }
                else
                {
                    return Helper(a, m + 1, r, target);
                }

            }
            //Right side sorted
            else if (a[m] < a[r])
            {
                if (a[m] < target && target <= a[r])
                {
                    return Helper(a, m + 1, r, target);

                }
                else
                {
                    return Helper(a, l, m - 1, target);
                }
            }

            else
            {
                if (a[l] == a[m])
                {
                    if (a[m] != a[r])
                    {
                        return Helper(a, m + 1, r, target);
                    }
                    else
                    {
                        int left = Helper(a, l, m - 1, target);
                        if (left != -1) return left;
                        else return Helper(a, m + 1, r, target);

                    }


                }
                else if (a[l] == a[m])
                {
                    return Helper(a, m + 1, r, target);
                }
                else
                {
                    return Helper(a, l, m - 1, target);
                }

            }
        }


        
    }

    public class Solution2
    {
        public int EvalRPN(string[] tokens)
        {
            if (tokens == null || tokens.Length == 0) return 0;


            string priority = "+-*/";
            if (tokens.Length == 1)
            {
                if (priority.Contains(tokens[0]))
                {
                    return Int32.MinValue;
                }
                else
                {
                    return Int32.Parse(tokens[0]);
                }
            }


            int i = 0;
            Stack<string> operand = new Stack<string>();
            Stack<string> oper = new Stack<string>();
            while (i < tokens.Length)
            {
                if (priority.Contains(tokens[i]))
                {
                    int pri = priority.IndexOf(tokens[i]);
                    while (oper.Count > 0)
                    {
                        string peek = oper.Peek();
                        int p = priority.IndexOf(peek);
                        if (pri >= p) break;
                        else
                        {
                            if (operand.Count < 2) return Int32.MinValue;
                            int result = GetResult(operand.Pop(), operand.Pop(), oper.Pop());
                            operand.Push(result.ToString());
                        }
                    }
                    oper.Push(tokens[i]);

                }
                else
                {
                    if(oper.Count==0)
                    {
                        operand.Push(tokens[i]);
                    }

                    
                }

                i++;
            }


            while (oper.Count > 0)
            {
                operand.Push(GetResult(operand.Pop(), operand.Pop(), oper.Pop()).ToString());
            }
            return Int32.Parse(operand.Peek());
        }

        private int GetResult(string s1, string s2, string op)
        {
            int a = Int32.Parse(s1);
            int b = Int32.Parse(s2);
            int result = 0;
            switch (op)
            {
                case "+":
                    result = a + b;
                    break;
                case "-":
                    result = a - b;
                    break;
                case "*":
                    result = a * b;
                    break;
                case "/":
                    result = a / b;
                    break;
                default:
                    result = 0;
                    break;

            }

            return result;
        }
    }

    public class Solution3
    {
        public string ReverseWords(string s)
        {
            if (s == null || s.Length == 0) return s;

            char[] a = s.ToCharArray();
            int i = 0, j = 0;
            while (i < a.Length)
            {
                //Look for first non empty
                while (i < a.Length && a[i] == ' ')
                {
                    i++;
                }

                if (i == a.Length) break;

                // Non spaces
                while (i < a.Length && a[i] != ' ')
                {
                    a[j] = a[i];
                    j++;
                    i++;
                }
                if (i == a.Length) break;
                a[j] = ' ';
                j++;
               

                // Word breaks with single line spaces

                //if(i!=a.Length-1)
                //{
                //    a[j] = a[i];
                //    i++;
                //    j++;
                    
                //}
                //else
                //{
                //    break;
                //}

            }

            int start = 0;
            int end = j;
            

            RangeSwap(a, start, end);

            i = 0;
            int k = 0;
            while (i <end)
            {
                k = i;
                if (a[i] == ' ')
                {
                    i++;
                }
                else
                {
                    while (i < end && a[i] != ' ')
                    {
                        i++;
                    }
                   // k = i - 1;
                    RangeSwap(a, k, i-1);
                    i++;
                }
            }


            return new string(a, 0, j);
        }

        private void swap(char[] a, int i, int j)
        {
            char temp = a[i];
            a[i] = a[j];
            a[j] = temp;
        }

        private void RangeSwap(char[] a, int start, int end)
        {
            int i = start, j = end;
            char temp = ' ';
            while(i<j)
            {
                temp = a[i];
                a[i] = a[j];
                a[j] = temp;
                i++;
                j--;
            }
        }
    }
}
