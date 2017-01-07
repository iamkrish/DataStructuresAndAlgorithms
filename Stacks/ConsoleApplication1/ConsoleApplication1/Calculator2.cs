using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Calculator2
    {


        public int Calculate(string s)
        {
            if (s == null) return 0;

            return CalculateResult(s);
        }

        private int CalculateResult(string s)
        {

            Stack<int> s1 = new Stack<int>();
            Stack<char> s2 = new Stack<char>();
            int val = 0;
            bool set = false;

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == ' ') continue;
                else if (s[i] == '(')
                {
                    s2.Push(s[i]);
                    continue;
                }

                else if (s[i] >= '0' && s[i] <= '9')
                {
                    set = true;
                    while (i < s.Length && s[i] >= '0' && s[i] <= '9')
                    {
                        val = 10 * val + (s[i] - '0');
                        i++;
                    }
                    i--;
                    continue;
                }

                else
                {
                    if (set)
                    {
                        s1.Push(val);
                        val = 0;
                        set = false;
                    }
                }

                if (s[i] == ')')
                {
                   
                    IntermediateResult(s1, s2);
                }
                else if (s[i] == '+' || s[i] == '-')
                {
                    
                    IntermediateResult(s1, s2);
                    s2.Push(s[i]);
                }

            }

            if (set)
            {
                s1.Push(val);
                val = 0;
                set = false;
            }

            int result = FinalResult(s1, s2);
            return result;

        }

        private int IntermediateResult(Stack<int> s1, Stack<char> s2)
        {
            int result = 0;

            while (s2.Count > 0 && s2.Peek() != '(')
            {
                if (s1.Count < 2)
                {
                    throw new InvalidOperationException();
                }

                char oper = s2.Pop();
                int a = s1.Pop();
                int b = s1.Pop();
                result = GetResult(a, b, oper);
                s1.Push(result);

            }

            if (s2.Count == 0)
            {

                if (s1.Count > 1)
                {
                    throw new InvalidOperationException("Malformed input string");
                }
            }
            else
            {
                if (s2.Count > 0)
                {
                    s2.Pop();
                }

            }
            return s1.Peek();

        }

        private int FinalResult(Stack<int> s1, Stack<char> s2)
        {
            if (s2.Count == 0)
            {
                if (s1.Count == 1) return s1.Peek();
                else throw new InvalidOperationException("Malformed input string");
            }

            int result = 0;
            while (s2.Count > 0)
            {
                if (s1.Count < 2) throw new InvalidOperationException("Malformed input string");
                int a = s1.Pop();
                int b = s1.Pop();
                char oper = s2.Pop();
                result = GetResult(a, b, oper);
                s1.Push(result);
            }

            if (s1.Count != 1 || s2.Count > 0) throw new InvalidOperationException("Malformed input string");
            return s1.Peek();
        }

        private int GetResult(int a, int b, char oper)
        {
            if (oper == '+')
            {
                return a + b;
            }
            else if (oper == '-')
            {
                return b - a;
            }
            else
            {
                throw new InvalidOperationException("Invalid operator is provided");
            }

        }
    }
}
