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
            // Return 15 => 1111
            int num = SetAllBits(4);

            //return 5->0101
            int num1 = SetEvenBits(4);

            CheckWhichBitsAreSet(num1);
            //Console.WriteLine(num1);

            int setBits = CountNumberOfBitsSet(15);
            Console.WriteLine(setBits);

            Console.ReadLine();
        }

        static int SetAllBits(int n)
        {
            int result = 0;
            for(int i=0;i< n;i++)
            {
                result |= (1 << i);
            }
            return result;
        }

        static int SetEvenBits(int n)
        {
            int result = 0;
            for (int i = 0; i < n; i+=2)
            {
                result |= (1 << i);
            }
            return result;
        }

        static void CheckWhichBitsAreSet(int n)
        {
            int i = 0;
            while(n!=0)
            {
                if((n&1)==1)
                {
                    Console.WriteLine(i);
                }
                i++;
                n = n >> 1;
            }
        }

        static int CountNumberOfBitsSet(int n)
        {
            //1. Method1: In CheckWhichBitsAreSet, increment count if n&1==1

            //Method 2
            int count = 0;
            while(n!=0)
            {
                count++;
                n = n & n - 1;
            }

            return count;
        }
    }
}
