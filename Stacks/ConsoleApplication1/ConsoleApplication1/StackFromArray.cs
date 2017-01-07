
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class StackFromArray
    {
        public int[] a;
        public int size;
        public int capacity;

        public int top;

        public StackFromArray()
        {
            capacity = 0;
            size = 0;
            a = new int[capacity];

            top = -1;
        }

        public StackFromArray(int c)
        {
            capacity = c;
            size = 0;
            a = new int[capacity];
        }
    }
}
