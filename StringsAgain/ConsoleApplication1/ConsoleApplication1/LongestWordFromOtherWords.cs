using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class LongestWordFromOtherWords
    {

        public string Longest(string[] words)
        {
            if (words == null || words.Length <3) return string.Empty;

            //Sort in decreasing order of length
            Array.Sort(words, new LengthComparator());

            IDictionary<string, bool> dic = new Dictionary<string, bool>();
            foreach(var word in words)
            {
                dic.Add(word, true);
            }

            for(int i=0;i<words.Length;i++)
            {
                if(CanSplit(words[i],true,dic))
                {
                    return words[i];
                }
            }

            return string.Empty;
        }


        private bool CanSplit(string word, bool original, IDictionary<string,bool> dictionary)
        {
            if(dictionary.ContainsKey(word) && !original)
            {
                return true;
            }

            for(int i=0;i<word.Length;i++)
            {
                string left = word.Substring(0, i + 1);

                // right could be formed by several words(not just one). So we have to verify that we can find all the components
                string right = word.Substring(i + 1);
                if(dictionary.ContainsKey(word) && CanSplit(right, false, dictionary))
                {
                    return true;
                }
            }
            return false;
        }
    }

    public class LengthComparator:IComparer<string>
    {
        public int Compare(string a, string b)
        {
            return b.Length - a.Length;
        }

    }
}
