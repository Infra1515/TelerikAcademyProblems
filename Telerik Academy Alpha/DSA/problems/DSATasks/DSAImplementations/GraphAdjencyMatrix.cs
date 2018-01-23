using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAImplementations
{
    public class GraphAdjencyMatrix
    {
        private readonly int[,] vertices;

        public GraphAdjencyMatrix(int[,] vertices)
        {
            this.vertices = vertices;
        }

        public GraphAdjencyMatrix(int n )
        {
            this.vertices = new int[n, n];
        }
        public void AddEdge(int i, int j)
        {
            this.vertices[i, j] = 1;
        }

        public void RemoveEdge(int i, int j)
        {
            this.vertices[i, j] = 0;
        }

        public bool HasEdge(int i, int j)
        {
            return this.vertices[i, j] == 1;
        }

        public IList<int> GetSuccessors(int i)
        {
            var successors = new List<int>();
            for(var j = 0; j < vertices.GetLength(1); j++)
            {
                if(vertices[i,j] == 1)
                {
                    successors.Add(vertices[i, j]);
                }
            }

            return successors;
        }
    }
}
