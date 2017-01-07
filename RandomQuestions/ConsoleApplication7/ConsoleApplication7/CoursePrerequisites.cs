using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication7
{
    public class CoursePrerequisites
    {
        public bool CanFinish(int numCourses, int[,] prerequisites)
        {
            if (numCourses == 0) return false;
            if (numCourses == 1) return true;

            if (prerequisites == null || prerequisites.Length == 0) return true;

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
            int[] visited = new int[numCourses];

            for (int i = 0; i < numCourses; i++)
            {
                if (visited[i] == 0)
                {
                    if (!DFS(i, map, visited))
                    {
                        return false;
                    }
                }

            }
            return true;

        }


        private bool DFS(int n, IDictionary<int, IList<int>> map, int[] visited)
        {

            if (visited[n] == 1) return false;
            
            if(visited[n]==0)
            {
                visited[n] = 1;
                IList<int> neighbors = map[n];

                foreach (var neighbor in neighbors)
                {
                    if (!DFS(neighbor, map, visited))
                    {
                        return false;
                    }
                }

                visited[n] = 2;
            }
            
            return true;
        }

    }
}
