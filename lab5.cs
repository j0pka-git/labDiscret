using System;

class lab5
{
    static void Main()
    {
        float inf = float.MaxValue;
        float[,] m = new float[,]
        {
            {0, 2, inf, 4, 14},
            {2, 0, 6, 8, inf},
            {3, inf, 0, 5, 6},
            {inf, 6, 5, 0, 9},
            {7, 8, 7, 2, 0}
        };

        int start = 1;
        float[] d = new float[5];
        Array.Fill(d, inf);
        d[start - 1] = 0;

        bool hasNegativeCycle = false;

        for (int i = 0; i < 5; i++)
        {
            bool updated = false;
            for (int a = 0; a < 5; a++)
            {
                for (int b = 0; b < 5; b++)
                {
                    if (m[a, b] != inf && d[b] != inf && d[a] > d[b] + m[a, b])
                    {
                        d[a] = d[b] + m[a, b];
                        updated = true;
                    }
                }
            }
            hasNegativeCycle = updated;
        }

        if (hasNegativeCycle)
        {
            Console.WriteLine("Есть контур отрицательного веса");
        }
        else
        {
            Console.WriteLine("Матрица смежности:");
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Console.Write(m[i, j] == inf ? "inf" : m[i, j].ToString());
                    Console.Write("\t");
                }
                Console.WriteLine();
            }
        }
    }
}
