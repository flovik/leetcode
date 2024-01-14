namespace Sandbox.Solutions.Medium;

public class NumberOfIslandsSolution
{
    public int NumIslands(char[][] grid)
    {
        var result = 0;
        for (int i = 0; i < grid.Length; i++)
        {
            for (int j = 0; j < grid[i].Length; j++)
            {
                if (grid[i][j] == '1')
                {
                    DfsIslands(j, i);
                    result++;
                }
            }
        }

        return result;

        void DfsIslands(int x, int y)
        {
            // mark as visited
            grid[y][x] = '2';

            if (x > 0 && grid[y][x - 1] == '1')
                DfsIslands(x - 1, y);

            if (x < grid[y].Length - 1 && grid[y][x + 1] == '1')
                DfsIslands(x + 1, y);

            if (y > 0 && grid[y - 1][x] == '1')
                DfsIslands(x, y - 1);

            if (y < grid.Length - 1 && grid[y + 1][x] == '1')
                DfsIslands(x, y + 1);
        }
    }
}