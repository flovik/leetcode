using NUnit.Framework;

namespace Sandbox.Solutions.Medium;

public class AsFarFromLandAsPossible
{
    private readonly int[][] _directions = [[0, 1], [1, 0], [0, -1], [-1, 0]];

    public int MaxDistance(int[][] grid)
    {
        var queue = new Queue<(int, int, int)>();
        var visited = new bool[grid.Length][];

        for (int i = 0; i < grid.Length; i++)
        {
            visited[i] = new bool[grid[i].Length];
        }

        for (var i = 0; i < grid.Length; i++)
        {
            for (var j = 0; j < grid[i].Length; j++)
            {
                if (grid[i][j] != 1)
                    continue;

                queue.Enqueue((i, j, 0));
            }
        }

        // BFS from all lands
        var max = int.MinValue;
        while (queue.Count > 0)
        {
            var (x, y, moves) = queue.Dequeue();

            foreach (var direction in _directions)
            {
                var x1 = x + direction[0];
                var y1 = y + direction[1];

                if (!IsValid(x1, y1, grid, visited))
                    continue;

                var distance = GetDistance(x1, y1, x, y);
                max = Math.Max(max, distance + moves);

                visited[x1][y1] = true;
                queue.Enqueue((x1, y1, moves + 1));
            }
        }

        return max == int.MinValue ? -1 : max;
    }

    private static int GetDistance(int x0, int y0, int x1, int y1) => Math.Abs(x0 - x1) + Math.Abs(y0 - y1);

    private static bool IsValid(int x, int y, int[][] grid, bool[][] visited) =>
        x >= 0 && y >= 0 && x <= grid.Length - 1 && y <= grid.Length - 1 && grid[x][y] == 0 && !visited[x][y];
}