namespace Sandbox.Solutions.Medium;

public class ShortestPathInBinaryMatrix
{
    // right, up, down, left, right-up, right-down, left-up, left-down
    private readonly int[][] _directions = [[0, 1], [1, 0], [-1, 0], [0, -1], [1, 1], [-1, 1], [1, -1], [-1, -1]];

    public int ShortestPathBinaryMatrix(int[][] grid)
    {
        // top left to bottom right
        // traverse by 0s and shortest clear path (8-directional)
        if (grid[0][0] != 0)
            return -1;

        // x, y, len of path
        var n = grid.Length;
        var result = int.MaxValue;
        var queue = new Queue<(int, int, int)>(n);
        queue.Enqueue((0, 0, 1));

        while (queue.Count > 0)
        {
            var (x, y, len) = queue.Dequeue();

            if (x == n - 1 && y == n - 1)
                result = Math.Min(result, len);

            grid[x][y] = 1;

            // Explore all 8 directions.
            foreach (var direction in _directions)
            {
                var newX = x + direction[0];
                var newY = y + direction[1];

                // Check if the new position is valid and unvisited.
                if (IsValid(newX, newY, n) && grid[newX][newY] == 0)
                {
                    queue.Enqueue((newX, newY, len + 1));
                    grid[newX][newY] = 1;
                }
            }
        }

        return result == int.MaxValue ? -1 : result;

        bool IsValid(int x, int y, int n) => x >= 0 && y >= 0 && x < n && y < n;
    }
}