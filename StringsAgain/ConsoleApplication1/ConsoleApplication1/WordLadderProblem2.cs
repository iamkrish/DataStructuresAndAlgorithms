using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
   public  class WordLadderProblem2
    {
        public IList<string> GetWordLadderPath(string source, string target, ISet<string> validWords)
        {
            BFSNode sourceNode = new BFSNode(source);
            BFSNode targetNode = new BFSNode(target);
            

            while (!sourceNode.IsComplete && !targetNode.IsComplete)
            {
                string link = SearchLevel(sourceNode, targetNode, validWords);
                if (link != null)

                {
                    return MergePaths(sourceNode, targetNode, link);
                   
                }

                link = SearchLevel(targetNode, sourceNode, validWords);
                if (link != null)
                {
                    var res = MergePaths(sourceNode, targetNode, link);
                    return MergePaths(sourceNode, targetNode, link);
                }

            }

            return null; 
        }

        public IList<IList<string>> GetWordLadderPath2(string source, string target, ISet<string> validWords)
        {
            BFSNode sourceNode = new BFSNode(source);
            BFSNode targetNode = new BFSNode(target);
            IList<IList<string>> allShortestpaths = new List<IList<string>>();
            HashSet<string> uniqueLinkWords = new HashSet<string>();
            //int shortestPathLength = 0;
            while (!sourceNode.IsComplete && !targetNode.IsComplete)
            {
                ISet<string> links = SearchLevel2(sourceNode, targetNode, validWords);
                foreach(string link in links)
                {
                    if(!uniqueLinkWords.Contains(link))
                    {
                        uniqueLinkWords.Add(link);
                        var res = MergePaths(sourceNode, targetNode, link);
                        allShortestpaths.Add(res);

                        
                    }
                   
                }

                links = SearchLevel2(targetNode, sourceNode, validWords);
                foreach (string link in links)
                {
                    if (!uniqueLinkWords.Contains(link))
                    {
                        uniqueLinkWords.Add(link);
                        var res = MergePaths(sourceNode, targetNode, link);
                        allShortestpaths.Add(res);
                    }
                }

            }

            int len = allShortestpaths.Select(x => x.Count).Min();
            return allShortestpaths.Where(x=>x.Count==len).ToList();
        }

        public string SearchLevel(BFSNode sourceNode, BFSNode targetNode, ISet<String> validWords)
        {
            Queue<PathNode> toBeVisited = sourceNode.ToBeVisitedNodes;

            while(toBeVisited.Count>0)
            {
                PathNode node = toBeVisited.Dequeue();

                // Is it visited bottom up?
                if (targetNode.VisitedNodes.ContainsKey(node.Word))
                {
                    //Yes.. return the common word;
                    return node.Word;
                }

                // Has it already been visited as a part of the current queue?
                IList<string> validNextWords = WordLadderHelper.GetValidLinkedWords(node.Word, validWords);

                foreach (string validWord in validNextWords)
                {
                    if (!sourceNode.VisitedNodes.ContainsKey(validWord))
                    {
                        PathNode pn = new PathNode(validWord, node);
                        sourceNode.VisitedNodes.Add(validWord, pn);
                        sourceNode.ToBeVisitedNodes.Enqueue(pn);
                    }
                }
            }
            return null;
        }

        public ISet<string> SearchLevel2(BFSNode sourceNode, BFSNode targetNode, ISet<String> validWords)
        {
            Queue<PathNode> toBeVisited = sourceNode.ToBeVisitedNodes;
            ISet<string> linkWords = new HashSet<string>();

            while (toBeVisited.Count > 0)
            {
                PathNode node = toBeVisited.Dequeue();

                // Is it visited bottom up?
                if (targetNode.VisitedNodes.ContainsKey(node.Word))
                {
                    //Yes.. return the common word;
                    linkWords.Add(node.Word);
                    continue;
                }

                // Has it already been visited as a part of the current queue?
                IList<string> validNextWords = WordLadderHelper.GetValidLinkedWords(node.Word, validWords);

                foreach (string validWord in validNextWords)
                {
                    if (!sourceNode.VisitedNodes.ContainsKey(validWord))
                    {
                        PathNode pn = new PathNode(validWord, node);
                        sourceNode.VisitedNodes.Add(validWord, pn);
                        sourceNode.ToBeVisitedNodes.Enqueue(pn);
                    }
                }
            }
            return linkWords;
        }

        private IList<string> MergePaths(BFSNode sourceNode, BFSNode destNode, string link)
        {
            PathNode end1 = sourceNode.VisitedNodes[link];
            PathNode end2 = destNode.VisitedNodes[link];
            IList<string> list1 = end1.Collapse(false);
            IList<string> list2 = end2.Collapse(true);
            list2.RemoveAt(0);

            for(int i =0; i<list2.Count;i++)
            {
                list1.Add(list2[i]);
                
            }
            //list2 = null;
            return list1;
        }

    }

    public class BFSNode
    {
        
        public bool IsComplete
        {
            get
            {
                return ToBeVisitedNodes.Count == 0;
            }
        }

        public Queue<PathNode> ToBeVisitedNodes { get; set; }

        public IDictionary<string, PathNode> VisitedNodes { get; set; }

        public BFSNode(string word)
        {
           
            ToBeVisitedNodes = new Queue<PathNode>();
            VisitedNodes = new Dictionary<string, PathNode>();

            PathNode node = new PathNode(word, null);
            ToBeVisitedNodes.Enqueue(node);

            VisitedNodes.Add(word, node);
        }



    }

    public class PathNode
    {
        public string Word { get; set; }

        public PathNode Previous { get; set; }

        public PathNode(string word, PathNode prev)
        {
            Word = word;
            Previous = prev;
        }

        public IList<string> Collapse(bool addToEnd)
        {
            IList<string> path = new List<string>();
            //path.Add(Word);
            PathNode previous = this;
            while (previous != null)
            {
                if (addToEnd)
                {
                    path.Add(previous.Word);
                }
                else
                {
                    path.Insert(0, previous.Word);
                }

                previous = previous.Previous;
            }
            return path;
        }

    }
}
