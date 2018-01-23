//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Actions
//{
//    public class Program
//    {
//        static void Main(string[] args)
//        {
//            var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
//            var n = input[0]; // total number of vertexes
//            var m = input[1]; // total number of dependencies
//            var childs = new List<int>[n];
//            var parentsCount = new int[n];
//            var visited = new bool[n];
//            ReadGraph(m, childs, parentsCount);
//            TopoSort(childs, visited, parentsCount);
//        }

//        static void ReadGraph(int m, List<int>[] childs, int[] parentsCount)
//        {
//            for(int i = 0; i < m; i++)
//            {
//                var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
//                var parent = input[0];
//                var child = input[1];
//                parentsCount[child]++;
//                if(childs[parent] == null)
//                {
//                    childs[parent] = new List<int>();
//                }
//                childs[parent].Add(child);
//            }
//        }

//        static void TopoSort(List<int>[] childs, bool[] visited, int[] parentCount)
//        {
//            bool isAllVisited = false;
//            while (!isAllVisited)
//            {
//                isAllVisited = true;
//                for(int i = 0; i < parentCount.Length; i++)
//                {
//                    if(parentCount[i] == 0 && !visited[i])
//                    {
//                        visited[i] = true;
//                        Console.WriteLine(i);

//                        if(childs[i] != null)
//                        {
//                            foreach (var child in childs[i])
//                            {
//                                parentCount[child]--;
//                            }

//                        }
//                        isAllVisited = false;
//                        break;
//                    }   
//                }
//            }
//        }
//    }
//}