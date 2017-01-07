using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class WordLadderProblem
    {
        public int GetShortestPath(string source, string target, ISet<string> validWords)
        {
            //validWords.Add(source);
            validWords.Add(target);

            IDictionary<string, ISet<string>> mapping = GetWildCardPatterns(validWords);
           

            Queue<WordNode> queue = new Queue<WordNode>();
            queue.Enqueue(new WordNode(source,1));

            while(queue.Count>0)
            {
                WordNode node = queue.Dequeue();

                if(string.Equals(node.Word, target))
                {
                    return node.NumberOfSteps;
                }

                else
                {
                   // result.Add(node.Word);
                    IList<string> possibleNextWordPatterns = CreateWildCardPattern(node.Word);
                    foreach(string nextWordPattern in possibleNextWordPatterns)
                    {

                        if(mapping.ContainsKey(nextWordPattern))
                        {
                            ISet<string> words = mapping[nextWordPattern];

                            foreach (string word in words)
                            {
                                if (string.Equals(target, word))
                                {
                                    return node.NumberOfSteps+1;
                                }
                                else
                                {
                                    WordNode nextNode = new WordNode(word, node.NumberOfSteps + 1);
                                    queue.Enqueue(nextNode);
                                }
                            }
                        }                                              
                       
                    }

                }
            }

            return -1;
        }

        private IDictionary<string,ISet<string>> GetWildCardPatterns(ISet<string> validWords)
        {
            IDictionary<string,ISet<string>> dic = new Dictionary<string, ISet<string>>();

            foreach(string validWord in validWords)
            {
                IList<string> patterns = CreateWildCardPattern(validWord);

                foreach(string pattern in patterns)
                {
                    if(!dic.ContainsKey(pattern))
                    {
                        HashSet<string> set = new HashSet<string>();
                        set.Add(validWord);
                        dic.Add(pattern, set);
                    }
                    else
                    {
                        dic[pattern].Add(validWord);
                    }
                }
            }
            return dic;
        }

        private IList<string> GetValidLinkedWords(string word, ISet<string> validWords)
        {
            IList<string> result = new List<string>();

            IList<string> patterns = CreateWildCardPattern(word);
            IDictionary<string, ISet<string>> patternToValidWordsMapping = GetWildCardPatterns(validWords);

            foreach(string pattern in patterns)
            {
                if(patternToValidWordsMapping.ContainsKey(pattern))
                {
                    ISet<string> words = patternToValidWordsMapping[pattern];

                    foreach(string w in words)
                    {
                        result.Add(w);
                    }
                }
            }
            return result;
        }

        private IList<string> CreateWildCardPattern(string word)
        {
            IList<string> list = new List<string>();
            
            for(int i = 0; i< word.Length;i++)
            {
                string pattern = word.Substring(0, i) + "_" + word.Substring(i+1);
                list.Add(pattern);
            }
            return list;
        }
    }

     public class WordNode
    {
        public string Word;
        public int NumberOfSteps;
        public WordNode(string word, int numberOfSteps)
        {
            Word = word;
            NumberOfSteps = numberOfSteps;
        }
    }
}
