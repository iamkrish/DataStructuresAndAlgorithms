using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
   
    public class PreorderSerialization
    {
        public bool IsValidSerialization(string preorder)
        {
            if (preorder == null || preorder.Length == 0) return true;
            if (preorder.Length < 3) return false;
            if (preorder[0] == '#') return false;

            int index = 0;

            StringBuilder sb = new StringBuilder();
            string[] tok = preorder.Split(new char[] { ',' });
            for(int i =0;i<tok.Length;i++)
            {
                sb.Append(tok[i]);
            }

            //preorder = sb.ToString();
            return Pre(preorder, 0, ref index);
        }

        private bool Pre(string s, int i, ref int index)
        {

            if (index == s.Length)
            {
                return false;
            }

            if (s[index] == ',')
            {
                index = index + 1;
                return Pre(s, i, ref index);
            }
            if (s[index] == '#')
            {
                if (i == 0) return false;
                return true;
            }

            index = index + 1;
            bool left = Pre(s, i + 1, ref index);
            if (!left) return false;
            index = index + 1;
            bool right = Pre(s, i + 1, ref index);
            if (!right) return false;

            if (i == 0)
            {
                if (index == s.Length - 1) return true;
                return false;
            }
            return true;
        }
    }
}
