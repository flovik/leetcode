namespace Sandbox.Solutions.Medium;

public class OutOfBoundaryPaths
{
    public int FindPaths(int m, int n, int maxMove, int startRow, int startColumn)
    {
        // row, column, move
        const int constant = 1_000_000_007;

        var memo = new int[m, n, maxMove + 1];

        for (var i = 0; i < m; i++)
        {
            for (var j = 0; j < n; j++)
            {
                for (int k = 0; k <= maxMove; k++)
                {
                    memo[i, j, k] = -1;
                }
            }
        }

        return Backtrack(maxMove, startRow, startColumn);

        int Backtrack(int currentMove, int row, int column)
        {
            // out of bounds
            if (row == m || column == n || row < 0 || column < 0)
                return 1;

            if (currentMove == 0)
                return 0;

            if (memo[row, column, currentMove] != -1)
                return memo[row, column, currentMove];

            return memo[row, column, currentMove] = ((Backtrack(currentMove - 1, row - 1, column) +
                                                      Backtrack(currentMove - 1, row + 1, column)) % constant +
                                                     (Backtrack(currentMove - 1, row, column + 1) +
                                                      Backtrack(currentMove - 1, row, column - 1)) % constant) % constant;
        }
    }
}