namespace Sandbox.Solutions.Medium;

public class NumberOfIslands
{
    public int NumIslands(char[][] grid)
    {
        //DFS the grid, change visited islands to 2
        int result = 0;
        for (int i = 0; i < grid.Length; i++)
        {
            for (int j = 0; j < grid[i].Length; j++)
            {
                if (grid[i][j] == '1')
                {
                    result++;
                    FoundIsland(grid, i, j);
                }
            }
        }
        return result;
    }

    private void FoundIsland(char[][] grid, int i, int j)
    {
        if (i < 0 || j < 0 || i >= grid.Length || j >= grid[0].Length || grid[i][j] != '1') return;
        grid[i][j] = '2';
        FoundIsland(grid, i + 1, j);
        FoundIsland(grid, i - 1, j);
        FoundIsland(grid, i, j + 1);
        FoundIsland(grid, i, j - 1);
    }
}