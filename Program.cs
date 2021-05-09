using System;
using System.Linq;

namespace graph
{
    class Program
    {
        static void Main(string[] args)
        {
            //Dijkstra();
            AStar();
        }

        private static void AStar()
        {
            var g = new Graph();
            g.AddVertex(0, "A", 0, 8);
            g.AddVertex(1, "B", 2, 11);
            g.AddVertex(2, "C", 3, 8);
            g.AddVertex(3, "D", 4, 12);
            g.AddVertex(4, "E", 4, 4);
            g.AddVertex(5, "F", 1, 3);
            g.AddVertex(6, "G", 6, 1);
            g.AddVertex(7, "H", 7, 6);
            g.AddVertex(8, "I", 9, 5);
            g.AddVertex(9, "J", 12, 4);
            g.AddVertex(10, "K", 12, 8);
            g.AddVertex(11, "L", 12, 11);
            g.AddVertex(12, "M", 12, 14);
            g.AddVertex(13, "N", 14, 3);
            g.AddVertex(14, "O", 15, 12);
            g.AddVertex(15, "P", 16, 8);

            g.AddEdge(0, 1, 5);
            g.AddEdge(0, 2, 5);
            g.AddEdge(1, 0, 5);
            g.AddEdge(1, 2, 4);
            g.AddEdge(1, 3, 3);
            g.AddEdge(2, 0, 5);
            g.AddEdge(2, 1, 4);
            g.AddEdge(2, 3, 7);
            g.AddEdge(2, 4, 7);
            g.AddEdge(2, 7, 8);
            g.AddEdge(3, 1, 3);
            g.AddEdge(3, 2, 7);
            g.AddEdge(3, 7, 11);
            g.AddEdge(3, 10, 16);
            g.AddEdge(3, 11, 13);
            g.AddEdge(3, 12, 14);
            g.AddEdge(4, 2, 7);
            g.AddEdge(4, 5, 4);
            g.AddEdge(4, 7, 5);
            g.AddEdge(5, 4, 4);
            g.AddEdge(5, 6, 9);
            g.AddEdge(6, 5, 9);
            g.AddEdge(6, 13, 12);
            g.AddEdge(7, 2, 8);
            g.AddEdge(7, 3, 11);
            g.AddEdge(7, 4, 5);
            g.AddEdge(7, 8, 3);
            g.AddEdge(8, 7, 3);
            g.AddEdge(8, 9, 4);
            g.AddEdge(9, 8, 4);
            g.AddEdge(9, 13, 3);
            g.AddEdge(9, 15, 8);
            g.AddEdge(10, 3, 16);
            g.AddEdge(10, 11, 5);
            g.AddEdge(10, 13, 7);
            g.AddEdge(10, 15, 4);
            g.AddEdge(11, 3, 13);
            g.AddEdge(11, 10, 5);
            g.AddEdge(11, 12, 9);
            g.AddEdge(11, 14, 4);
            g.AddEdge(12, 3, 14);
            g.AddEdge(12, 11, 9);
            g.AddEdge(12, 14, 5);
            g.AddEdge(13, 6, 12);
            g.AddEdge(13, 9, 3);
            g.AddEdge(13, 10, 7);
            g.AddEdge(13, 15, 7);
            g.AddEdge(14, 11, 4);
            g.AddEdge(14, 12, 5);
            g.AddEdge(15, 9, 8);
            g.AddEdge(15, 10, 4);
            g.AddEdge(15, 13, 7);

            var stOut = g.AStar(0, 15);

            Console.WriteLine(string.Join(" ", stOut));
        }

        private static void Dijkstra()
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
