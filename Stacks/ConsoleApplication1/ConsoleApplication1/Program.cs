using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution sln = new Solution();
            int r=sln.Calculate(@"1   -(  20-( -15)  )-40");


            Calculator c = new Calculator();
        //    var m = c.Calculate("1+2*5/3+6/4*2");


            Calculator2 calci = new Calculator2();

            // string ho = "(1+(4+5+2)-3)+(6+8)";
            string ho = " 2-1 + 2 ";
            int what =  calci.Calculate(ho);

            Stack<int> st = new Stack<int>();
            

           
            CustomStack s = new CustomStack();
            s.Push(9);
            s.Push(5);
            s.Push(7);
            s.Push(1);
            s.Push(2);

            int peek = s.Peek();
            int min = s.Min();
            s.Pop();
            min = s.Peek();
            s.Pop();
            min = s.Min();
            peek = s.Peek();

            Console.WriteLine();
        }
    }
}
