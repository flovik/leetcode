namespace Sandbox.Solutions.Medium;

public class NumMatrix
{
    private readonly int[][] dp;

    public NumMatrix(int[][] matrix)
    {
        dp = new int[matrix.Length + 1][];
        for (var i = 0; i <= matrix.Length; i++)
        {
            dp[i] = new int[matrix[0].Length + 1];
        }

        for (var i = 1; i <= matrix.Length; i++)
        {
            for (var j = 1; j <= matrix[0].Length; j++)
            {
                var currentMatrixValue = matrix[i - 1][j - 1];
                var previouslyCalculatedRowSum = dp[i - 1][j];
                var previouslyCalculatedColumnSum = dp[i][j - 1];
                var duplicateSumFromIntersectionOfRowAndColumnSums = dp[i - 1][j - 1];

                dp[i][j] = currentMatrixValue +
                           previouslyCalculatedRowSum +
                           previouslyCalculatedColumnSum -
                           duplicateSumFromIntersectionOfRowAndColumnSums;
            }
        }
    }

    public int SumRegion(int row1, int col1, int row2, int col2)
    {
        // remove the sum of previous row sum
        // remove the sum of previous column sum
        // add one value that has been subtracted double time

        // dp is by one bigger, so increment all values by one
        row1++;
        col1++;
        row2++;
        col2++;

        return dp[row2][col2] - dp[row2 - 1][col1] - dp[row1][col2 - 1] + dp[row1 - 1][col1 - 1];
    }
}