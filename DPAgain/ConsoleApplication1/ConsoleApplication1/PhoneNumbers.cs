using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class PhoneNumbers
    {
        public IList<string> GetLetterCombinations(string s)
        {
            IList<string> res = new List<string>();
            if (s == null || s.Length == 0) return res;

            IDictionary<int, IList<char>> map = new Dictionary<int, IList<char>>();
            map.Add(2, new List<char>() { 'a', 'b' });
            map.Add(3, new List<char>() { 'd', 'e', 'f' });
            map.Add(4, new List<char>() { 'g', 'h', 'i' });
            map.Add(5, new List<char>() { 'j', 'k', 'l' });
            map.Add(6, new List<char>() { 'm', 'n', 'o' });
            map.Add(7, new List<char>() { 'p', 'q', 'r', 's' });
            map.Add(8, new List<char>() { 't', 'u', 'v' });
            map.Add(9, new List<char>() { 'w', 'x', 'y', 'z' });
            map.Add(0, new List<char>() { ' ' });

            IList<char> output = new List<char>();
            Helper(s, 0, res, new StringBuilder(), map);

            return res;

        }

        private void Helper(string s, int index, IList<string> res, StringBuilder sb, IDictionary<int, IList<char>> map)
        {
            if(index == s.Length)
            {
                //StringBuilder sb = new StringBuilder();
                //foreach(char c in output)
                //{
                //    sb.Append(c);
                //}
                res.Add(sb.ToString());
                return;
                
            }

            int key = (int)Char.GetNumericValue(s[index]);
            IList<char> ch = map[key];
            foreach (char c in ch)
            {
                sb.Append(c);

                Helper(s, index + 1, res, sb, map);
                sb.Length--;
                //sb.Remove(output[output.Count - 1]);
            }
        }
    }
}
