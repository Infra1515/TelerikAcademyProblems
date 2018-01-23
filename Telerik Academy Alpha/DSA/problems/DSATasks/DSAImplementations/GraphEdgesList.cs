using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAImplementations
{
    public class Graph<T>
    {
        public Graph() { }
        public Graph(IEnumerable<T> vertices, IEnumerable<Tuple<T, T>> edges)
        {
            foreach (var vertex in vertices)
                AddVertex(vertex);

            foreach (var edge in edges)
                AddEdge(edge);
        }

        public Dictionary<T, HashSet<T>> AdjacencyList { get; } = new Dictionary<T, HashSet<T>>();

        public void AddVertex(T vertex)
        {
            AdjacencyList[vertex] = new HashSet<T>();
        }

        public void AddEdge(Tuple<T, T> edge)
        {
            if (AdjacencyList.ContainsKey(edge.Item1) && AdjacencyList.ContainsKey(edge.Item2))
            {
                // bidirectional graph - if you uncomment second line it will be one-directional
                AdjacencyList[edge.Item1].Add(edge.Item2);
                //AdjacencyList[edge.Item2].Add(edge.Item1); 
            }
        }

        public void RemoveEdge(Tuple<T, T> edge)
        {
            if (AdjacencyList.ContainsKey(edge.Item1) && AdjacencyList.ContainsKey(edge.Item2))
            {
                AdjacencyList[edge.Item1].Remove(edge.Item2);
                //AdjacencyList[edge.Item2].Remove(edge.Item1);
            }
        }

        public bool HasEdge(T u, T v)
        {
            bool hasEdge = this.AdjacencyList[u].Contains(v);
            return hasEdge;
        }
    }
}
