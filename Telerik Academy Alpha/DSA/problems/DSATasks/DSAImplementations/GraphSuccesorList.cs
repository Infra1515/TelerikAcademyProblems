using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAImplementations
{
    public class GraphSuccesorList
    {
        private readonly List<int>[] childNodes;

        /// <summary>
        /// constructs an empty graf by given size
        /// </summary>
        /// <param name="size"></param>
        public GraphSuccesorList(int size)
        {
            this.childNodes = new List<int>[size];

            for(int i = 0; i < size; i++)
            {
                this.childNodes[i] = new List<int>();
            }
        }


        /// <summary>
        /// constructs a new graph by a given list of child nodes for each vertex
        /// </summary>
        /// <param name="childNodes"></param>
        public GraphSuccesorList(List<int>[] childNodes)
        {
            this.childNodes = childNodes;
        }

        public int Size()
        {
            return this.childNodes.Length;
        }

        /// <summary>
        /// Adds a new edge from vertex U to vertex V
        /// </summary>
        /// <param name="u">predecessor</param>
        /// <param name="v">successor</param>
        public void AddEdge(int u, int v  )
        {
            childNodes[u].Add(v);
        }

        public void RemoveEdge(int u, int v)
        {
            childNodes[u].Remove(v);
        }

        public bool HasEdge(int u, int v)
        {
            bool hasEdge = this.childNodes[u].Contains(v);
            return hasEdge;
        }

        public List<int> GetSuccesors(int v)
        {
            return childNodes[v];
        }



    }
}
