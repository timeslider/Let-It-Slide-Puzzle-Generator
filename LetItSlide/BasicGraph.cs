using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetItSlide
{
    internal abstract class GraphBase
    {
        protected readonly int NumVertices;
        protected readonly bool Directed;

        public GraphBase(int numVertices, bool directed = false)
        {
            this.NumVertices = numVertices;
            this.Directed = directed;
        }

        public abstract void AddEdge(int v1, int v2, int weight);

        public abstract IEnumerable<int> GetAdjacentVertices(int v);

        public abstract int GetEdgeWeight(int v1, int v2);

        public abstract void Display();

        //public int NumVertices { get { return this.numVertices; } }
    }

    public class Node
    {
        private readonly int VertexId;
        private readonly HashSet<int> AdjacencySet;

        public Node(int vertexId)
        {
            this.VertexId = vertexId;
            this.AdjacencySet = new HashSet<int>();
        }

        public void AddEdge(int v)
        {
            if (this.VertexId == v)
                throw new ArgumentException("The vertex cannot be adjacent to itself");
            this.AdjacencySet.Add(v);
        }

        public HashSet<int> GetAdjacentVertices()
        {
            return this.AdjacencySet;
        }
    }

}
