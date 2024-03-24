using NUnit.Framework.Constraints;

namespace Sandbox.Solutions.Medium;

public class InterleavingString
{
    public bool IsInterleave(string s1, string s2, string s3)
    {
        // caching, O (m*n) DP
        // bottom up approach
        // go cell by cell and consider the possibility to create that substring out of that letters
        // make 2D table and see why it works

        if (s1.Length + s2.Length != s3.Length)
            return false;

        var dp = new bool[s1.Length + 1, s2.Length + 1];

        // nothing with nothing = nothing
        dp[s1.Length, s2.Length] = true;

        // initialize last row and last column (can you compute the s3 string out of s2 or s1 string)
        for (var i = s1.Length - 1; i >= 0 && s3[s2.Length + i] == s1[i]; i--)
        {
            dp[i, s2.Length] = true;
        }

        for (var i = s2.Length - 1; i >= 0 && s3[s1.Length + i] == s2[i]; i--)
        {
            dp[s1.Length, i] = true;
        }

        for (var i = dp.GetLength(0) - 2; i >= 0; i--)
        {
            for (var j = dp.GetLength(1) - 2; j >= 0; j--)
            {
                // second conditional means that it has been already computed and if that
                // can be used further (if true)
                if (s1[i] == s3[i + j] && dp[i + 1, j])
                    dp[i, j] = true;

                if (s2[j] == s3[i + j] && dp[i, j + 1])
                    dp[i, j] = true;
            }
        }

        return dp[0, 0];
    }
}