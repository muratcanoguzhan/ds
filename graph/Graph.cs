using System;
using System.Collections.Generic;

namespace graph
{
    public class Graph
    {
        private const int TOTAL_VERTICES = 52;
        public Vertex[] Vertices;

        public int[,] AdjacencyMatrix;
        private int iVertex;

        public Graph()
        {
            Vertices = new Vertex[TOTAL_VERTICES];
            AdjacencyMatrix = new int[TOTAL_VERTICES, TOTAL_VERTICES];

            for (int x = 0; x < TOTAL_VERTICES; x++)
            {
                for (int y = 0; y < TOTAL_VERTICES; y++)
                {
                    AdjacencyMatrix[x, y] = 0;
                }
            }
            iVertex = 0;
        }

        internal void AddVertex(int index, string value, int x, int y)
        {
            Vertices[iVertex] = new Vertex(index, value, x, y);
            iVertex++;
        }

        internal void AddEdge(int startVertex, int endVertex, int weight)
        {
            AdjacencyMatrix[startVertex, endVertex] = weight;
            AdjacencyMatrix[endVertex, startVertex] = weight; //For undirected graph
        }

        internal List<string> AStar(int start, int destination)
        {
            var openVertices = new List<int>();
            var closedVertices = new List<int>();
            var unvisitedVertices = new List<int>();
            Vertex currentVertex;

            for (int i = 0; i < TOTAL_VERTICES; i++)
            {
                unvisitedVertices.Add(i);
            }

            unvisitedVertices.Remove(start);
            currentVertex = Vertices[start];

            Vertices[start].G = 0;
            Vertices[start].F = Vertices[start].G + Vertices[start].H(Vertices[destination]);

            while (currentVertex != Vertices[destination])
            {
                for (int i = 0; i < TOTAL_VERTICES; i++)
                {
                    if (AdjacencyMatrix[currentVertex.Index, i] > 0)
                    {
                        if (!closedVertices.Contains(i) && !openVertices.Contains(i))
                        {
                            unvisitedVertices.Remove(i);
                            openVertices.Add(i);
                            Vertices[i].Parent = currentVertex;

                            var g = Vertices[i].Parent.G + AdjacencyMatrix[currentVertex.Index, i];
                            var f = g + Vertices[i].H(Vertices[destination]);

                            if (Vertices[i].F == 0 || f < Vertices[i].F)
                            {
                                Vertices[i].F = f;
                                Vertices[i].G = g;
                                Vertices[i].Parent = currentVertex;
                            }
                        }
                    }
                }

                closedVertices.Add(currentVertex.Index);

                var iSmallestF = 1000;
                int iNextCurrent = 0;

                foreach (var i in openVertices)
                {
                    if (Vertices[i].F < iSmallestF)
                    {
                        iSmallestF = Vertices[i].F;
                        iNextCurrent = i;
                    }
                }

                openVertices.Remove(iNextCurrent);
                currentVertex = Vertices[iNextCurrent];
            }

            var shortestPath = new List<string>();

            var v = Vertices[destination];
            do
            {
                shortestPath.Add(v.Value);
                v = v.Parent;
            } while (v != null);

            shortestPath.Reverse();
            shortestPath.Add(currentVertex.G.ToString());

            return shortestPath;
        }
    }

    public class Vertex
    {
        public Vertex(int index, string value, int x, int y)
        {
            Index = index;
            Value = value;
            X = x;
            Y = y;
        }
        public string Value { get; set; }
        public int Index { get; set; }
        private int X;
        private int Y;
        public int G { get; set; }
        public int F { get; set; }
        public Vertex Parent { get; set; }

        public int H(Vertex destination)
        {
            // return (destination.X - X) + (destination.Y - Y);

            var eucledeanDistance = ((Math.Pow(destination.X - X, 2)) + (Math.Pow(destination.Y - Y, 2)));
            return (int)Math.Sqrt(eucledeanDistance);
        }
    }
}
