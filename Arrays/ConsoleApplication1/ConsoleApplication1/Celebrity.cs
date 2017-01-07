using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    /* The Knows API is defined in the parent class Relation.
       bool Knows(int a, int b); */

    public class Solution 
    {
        IDictionary<int, int> list = new Dictionary<int,int>();
        
        public int FindCelebrity(int n)
        {

            list.Add(0, 1);
            list.Add(1, 0);

            int[] knownby = new int[n];
            bool[] knowssomeone = new bool[n];
            int match = -1;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = i+1; j < n; j++)
                {
                    // if j knows someone, skip
                    if (knowssomeone[j])
                    {
                        continue;
                    }

                    // if i knows j
                    // j could possibly be  a celbrity
                    if (Knows(i, j))
                    {
                        knownby[j] += 1;
                        knowssomeone[i] = true;
                    }

                    if (Knows(j, i))
                    {
                        knownby[i] += 1;
                        knowssomeone[j] = true;
                    }

                }

            }

            for (int i = 0; i < n; i++)
            {
                if (!knowssomeone[i] && knownby[i] == n - 1)
                {
                    match = i;

                }

            }

            if (match != -1) return match;
            else return -1;
        }

        private bool Knows(int i, int j)
        {
            return list[i] == j
;

        }
    }

   
}
