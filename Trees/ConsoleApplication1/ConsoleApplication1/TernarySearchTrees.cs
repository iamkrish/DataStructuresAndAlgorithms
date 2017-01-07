using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class TernarySearchTrees
    {
        private TernaryNode Root;
        public TernarySearchTrees()
        {
            Root = null;
        }

        public void Insert(string s)
        {
            TernaryNode node = InsertHelper(Root, s);
            if(Root == null)
            {
                Root = node;
            }
        }

        public bool Search(string word)
        {
            return SearchHelper(Root, word);
        }

        private bool SearchHelper(TernaryNode root, string word)
        {
            if (root == null) return false;
            if(root.key==word[0])
            {
                if (word.Length == 1) return true;
                else return SearchHelper(root.equal, word.Substring(1));
            }
            else if(word[0]<root.key)
            {
                return SearchHelper(root.less, word);
            }
            else
            {
                return SearchHelper(root.greater, word);
            }
        }

        private TernaryNode InsertHelper(TernaryNode root, string s)
        {            
            if(root==null)
            {
                root = new TernaryNode(s[0]);
                if(s.Length==1)
                {
                    root.endWord = true;
                    return root;

                }
                else
                {
                    root.equal = InsertHelper(root.equal, s.Substring(1));
                }
            }
            else
            {
                if(s[0].Equals(root.key))
                {
                    if(s.Length==1)
                    {
                        root.endWord = true;
                        return root;
                    }
                    root.equal = InsertHelper(root.equal, s.Substring(1));
                }
                else if(s[0]<(root.key))
                {
                    root.less =  InsertHelper(root.less, s);
                }
                else
                {
                    root.greater = InsertHelper(root.greater, s);
                }

            }
            return root;
        }

        public void Traversal()
        {
            StringBuilder sb = new StringBuilder();
            Traversal(Root, sb);
        }
        public void Traversal(TernaryNode root, StringBuilder sb)
        {
            if(root!=null)
            {
                Traversal(root.less,sb);
                sb.Append(root.key);
                Traversal(root.equal,sb);                
                if(root.endWord)
                {
                    Console.WriteLine(sb.ToString());
                }
                sb.Length--;
                Traversal(root.greater, sb);

            }
        }
    }

    public class TernaryNode
    {
        public char key;
        public TernaryNode less;
        public TernaryNode equal;
        public TernaryNode greater;
        public bool endWord;

        public TernaryNode(char c)
        {
            key = c;
            less = null;
            equal = null;
            greater = null;
        }

       
    }
}
