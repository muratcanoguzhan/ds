using System;
using System.Collections.Generic;

namespace graph
{
    public class Dijkstra
    {
        public double[] aShortestDistances { get; set; }
        public double[] aPreviousVertices { get; set; }
        public List<int> unvisitedVertices = new List<int>();
        public double[] ShortestDistances { get { return aShortestDistances; } }
        public double[] Paths { get { return aPreviousVertices; } }
        public Dijkstra(int[,] adjacencyMatrix, int totalVerticesCount)
        {
            aShortestDistances = new double[totalVerticesCount];
            aPreviousVertices = new double[totalVerticesCount];

            for (int i = 0; i < totalVerticesCount; i++)
            {
                unvisitedVertices.Add(i);
                aShortestDistances[i] = Double.PositiveInfinity;
            }
            aShortestDistances[0] = 0;

            while (unvisitedVertices.Count > 0)
            {
                int iCurrentVertex = GetNextVertex();

                for (int i = 0; i < totalVerticesCount; i++)
                {
                    if (adjacencyMatrix[iCurrentVertex, i] > 0)
                    {
                        if (aShortestDistances[i] > aShortestDistances[iCurrentVertex] + adjacencyMatrix[iCurrentVertex, i])
                        {
                            aShortestDistances[i] = aShortestDistances[iCurrentVertex] + adjacencyMatrix[iCurrentVertex, i];

                            aPreviousVertices[i] = iCurrentVertex;
                        }
                    }
                }
            }
        }

        private int GetNextVertex()
        {
            var smallestKnownDistance = double.PositiveInfinity;
            var vertex = -1;

            foreach (var value in unvisitedVertices)
            {
                if (aShortestDistances[value] <= smallestKnownDistance)
                {
                    smallestKnownDistance = aShortestDistances[value];
                    vertex = value;
                }
            }

            unvisitedVertices.Remove(vertex);

            return vertex;
        }
    }
}
