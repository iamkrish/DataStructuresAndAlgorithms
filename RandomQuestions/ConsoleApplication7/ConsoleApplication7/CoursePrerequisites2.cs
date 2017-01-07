using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication7
{
    class CoursePrerequisites2
    {
        public int[] FindOrder(int numCourses, int[,] prerequisites)
        {
            if (numCourses == 0) return new int[0];
            //if (numCourses == 1) return new int[];

            if (prerequisites == null || prerequisites.Length == 0) return new int[0];

            IDictionary<int, IList<int>> map = new Dictionary<int, IList<int>>();

            for (int i = 0; i < prerequisites.GetLength(0); i++)
            {
                int key = prerequisites[i, 1];
                int value = prerequisites[i, 0];
                if (!map.ContainsKey(key))
                {
                    map.Add(key, new List<int>()); ;
                }
                map[key].Add(value);

                if (!map.ContainsKey(value))
                {
                    map.Add(value, new List<int>());
                }
            }
            int[] visited = new int[prerequisites.Length];
            Stack<int> stack = new Stack<int>();
            bool hasCycle = false;

            for (int i = 0; i < prerequisites.GetLength(0); i++)
            {
                int course = prerequisites[i, 0];
                if (visited[course] == 0)
                {
                    if (!DFS(course, map, visited, stack))
                    {
                        hasCycle = true;
                        break;
                    }
                }

            }

            if (hasCycle)
            {
                return new int[0];
            }
            else
            {
                int[] result = new int[stack.Count];
                for (int i = 0; i < result.Length; i++)
                {
                    result[i] = stack.Pop();
                }
                return result;

            }
            // return true;

        }


        private bool DFS(int n, IDictionary<int, IList<int>> map, int[] visited, Stack<int> stack)
        {

            if (visited[n] == 1) return false;

            if (visited[n] == 0)
            {
                visited[n] = 1;
                IList<int> neighbors = map[n];

                foreach (var neighbor in neighbors)
                {
                    if (!DFS(neighbor, map, visited, stack))
                    {
                        return false;
                    }
                }

                visited[n] = 2;
                stack.Push(n);
            }

            return true;
        }
    }
}
