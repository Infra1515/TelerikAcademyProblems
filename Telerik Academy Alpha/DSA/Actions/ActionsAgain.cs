using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actions
{
    public class ActionsAgain
    {
        static void Main()
        {
            var input = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int totalSize = input[0];
            int totalDependencies = input[1];

            var childs = new List<int>[totalSize];
            var parentsCount = new int[totalSize];
            var visited = new bool[totalSize];
            FillGraph(childs, parentsCount, totalDependencies);
            TopoSort(childs, parentsCount, visited);


        }

        static void FillGraph(List<int>[] childs, int[] parentsCount, int totalDependencies)
        {
            for(int i = 0; i < totalDependencies; i++)
            {
                var pair = Console.ReadLine().Split().Select(int.Parse).ToArray();
                var parent = pair[0];
                var child = pair[1];

                if(childs[parent] == null)
                {
                    childs[parent] = new List<int>();
                }

                childs[parent].Add(child);
                parentsCount[child]++;
            }
        }

        static void TopoSort(List<int>[] childs, int[] parentsCount, bool[] visited)
        {
            bool isAllVisited = false;

            while (!isAllVisited)
            {
                isAllVisited = true;

                for (int i = 0; i < parentsCount.Length; i++)
                {
                    if (parentsCount[i] == 0 && !visited[i])
                    {
                        Console.WriteLine(i);
                        visited[i] = true;
                        if(childs[i] != null)
                        {
                            foreach (var child in childs[i])
                            {
                                parentsCount[child]--;
                            }
                        }

                        isAllVisited = false;
                        break;
                    }
                }
            }
        }
    }

}
