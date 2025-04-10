using System;
using System.Collections.Generic;

public class Connectivity
{
    public static int FirstAlgorithm(int[][] graph)
    {
        int verticesCount = graph.Length;
        List<int> vertices = new List<int>();
        for (int i = 0; i < verticesCount; i++) vertices.Add(i);
        List<int> visitedVertices = new List<int>();
        List<List<int>> connectivityComponents = new List<List<int>>();

        if (vertices.Count > 0)
        {
            int initial = 0;
            if (vertices.Contains(initial))
            {
                vertices.Remove(initial);
                visitedVertices.Add(initial);
            }
        }

        while (vertices.Count > 0)
        {
            int i = 0;
            while (i < visitedVertices.Count)
            {
                int current = visitedVertices[i];
                for (int j = 0; j < verticesCount; j++)
                {
                    if (graph[current][j] != 0 && !visitedVertices.Contains(j))
                    {
                        visitedVertices.Add(j);
                        if (vertices.Contains(j)) vertices.Remove(j);
                    }
                }
                i++;
            }

            connectivityComponents.Add(new List<int>(visitedVertices));
            visitedVertices.Clear();

            if (vertices.Count > 0)
            {
                int nextVertex = vertices[0];
                visitedVertices.Add(nextVertex);
                vertices.Remove(nextVertex);
            }
        }
        return connectivityComponents.Count;
    }

    public static int SecondAlgorithm(int[][] graph)
    {
        int verticesCount = graph.Length;
        int[] parent = new int[verticesCount];
        for (int i = 0; i < verticesCount; i++) parent[i] = i;

        int Find(int[] parentArray, int vertex)
        {
            if (parentArray[vertex] != vertex)
            {
                parentArray[vertex] = Find(parentArray, parentArray[vertex]);
            }
            return parentArray[vertex];
        }

        void Union(int[] parentArray, int x, int y)
        {
            int rootX = Find(parentArray, x);
            int rootY = Find(parentArray, y);
            if (rootX != rootY)
            {
                parentArray[rootY] = rootX;
            }
        }

        for (int i = 0; i < verticesCount; i++)
        {
            for (int j = 0; j < verticesCount; j++)
            {
                if (graph[i][j] != 0)
                {
                    Union(parent, i, j);
                }
            }
        }

        HashSet<int> roots = new HashSet<int>();
        for (int i = 0; i < verticesCount; i++)
        {
            roots.Add(Find(parent, i));
        }
        return roots.Count;
    }

    public static void Main(string[] args)
    {
        int[][] graph1 = new int[][] {
            new int[] {0, 1, 1, 1, 1, 0, 0, 1},
            new int[] {1, 0, 0, 0, 0, 0, 0, 1},
            new int[] {0, 0, 0, 1, 0, 1, 0, 0},
            new int[] {0, 0, 1, 0, 0, 1, 0, 0},
            new int[] {0, 0, 0, 0, 0, 0, 0, 1},
            new int[] {0, 0, 1, 1, 0, 0, 0, 0},
            new int[] {0, 0, 0, 0, 0, 0, 0, 1},
            new int[] {1, 1, 0, 0, 1, 0, 1, 0}
        };

        int[][] graph2 = new int[][] {
            new int[] {0, 1, 1, 1, 0, 0, 0, 0},
            new int[] {1, 0, 1, 1, 0, 0, 0, 0},
            new int[] {1, 1, 0, 1, 0, 0, 0, 0},
            new int[] {1, 1, 1, 0, 0, 0, 0, 0},
            new int[] {0, 0, 0, 0, 0, 1, 1, 1},
            new int[] {0, 0, 0, 0, 1, 0, 1, 1},
            new int[] {0, 0, 0, 0, 1, 1, 0, 1},
            new int[] {0, 0, 0, 0, 1, 1, 1, 0}
        };

        Console.WriteLine($"число компонент связности 1 алг 1 граф = {FirstAlgorithm(graph1)}");
        Console.WriteLine($"число компонент связности 2 алг 1 граф = {SecondAlgorithm(graph1)}");
        Console.WriteLine($"число компонент связности 1 алг 2 граф = {FirstAlgorithm(graph2)}");
        Console.WriteLine($"число компонент связности 2 алг 2 граф = {SecondAlgorithm(graph2)}");
    }
}
