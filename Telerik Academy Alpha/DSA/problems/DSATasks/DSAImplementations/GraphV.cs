using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAImplementations
{
    class GraphV
    {
        private static IDictionary<T, NodeV<T>> ReadGraph<T>(int m, int n, Func<string, T> parse)
        {
            SortedDictionary<T, NodeV<T>> graph = new SortedDictionary<T, NodeV<T>>();

            for (int i = 0; i < m; i++)
            {
                var pair = Console.ReadLine().Split().ToList();
                T parent = parse(pair[0]);
                T child = parse(pair[1]);

                if (!graph.ContainsKey(parent))
                {
                    graph[parent] = new NodeV<T>();
                }

                if (!graph.ContainsKey(child))
                {
                    graph[child] = new NodeV<T>();
                }

                if (graph[parent].Childs == null)
                {
                    graph[parent].Childs = new List<T>();
                }

                graph[parent].Childs.Add(child);
                graph[child].ParentCount++;
            }

            return graph;
        }

        private static void UpdateGraph(int n, IDictionary<int, NodeV<int>> graph)
        {
            for (int i = 0; i < n; i++)
            {
                if (!graph.ContainsKey(i))
                {
                    graph[i] = new NodeV<int>();
                }
            }
        }
    }

    public class NodeV<T>
    {
        public int ParentCount { get; set; }

        public bool IsVisited { get; set; }

        public List<T> Childs { get; set; }
    }
}
