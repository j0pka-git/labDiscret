using System;
class lab4
  
{
    static void Main()
    {
        float inf = float.MaxValue;
        float[,] matrix = new float[,] 
        {
            {inf, 2, inf, 4, 14},
            {2, inf, 6, 8, inf},
            {3, inf, inf, 5, 6},
            {inf, 6, 5, inf, 9},
            {7, 8, 7, 2, inf}
        };
        
        int start = 1;
        int finish = 4;
        int n = matrix.GetLength(0);
        
        float[] d = new float[n];
        bool[] notUsed = new bool[n];

      
        float[] localD = new float[n];
        
        Array.Fill(d, inf);
        Array.Fill(notUsed, true);
        Array.Fill(localD, inf);
        
        d[start - 1] = 0;
        notUsed[start - 1] = false;
        int v = start - 1;

        while (v != finish - 1)
        {
            for (int u = 0; u < n; u++)
            {
                if (notUsed[u])
                {
                    localD[u] = Math.Min(localD[u], d[v] + matrix[v, u]);
                }
            }
            float minVal = float.MaxValue;
            int minIndex = -1;
            for (int i = 0; i < n; i++)
            {
                if (localD[i] < minVal)
                {
                    minVal = localD[i];
                    minIndex = i;
                }
            }
            
            v = minIndex;
            d[v] = minVal;
            localD[v] = inf;
            notUsed[v] = false;
        }

        Console.WriteLine($"Кратчайший путь: {d[finish - 1]}");
    }
}
