namespace Sandbox.Solutions.Medium;

public class ShortestBridge
{
    public int ShortestBridgeSol(int[][] grid)
    {
        var n = grid.Length;
        var flips = int.MaxValue;
        var newGrid = new int[n][];

        for (int i = 0; i < n; i++)
        {
            newGrid[i] = new int[n];
            Array.Copy(grid[i], newGrid[i], n);
        }

        // x, y, flips
        var queue = new Queue<(int, int, int)>(n * n);
        var first = false;
        for (var i = 0; i < n && !first; i++)
        {
            for (var j = 0; j < n && !first; j++)
            {
                if (newGrid[i][j] != 1)
                    continue;

                Dfs(i, j, newGrid, queue);
                first = true;
            }
        }

        while (queue.Count > 0)
        {
            var (x, y, flip) = queue.Dequeue();

            if (x > 0)
                CheckPoint(x - 1, y, flip);
            if (y > 0)
                CheckPoint(x, y - 1, flip);
            if (x < n - 1)
                CheckPoint(x + 1, y, flip);
            if (y < n - 1)
                CheckPoint(x, y + 1, flip);
        }

        return flips;

        void CheckPoint(int x, int y, int flip)
        {
            if (newGrid[x][y] == 1)
                flips = Math.Min(flips, flip);

            if (newGrid[x][y] == 0)
            {
                newGrid[x][y] = Math.Min(newGrid[x][y], flip);
                queue.Enqueue((x, y, flip + 1));
                newGrid[x][y] = -1;
            }
        }
    }

    private void Dfs(int x, int y, int[][] grid, Queue<(int, int, int)> queue)
    {
        // out-of-bounds
        if (x == -1 || y == -1 || x == grid.Length || y == grid[0].Length)
            return;

        // visited or water
        if (grid[x][y] == -1 || grid[x][y] == 0)
            return;

        // save point of first island
        queue.Enqueue((x, y, 0));
        grid[x][y] = -1;

        Dfs(x - 1, y, grid, queue);
        Dfs(x, y - 1, grid, queue);
        Dfs(x + 1, y, grid, queue);
        Dfs(x, y + 1, grid, queue);
    }
}