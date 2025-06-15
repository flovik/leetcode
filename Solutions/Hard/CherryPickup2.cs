namespace Sandbox.Solutions.Hard;

public class CherryPickup2
{
    private int[][][] _cache = [];
    private readonly int[] _decisions = [-1, 0, 1];

    public int CherryPickup(int[][] grid)
    {
        _cache = new int[grid.Length][][];

        for (var i = 0; i < grid.Length; i++)
        {
            _cache[i] = new int[grid[0].Length][];

            for (var j = 0; j < grid[0].Length; j++)
            {
                _cache[i][j] = new int[grid[0].Length];
                Array.Fill(_cache[i][j], -1);
            }
        }

        // move robots simultaneously row-by-row, and consider all their possibilities
        var count = Backtrack(grid, 0, 0, grid[0].Length - 1);
        return count;
    }

    private int Backtrack(int[][] grid, int row, int col1, int col2)
    {
        // out-of-bounds
        if (col1 < 0 || col2 < 0)
            return 0;

        if (col1 >= grid[0].Length || col2 >= grid[0].Length)
            return 0;

        // I don't want robots to go to the same cell
        if (col1 == col2)
            return 0;

        // last row, return current cell value
        if (row == grid.Length - 1)
            return grid[row][col1] + grid[row][col2];

        if (_cache[row][col1][col2] != -1)
            return _cache[row][col1][col2];

        var count = 0;

        // for each decision of robot1, robot2 is moved into any 3 of directions
        foreach (var r1Decision in _decisions)
        {
            foreach (var r2decision in _decisions)
            {
                var decision = Backtrack(grid, row + 1, col1 + r1Decision, col2 + r2decision);
                count = Math.Max(count, decision);
            }
        }

        return _cache[row][col1][col2] = count + grid[row][col1] + grid[row][col2];
    }
}