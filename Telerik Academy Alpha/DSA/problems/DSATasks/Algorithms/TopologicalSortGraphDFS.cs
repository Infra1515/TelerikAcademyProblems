using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSAImplementations;

namespace Algorithms
{
    public static class TopologicalSortGraphDFS
    {
        //public static HashSet<int> TopologicalSortKahn(GraphSuccesorList graph)
        //{
        //    var stack = new Stack<int>();
        //    var set = new HashSet<int>();
        //    var topologicallySortedSet = new HashSet<int>();
        //    // how to implement ? vertex with no incoming edge?
        //    throw new NotImplementedException();
        //}

        //public static int TopologicalSortDFSRecursive(GraphSuccesorList graph, HashSet<int> visited, int v)
        //{
        //    var result = 0;
        //    if (!visited.Contains(v))
        //    {
        //        visited.Add(v);
        //        result = v;
        //        foreach (var child in graph.GetSuccesors(v))
        //        {
        //            TopologicalSortDFSRecursive(graph, visited, v);
        //        }
        //    }

        //    return result;
            
        //}

        //public static void TopSortHelpers<T> (int v, bool[] visited, Stack<T> stack)
        //{
        //    visited[v] = true;
            

        //}

        public static Stack<int> TopoSort(GraphSuccesorList graph)
        {
            var visited = new bool[graph.Size()];
            var sortedResult = new Stack<int>();
            for(int v = 0; v < graph.Size(); v++)
            {
                //visited[v] = true;
                if (!visited[v])
                {
                    VisitDFS(graph, v, sortedResult, visited);
                }
            }

            return sortedResult;
        }

        public static void VisitDFS(GraphSuccesorList graph, int v, Stack<int> result, bool[] visited)
        {
            if (!visited[v])
            {
                visited[v] = true;
                foreach (var child in graph.GetSuccesors(v))
                {
                    VisitDFS(graph, child, result, visited);
                }
                result.Push(v);
            }
        }
        //public static int TopologicalSortDFSRecursive(GraphSuccesorList graph, HashSet<int> visited, int v)
        //{
        //    var result = 0;
        //    if (!visited.Contains(v))
        //    {
        //        visited.Add(v);
        //        result = v;
        //        foreach (var child in graph.GetSuccesors(v))
        //        {
        //            TopologicalSortDFSRecursive(graph, visited, v);
        //        }
        //    }

        //    return result;

        //}

    }
}
