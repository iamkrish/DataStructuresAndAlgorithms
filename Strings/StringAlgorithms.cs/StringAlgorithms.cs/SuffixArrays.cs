using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringAlgorithms.cs
{
    //TODO:
    /*
      Suffix arrya does not seem to handle the following cases
      1. repeated patterns. It returns only 1 of the indexes. Does not return the count of occurences
      2. For 1, it also does not always return the first/last occurnce 

    */
    internal class SuffixArrayElement : IComparable<SuffixArrayElement>
    {
        public String Suffix { get; set; }
        public int StartIndexOfSuffix { get; set; }
        public SuffixArrayElement(String suffix, int index)
        {
            Suffix = suffix;
            StartIndexOfSuffix = index;
        }

        int IComparable<SuffixArrayElement>.CompareTo(SuffixArrayElement other)
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
                return this.Suffix.CompareTo(other.Suffix);
            }

        }

    }

    internal class SuffixArray
    {
        public SuffixArrayElement[] Suffixes { get; set; }

        public int[] SuffixIndexes { get; set; }

        public SuffixArray(String s)
        {
            ConstructSuffixTree(s);
        }

        public int GetPatternStart(string text, string pattern)
        {
            if (text == null) return -1;
            if (pattern == null) return -1;

            if (text.Length == 0)
            {
                if (pattern.Length == 0) return 0;
                else return -1;
            }

            int start = 0;
            int end = text.Length - 1;

            while (start <= end)
            {
                int mid = start + (end - start) / 2;

                //Since suffix indexes hold the starting point of each suffix in a sorted order, we can access the substring
                // starting at value pointed by SuffixIndexes[mid];
                string suffixFromText = text.Substring(SuffixIndexes[mid]);

                //Compare the pattern with the middle suffix in sorted order
                int compare = string.Compare(pattern, 0, suffixFromText, 0, pattern.Length);
                if (compare == 0)
                {
                    //Found match
                    return SuffixIndexes[mid];
                }
                else
                {
                    if (compare > 0)
                    {
                        // Look in later pages in dictionary
                        start = mid + 1;
                    }
                    else
                    {
                        // look for earlier pages in dictionary
                        end = mid - 1;
                    }
                }
            }

            // did not find the pattern
            return -1;
        }

        public IList<int> FindAllOccurrencesOfPatternInText(string text, string pattern)
        {
            if (text == null || pattern == null) return null;
            IList<int> Count = new List<int>();
            if (text.Length == 0)
            {
                if (pattern.Length == 0)
                {
                    Count.Add(0);
                    return Count;
                }
                else
                {
                    return null;
                }
            }

            int start = 0;
            int end = text.Length - 1;
            while (start <= end)
            {
                int mid = start + (end - start) / 2;

                string textStartingAtSuffix = text.Substring(SuffixIndexes[mid]);
                int compare = string.Compare(pattern, 0, textStartingAtSuffix, 0, pattern.Length);

                if (compare == 0)
                {
                    //Match found.. 
                    Count.Add(SuffixIndexes[mid]);

                    int l = mid - 1;
                    while (l >= start && (string.Compare(pattern, 0, text.Substring(SuffixIndexes[l]), 0, pattern.Length) == 0))
                    {
                        Count.Add(SuffixIndexes[l]);
                        l--;
                    }

                    int r = mid + 1;
                    while (r <= end && (string.Compare(pattern, 0, text.Substring(SuffixIndexes[r]), 0, pattern.Length) == 0))
                    {
                        Count.Add(SuffixIndexes[r]);
                        r++;
                    }
                    return Count;
                }
                else
                {
                    if (compare > 0)
                    {
                        // Look in later pages in dictionary
                        start = mid + 1;
                    }
                    else
                    {
                        // look for earlier pages in dictionary
                        end = mid - 1;
                    }
                }
            }

            return null;
        }

        private void ConstructSuffixTree(string s)
        {
            if (s != null)
            {
                Suffixes = new SuffixArrayElement[s.Length];

                for (int i = 0; i < Suffixes.Length; i++)
                {
                    string suffix = s.Substring(i);
                    SuffixArrayElement suffixArrayElement = new SuffixArrayElement(suffix, i);
                    Suffixes[i] = suffixArrayElement;
                }

                Array.Sort<SuffixArrayElement>(Suffixes);

                // Save the starting point indexes of the sorted arrays in an ainteger array
                SuffixIndexes = Suffixes.Select(st => st.StartIndexOfSuffix).ToArray();

            }
        }

    }

}
