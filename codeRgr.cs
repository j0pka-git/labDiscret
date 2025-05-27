using System;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int m = int.Parse(Console.ReadLine());
        int[,] matrix = new int[n, n];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                matrix[i, j] = (i == j) ? 0 : int.MaxValue;
            }
        }
        for (int i = 0; i < m; i++)
        {
            string[] array = Console.ReadLine().Split();
            int from = int.Parse(array[0]) - 1; 
            int to = int.Parse(array[1]) - 1;    
            int price = int.Parse(array[2]);
            if (price < matrix[from, to])        
            {
                matrix[from, to] = price;        
            }
        }
        for (int k = 0; k < n; k++)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (matrix[i, k] != int.MaxValue &&
                        matrix[k, j] != int.MaxValue &&
                        matrix[i, j] > matrix[i, k] + matrix[k, j])
                    {
                        matrix[i, j] = matrix[i, k] + matrix[k, j];
                    }
                }
            }
        }
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (i == j) continue;
                int cost = matrix[i, j];
                Console.WriteLine($"{i + 1} {j + 1} {(cost == int.MaxValue ? -1 : cost)}");
            }
        }
    }
}
