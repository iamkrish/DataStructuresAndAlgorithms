using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class StepsJumpWays
    {

        public IList<IList<int>> PrintWaysToReachNsteps(int n)
        {

            IList<IList<int>> res = new List<IList<int>>();
            if (n == 0) return res;
            IList<int> sub = new List<int>();

            Foo(n, sub, res, 3);
            return res;
        }

        private void Foo(int n, IList<int> sub, IList<IList<int>> res, int max_step_size)
        {
            if (n < 0) return;
            if(n==0)
            {
                res.Add(new List<int>(sub));
                return;

            }

            for(int i=1;i<=max_step_size;i++)
            {
                sub.Add(i);
                Foo(n - i, sub, res, max_step_size);
                sub.RemoveAt(sub.Count - 1);
            }

        }
    }
}
