namespace graph
{
    public class Graph
    {
        public string[] Vertexies = { "A", "B", "C", "D", "E" };

        public int[,] AdjacencyMatrix = new int[5, 5];

        internal void AddEdge(int x, int y, int impact)
        {
            AdjacencyMatrix[x, y] = impact;
        }
    }
}
