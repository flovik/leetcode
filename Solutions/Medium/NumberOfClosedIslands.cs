namespace Sandbox.Solutions.Medium;

public class NumberOfClosedIslands
{
    public int ClosedIsland(int[][] grid)
    {
        // 0 - land, 1 - water
        // if land touches out-of-bounds - not a valid answer
        // all must return true

        var count = 0;
        for (var i = 0; i < grid.Length; i++)
        {
            for (var j = 0; j < grid[i].Length; j++)
            {
                if (grid[i][j] == 0 && !Dfs(i, j, grid))
                    count++;
            }
        }

        return count;
    }

    private bool Dfs(int x, int y, int[][] grid)
    {
        // mark current node as visited
        // normally we shouldn't change input array!
        grid[x][y] = 2;

        if (x == 0 || y == 0 || x == grid.Length - 1 || y == grid[x].Length - 1)
            return true;

        var result = false;

        if (grid[x - 1][y] == 0)
            result = Dfs(x - 1, y, grid) || result;

        if (grid[x + 1][y] == 0)
            result = Dfs(x + 1, y, grid) || result;

        if (grid[x][y + 1] == 0)
            result = Dfs(x, y + 1, grid) || result;

        if (grid[x][y - 1] == 0)
            result = Dfs(x, y - 1, grid) || result;

        return result;
    }
}