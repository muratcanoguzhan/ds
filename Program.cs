using System;
using System.Linq;

namespace graph
{
    class Program
    {
        static void Main(string[] args)
        {
            var graph = new Graph();
            graph.AddEdge(0, 1, 6);
            graph.AddEdge(0, 3, 1);
            graph.AddEdge(1, 0, 6);
            graph.AddEdge(1, 2, 5);
            graph.AddEdge(1, 3, 2);
            graph.AddEdge(1, 4, 2);
            graph.AddEdge(2, 1, 5);
            graph.AddEdge(2, 4, 5);
            graph.AddEdge(3, 0, 1);
            graph.AddEdge(3, 1, 2);
            graph.AddEdge(3, 4, 1);
            graph.AddEdge(4, 1, 2);
            graph.AddEdge(4, 2, 5);
            graph.AddEdge(4, 3, 1);

            var pathInformation = new Dijkstra(graph.AdjacencyMatrix, 5);

            var distances = pathInformation.ShortestDistances;
            var paths = pathInformation.Paths;

            for (int i = 0; i < distances.Length; i++)
            {
                Console.WriteLine("Vertex " + i + "   Distance = " + distances[i] + "   Via Vertex " + paths[i]);
            }

        }
    }
}
