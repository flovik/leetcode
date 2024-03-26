namespace Sandbox.Solutions.Medium;

public class EditDistance
{
    public int MinDistance(string word1, string word2)
    {
        var dp = new int[word1.Length + 1, word2.Length + 1];

        // 2DP problem, as LCS, draw 2d grid with both words and remember how to compute
        // base cases

        for (int i = 0; i <= word1.Length; i++)
            dp[word1.Length - i, word2.Length] = i;

        for (int i = 0; i <= word2.Length; i++)
            dp[word1.Length, word2.Length - i] = i;

        // the interesting part is here
        // you have 3 operations insert [i, j+ 1], delete [i + 1, j], replace [i + 1, j + 1]
        // if the characters match, pick [i + 1, j + 1]
        // else minimum from any of 3 operations + 1, because we need to perform one operation

        for (int i = dp.GetLength(0) - 2; i >= 0; i--)
        {
            for (int j = dp.GetLength(1) - 2; j >= 0; j--)
            {
                if (word1[i] == word2[j])
                    dp[i, j] = dp[i + 1, j + 1];
                else
                    dp[i, j] = 1 + Math.Min(Math.Min(dp[i + 1, j], dp[i, j + 1]), dp[i + 1, j + 1]);
            }
        }

        return dp[0, 0];
    }
}