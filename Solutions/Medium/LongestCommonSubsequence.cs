namespace Sandbox.Solutions.Medium;

public class LongestCommonSubsequence
{
    public int LongestCommonSubsequenceSol(string text1, string text2)
    {
        // if two first characters match, then we can divide the problem in a sub problem of
        // sub sequences of remainder of strings of both strings
        // !!! dynamic programming is all about finding the sub problem
        // 2D grid is commonly used to solve DP problems
        // we can put a value in each cell

        // it's BOTTOM UP, because we go backwards from the end of the matrix to the start of the matrix
        // look at the matrix below to understand what is happening
        // basically we move from the bottom-right corner up to upper-left
        // but we take each cell and compute them
        // bound are set to 0

        // if characters match, set currentCell = 1 + dp[i + 1, j + 1], the diagonal letter
        // if they don't take the Math.Max(dp[i + 1, j], dp[i, j + 1]
        var dp = new int[text1.Length + 1, text2.Length + 1];

        for (var i = dp.GetLength(0) - 2; i >= 0; i--)
        {
            for (var j = dp.GetLength(1) - 2; j >= 0; j--)
            {
                if (text1[i] == text2[j])
                    dp[i, j] = 1 + dp[i + 1, j + 1];
                else
                    dp[i, j] = Math.Max(dp[i + 1, j], dp[i, j + 1]);
            }
        }

        return dp[0, 0];
    }

    /*       j
     *     a c e        b b b a c
     *   a 3 2 1 0    a 3 2 2 2 1 0
     *   b 2 2 1 0    c 3 2 1 1 1 0
     * i c 2 2 1 0    b 3 2 1 0 0 0
     *   d 1 1 1 0    b 2 2 1 0 0 0
     *   e 1 1 1 0    b 1 1 1 0 0 0
     *   0 0 0 0 0    0 0 0 0 0 0 0
     */
}