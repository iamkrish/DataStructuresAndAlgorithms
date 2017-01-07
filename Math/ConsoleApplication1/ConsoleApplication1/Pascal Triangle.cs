using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Pascal_Triangle
    {
        public IList<IList<int>> Generate(int numRows)
        {
            IList<IList<int>> list = new List<IList<int>>();
            int i = 0;
            while (i < numRows)
            {
                IList<int> current = new List<int>();
                current.Add(1);
                if (i > 0)
                {
                    IList<int> prev = list[i - 1];
                    if (prev.Count > 0)
                    {
                        int j = 1;
                        while (j < prev.Count)
                        {
                            current.Add(prev[j] + prev[j - 1]);
                            j++;
                        }
                        current.Add(1);
                    }
                }


                list.Add(current);
                i++;
            }

            return list;
        }
    }
}
