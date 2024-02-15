namespace Sandbox.Solutions.Medium;

public class UniquePathss
{
    public int UniquePaths(int m, int n)
    {
        var dp = new int[m, n];

        // initialize first row and first column
        for (var i = 0; i < n; i++)
        {
            dp[0, i] = 1;
        }

        for (var i = 0; i < m; i++)
        {
            dp[i, 0] = 1;
        }

        // take the left and upper cells, as they've been computed all the paths for them
        // compute sum of those cells
        for (var i = 1; i < m; i++)
        {
            for (var j = 1; j < n; j++)
            {
                dp[i, j] = dp[i - 1, j] + dp[i, j - 1];
            }
        }

        return dp[m - 1, n - 1];
    }
}