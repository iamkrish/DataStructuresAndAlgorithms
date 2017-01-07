using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class Calculator
    {

        public int Calculate(string s)
        {

            if (s == null) return 0;

            string priority = @"+-*/";
            IDictionary<char, int> pd = new Dictionary<char, int>();
            pd.Add('+', 1);
            pd.Add('-', 1);
            pd.Add('*', 2);
            pd.Add('%', 2);

            Stack<int> operand = new Stack<int>();
            Stack<char> oper = new Stack<char>();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];
                if (c == ' ') continue;

                if (c == '*' || c == '/' || c == '+' || c == '-')
                {
                    if (sb.Length > 0)
                    {
                        int v = foo(sb);
                        operand.Push(v);
                        sb.Clear();
                    }

                    if (oper.Count == 0)
                    {
                        oper.Push(c);
                    }
                    else
                    {
                        int index1 = pd[c];

                        while (oper.Count > 0 && pd[oper.Peek()] >= index1)
                        {
                            if (operand.Count < 2) return 0;
                            else
                            {

                                int a = operand.Pop();
                                int b = operand.Pop();
                                operand.Push(Value(a, b, oper.Pop()));
                            }

                        }
                        oper.Push(c);
                    }

                }
                else
                {
                    sb.Append(c);
                    
                    //operand.Push(c - '0');
                }
            }

            if (sb.Length>0)
            {
                operand.Push(foo(sb));
                sb.Clear();
            }


            while (oper.Count > 0 && operand.Count > 0)
            {
                if (operand.Count < 2) return 0;
                int a1 = (int)operand.Pop();
                int b1 = (int)operand.Pop();
                int x = Value(a1, b1, oper.Pop());
                operand.Push(x);
            }

            if (operand.Count > 1) return 0;
            return operand.Pop();
        }

        public int Value(int a, int b, char oper)
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

                case '*':
                    result = a * b;
                    break;

                case '/':
                    result = b / a;
                    break;

                default: break;
            }

            return result;

        }

        public int foo(StringBuilder sb)
        {
            string s = sb.ToString();
            int val = 0;
            for (int i = 0; i < s.Length; i++)
            {
                val = val * 10 + (s[i] - '0');
            }
            return val;
        }
    }
}
