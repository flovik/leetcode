namespace Sandbox.Solutions.Medium;

public class NumberOfEnclaves
{
    private bool _isEnclave;

    public int NumEnclaves(int[][] grid)
    {
        var count = 0;
        for (var i = 0; i < grid.Length; i++)
        {
            for (var j = 0; j < grid[i].Length; j++)
            {
                if (grid[i][j] != 1)
                    continue;

                var curCount = Dfs(i, j);

                if (!_isEnclave)
                    count += curCount;

                _isEnclave = false;
            }
        }

        return count;

        int Dfs(int i, int j)
        {
            if (i == 0 || j == 0 || i == grid.Length - 1 || j == grid[i].Length - 1)
                _isEnclave = true;

            grid[i][j] = 2;

            var lands = 1;
            if (i > 0 && grid[i - 1][j] == 1)
                lands += Dfs(i - 1, j);

            if (j > 0 && grid[i][j - 1] == 1)
                lands += Dfs(i, j - 1);

            if (i < grid.Length - 1 && grid[i + 1][j] == 1)
                lands += Dfs(i + 1, j);

            if (j < grid[i].Length - 1 && grid[i][j + 1] == 1)
                lands += Dfs(i, j + 1);

            return lands;
        }
    }
}