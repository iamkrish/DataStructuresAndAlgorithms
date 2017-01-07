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
            Pascal_Triangle pt = new Pascal_Triangle();
            var res= pt.Generate(2);
            ReverseNumber rnum = new ReverseNumber();
            int rev =rnum.Reverse(1234567898);

            Console.ReadLine();
        }
    }
}
