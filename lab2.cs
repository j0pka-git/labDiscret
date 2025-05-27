using System;
using System.Collections.Generic;

public class Graph
{
    public static int Kruskal(int[,] g)
    {
        int n = g.GetLength(0);
        int[] p = new int[n];
        int[] r = new int[n];

        for (int i = 0; i < n; i++) p[i] = i;

        var edges = new List<(int w, int a, int b)>();

        for (int i = 0; i < n; i++)
            for (int j = i + 1; j < n; j++)
                if (g[i, j] > 0)
                    edges.Add((g[i, j], i, j));

        edges.Sort();

        int sum = 0;
        int cnt = 0;

        foreach (var e in edges)
        {
            int ra = Find(e.a, p);
            int rb = Find(e.b, p);

            if (ra != rb)
            {
                Merge(ra, rb, p, r);
                sum += e.w;
                cnt++;

                if (cnt == n - 1) break;
            }
        }

        return sum;
    }
    private static int Find(int x, int[] p)
    {
        while (p[x] != x)
        {
            p[x] = p[p[x]]; 
            x = p[x];
        }
        return x;
    }
    private static void Merge(int a, int b, int[] p, int[] r)
    {
        if (r[a] > r[b]) p[b] = a;
        else
        {
            p[a] = b;
            if (r[a] == r[b]) r[b]++;
        }
    }
    public static int Prim(int[,] g)
    {
        int n = g.GetLength(0);
        var vis = new HashSet<int> { 0 };
        int sum = 0;

        while (vis.Count < n)
        {
            int min = int.MaxValue;
            int next = -1;

            foreach (int v in vis)
                for (int i = 0; i < n; i++)
                    if (g[v, i] > 0 && !vis.Contains(i) && g[v, i] < min)
                    {
                        min = g[v, i];
                        next = i;
                    }

            if (next == -1) break;

            vis.Add(next);
            sum += min;
        }

        return sum;
    }

    public static void Main()
    {
        int[,] g =
        {
            {0, 1, 0, 1, 0},
            {1, 0, 1, 0, 1},
            {0, 1, 0, 1, 0},
            {1, 0, 1, 0, 1},
            {0, 1, 0, 1, 0}
        };

        Console.WriteLine($"крускал: {Kruskal(g)}");
        Console.WriteLine($"прима: {Prim(g)}");
    }
}
