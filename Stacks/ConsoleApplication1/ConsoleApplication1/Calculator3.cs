using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class Solution
    {
        public int Calculate(string s)
        {
            if (s == null || s.Length == 0) return 0;


            Stack<int> s1 = new Stack<int>();
            Stack<char> s2 = new Stack<char>();
            int i = 0;
            int num = 0;
            while (i < s.Length)
            {
                if (s[i] >= '0' && s[i] <= '9')
                {
                    num = s[i] - '0';

                    while (++i < s.Length && (s[i] >= '0' && s[i] <= '9'))
                    {
                        num = 10 * num + s[i] - '0';
                    }
                    i--;
                    s1.Push(num);
                    num = 0;
                }
               // else if (s[i] == ' ') continue;
                else if (s[i] == '(')
                {
                    s2.Push(s[i]);

                }
                else if (s[i] == ')')
                {
                    while (s2.Count > 0 && s2.Peek() != '(')
                    {
                        if (s1.Count < 2) throw new InvalidOperationException("Cannot proceed");
                        int a = s1.Pop();
                        int b = s1.Pop();
                        char oper = s2.Pop();
                        int result = GetResult(a, b, oper);
                        s1.Push(result);
                    }

                    s2.Pop();

                }
                else if (s[i] == '+' || s[i] == '-')
                {
                    if (s2.Count == 0 || s2.Peek() == '(')
                    {
                        s2.Push(s[i]);
                    }
                    else
                    {
                        while (s2.Count > 0 && s2.Peek() != '(')
                        {
                            if (s1.Count < 2) throw new InvalidOperationException("Cannot proceed");
                            int a = s1.Pop();
                            int b = s1.Pop();
                            char oper = s2.Pop();
                            int result = GetResult(a, b, oper);
                            s1.Push(result);
                        }
                        s2.Push(s[i]);
                    }

                }

                i++;
            }

            while (s2.Count > 0)
            {

                if (s1.Count < 2) throw new InvalidOperationException("Cannot proceed");
                int a = s1.Pop();
                int b = s1.Pop();
                char oper = s2.Pop();
                int result = GetResult(a, b, oper);
                s1.Push(result);
            }

            return s1.Peek();

        }



        int GetResult(int a, int b, char oper)
        {
            int result = 0;
            switch (oper)
            {
                case '+':
                    result = a + b;
                    break;
                case '-':
                    result = b - a;
                    break;
                default:
                    result = 0;
                    break;
            }

            return result;

        }
    }
}
