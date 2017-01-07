using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringAlgorithms.cs
{
    public class SuffixArray2Element:IComparable<SuffixArray2Element>
    {
        public int index;
        public string SuffixStartingAtIndex;

        public SuffixArray2Element(int i, string suffix)
        {
            index = i;
            SuffixStartingAtIndex = suffix;
        }

        int IComparable<SuffixArray2Element>.CompareTo(SuffixArray2Element other)
        {
            if (this == null && other == null)
            {
                return 0;
            }
            else if (this == null)
            {
                return 1;
            }
            else if (other == null)
            {
                return -1;
            }
            else
            {
                return this.SuffixStartingAtIndex.CompareTo(other.SuffixStartingAtIndex);
            }

        }
    }

    public class SuffixArray2
    {
        public SuffixArray2Element[] suffixArrayELements;
        public int[] suffixIndexes;

        public SuffixArray2(string s)
        {
            suffixArrayELements = new SuffixArray2Element[s.Length];

            for (int i =0; i< s.Length;i++)
            {
                suffixArrayELements[i] = new SuffixArray2Element(i, s.Substring(i));
            }

            Array.Sort(suffixArrayELements);
            suffixIndexes = suffixArrayELements.Select(st => st.index).ToArray();          
        }

        public IList<int> GetCount(string text, string pattern)
        {
            IList<int> list = new List<int>();
            if (string.IsNullOrEmpty(text) || string.IsNullOrEmpty(pattern)) return list;

            int start = 0;
            int end = text.Length-1;
            
            int mid=0;
            while(start<=end)
            {
                mid = start + (end - start) / 2;

                string textAtIndex = suffixArrayELements[suffixIndexes[mid]].SuffixStartingAtIndex;

                int compare = string.Compare(textAtIndex, 0, pattern, 0, pattern.Length);

                if(compare==0)
                {
                    list.Add(suffixIndexes[mid]);
                    break;
                }

                if(compare<0)
                {
                    start = mid + 1;
                }
                else
                {
                    end = mid - 1;
                }              
               
            }

            if(start<=end)
            {
                int l = mid - 1;
                while (l >= 0 && suffixArrayELements[l].SuffixStartingAtIndex.StartsWith(pattern))
                {
                    list.Add(suffixIndexes[l]);
                    l--;
                }
                int r = mid + 1;
                while (r < text.Length && suffixArrayELements[r].SuffixStartingAtIndex.StartsWith(pattern))
                {
                    list.Add(suffixIndexes[r]);
                    r++;
                }

            }

            return list;
        }
    }
}
