using System;
using System.Collections.Generic;

class lab7
{
    static int? FindShortestPath(int[][] grid)
    {
        Tuple<int, int> startPoint = null, targetPoint = null;

        for (int row = 0; row < grid.Length; row++)
        {
            for (int col = 0; col < grid[row].Length; col++)
            {
                if (grid[row][col] == -2) startPoint = Tuple.Create(row, col);
                if (grid[row][col] == -3) targetPoint = Tuple.Create(row, col);
            }
        }

        if (startPoint == null || targetPoint == null) return null;

        Queue<Tuple<int, int>> explorationQueue = new Queue<Tuple<int, int>>();
        explorationQueue.Enqueue(startPoint);
        grid[startPoint.Item1][startPoint.Item2] = 1;

        (int, int)[] movementDirections = { (-1, 0), (1, 0), (0, -1), (0, 1) };

        while (explorationQueue.Count > 0)
        {
            var (currentX, currentY) = explorationQueue.Dequeue();

            if (currentX == targetPoint.Item1 && currentY == targetPoint.Item2)
                return grid[currentX][currentY] - 1;

            foreach (var (dx, dy) in movementDirections)
            {
                int newX = currentX + dx;
                int newY = currentY + dy;

                if (newX >= 0 && newX < grid.Length &&
                    newY >= 0 && newY < grid[newX].Length)
                {
                    if (grid[newX][newY] == 0 || grid[newX][newY] == -3)
                    {
                        grid[newX][newY] = grid[currentX][currentY] + 1;
                        explorationQueue.Enqueue(Tuple.Create(newX, newY));
                    }
                }
            }
        }

        return null;
    }

    static void Main()
    {
        Console.Write("Укажите размер квадратной матрицы: ");
        int size = int.Parse(Console.ReadLine());

        Console.WriteLine("\nВведите построчно элементы матрицы:");
        Console.WriteLine("Обозначения:");
        Console.WriteLine("  -1 — препятствие (непроходимо)");
        Console.WriteLine("  -2 — начальная точка");
        Console.WriteLine("  -3 — целевая точка");
        Console.WriteLine("   0 — доступная ячейка\n");

        int[][] gridData = new int[size][];
        for (int i = 0; i < size; i++)
        {
            Console.Write($"Строка {i + 1}: ");
            gridData[i] = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        }

        var result = FindShortestPath(gridData);

        Console.WriteLine(result.HasValue
            ? $"\nМинимальное расстояние до цели: {result}"
            : "\nМаршрут отсутствует");
    }
}
