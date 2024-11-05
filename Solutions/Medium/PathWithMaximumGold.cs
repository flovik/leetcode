namespace Sandbox.Solutions.Medium;

public class PathWithMaximumGold
{
    public int GetMaximumGold(int[][] grid)
    {
        var gold = 0;
        for (var i = 0; i < grid.Length; i++)
        {
            for (var j = 0; j < grid[i].Length; j++)
            {
                if (grid[i][j] == 0)
                    continue;

                var newGold = Dfs(i, j, grid, 0);
                gold = Math.Max(gold, newGold);
            }
        }

        return gold;
    }

    private int Dfs(int x, int y, int[][] grid, int gold)
    {
        if (grid[x][y] == 0)
            return 0;

        var origin = grid[x][y];
        gold += origin;
        var t = gold;
        grid[x][y] = 0; // mark as visited

        if (x > 0)
            t = Math.Max(t, Dfs(x - 1, y, grid, gold));

        if (y > 0)
            t = Math.Max(t, Dfs(x, y - 1, grid, gold));

        if (x < grid.Length - 1)
            t = Math.Max(t, Dfs(x + 1, y, grid, gold));

        if (y < grid[x].Length - 1)
            t = Math.Max(t, Dfs(x, y + 1, grid, gold));

        grid[x][y] = origin;
        return t;
    }
}