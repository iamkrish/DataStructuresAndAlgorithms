using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class ReverseNumber
    {
        public int Reverse(int n)
        {
            if (n == 0) return 0;

            bool flag = false;
            if(n<0)
            {
                flag = true;
                n = n * -1;
            }

            int result = 0;

            while (n>0)
            {
                int q = n % 10;
                
                if (result >= Int32.MaxValue / 10 || result >= (Int32.MaxValue - q) / 10)
                {
                    //overflow
                    return 0;
                }
                result = 10 * result + q; ;
                n = n / 10;
            }

            if(flag)
            {
                return -1 * result;
            }
            else
            {
                return result;
            }
        }
    }
}
