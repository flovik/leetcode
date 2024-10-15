namespace Sandbox.Solutions.Medium;

public class CountSubIslands
{
    public int CountSubIslandsSol(int[][] grid1, int[][] grid2)
    {
        // ALL cells of a sub-island must be in grid1 island
        var count = 0;
        var result = true;

        for (int i = 0; i < grid1.Length; i++)
        {
            for (int j = 0; j < grid1[i].Length; j++)
            {
                // both should be 1 to start checking
                if (grid2[i][j] == 1)
                {
                    result = true;
                    CountIsland(i, j, grid1, grid2);

                    if (result)
                        count++;
                }
            }
        }

        return count;

        void CountIsland(int i, int j, int[][] grid1, int[][] grid2)
        {
            if (i == -1 || j == -1 || i == grid1.Length || j == grid1[i].Length)
                return;

            if (grid2[i][j] != 1)
                return;

            if (grid1[i][j] == 0)
            {
                result = false;
                return;
            }

            grid2[i][j] = 0;

            CountIsland(i - 1, j, grid1, grid2);
            CountIsland(i, j - 1, grid1, grid2);
            CountIsland(i + 1, j, grid1, grid2);
            CountIsland(i, j + 1, grid1, grid2);
        }
    }
}