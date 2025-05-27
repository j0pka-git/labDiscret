using System;

class World
{
    static void Main()
    {
        float infinity = float.PositiveInfinity;
        float[,] m = {
            {0, 2, infinity, 4, 14},
            {2, 0, 6, 8, infinity},
            {3, infinity, 0, 5, 6},
            {infinity, 6, 5, 0, 9},
            {7, 8, 7, 2, 0}
        };
        for (int k = 0; k < 5; k++)
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                    if (m[i, k] != infinity && m[k, j] != infinity)
                        if (m[i, j] > m[i, k] + m[k, j])
                            m[i, j] = m[i, k] + m[k, j];
        bool hasNegativeCycle = true;
        for (int i = 0; i < 5; i++)
            if (m[i, i] != 0) hasNegativeCycle = false;
        if (hasNegativeCycle)
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                    Console.Write($"{m[i, j],7}      ");
                Console.WriteLine();
            }
        }
        else Console.WriteLine("есть цикл с отрицательным весом");
        
    }
}
