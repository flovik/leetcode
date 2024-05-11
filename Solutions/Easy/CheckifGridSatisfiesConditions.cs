namespace Sandbox.Solutions.Easy;

public class CheckifGridSatisfiesConditions
{
    public bool SatisfiesConditions(int[][] grid)
    {
        for (int i = 0; i < grid.Length; i++)
        {
            for (int j = 0; j < grid[i].Length; j++)
            {
                if (i != grid.Length - 1 && grid[i][j] != grid[i + 1][j])
                    return false;

                if (j != grid[i].Length - 1 && grid[i][j] == grid[i][j + 1])
                    return false;
            }
        }

        return true;
    }
}