namespace Sandbox.Solutions.Medium;

public class LongestIncreasingPathinaMatrix
{
    public int LongestIncreasingPath(int[][] matrix)
    {
        int m = matrix.Length, n = matrix[0].Length;
        var dp = new int[m, n];
        int longestPath = 0;

        for (int y = 0; y < m; y++)
        {
            for (int x = 0; x < n; x++)
            {
                Dfs(x, y);

                longestPath = Math.Max(dp[y, x], longestPath);
            }
        }

        return longestPath;

        int Dfs(int x, int y)
        {
            if (dp[y, x] != 0)
                return dp[y, x];

            int left = 0, right = 0, up = 0, down = 0;

            if (x - 1 >= 0 && matrix[y][x - 1] > matrix[y][x])
                left = Dfs(x - 1, y);

            if (y - 1 >= 0 && matrix[y - 1][x] > matrix[y][x])
                up = Dfs(x, y - 1);

            if (x + 1 < n && matrix[y][x + 1] > matrix[y][x])
                right = Dfs(x + 1, y);

            if (y + 1 < m && matrix[y + 1][x] > matrix[y][x])
                down = Dfs(x, y + 1);

            return dp[y, x] = 1 + Math.Max(Math.Max(left, right), Math.Max(up, down));
        }
    }
}