using System.Text;

namespace Sandbox.Solutions.Hard;

public class ShortestCommonSupersequence
{
    public string ShortestCommonSupersequenceSol(string str1, string str2)
    {
        // longest common subsequence (don't take subsequences that can be deleted, it should be continuous)

        var dp = new int[str1.Length + 1][];
        var sb = new StringBuilder();

        for (var i = 0; i < str1.Length + 1; i++)
        {
            dp[i] = new int[str2.Length + 1];
        }

        for (int i = 1; i < dp[0].Length; i++)
        {
            dp[0][i] = i;
        }

        for (int i = 1; i < dp.Length; i++)
        {
            dp[i][0] = i;
        }

        for (var i = 1; i < str1.Length + 1; i++)
        {
            for (var j = 1; j < str2.Length + 1; j++)
            {
                dp[i][j] = Math.Min(dp[i][j - 1], dp[i - 1][j]) + 1;

                if (str1[i - 1] == str2[j - 1])
                    dp[i][j] = Math.Min(dp[i][j], dp[i - 1][j - 1] + 1);
            }
        }

        // from constructed table, trace back how that LCS was constructed

        int m = dp.Length - 1, n = dp[0].Length - 1;

        while (m > 0 && n > 0)
        {
            if (str1[m - 1] == str2[n - 1])
            {
                sb.Append(str1[m - 1]);
                m--;
                n--;
            }
            else
            {
                var ch = dp[m - 1][n] > dp[m][n - 1] ? str2[--n] : str1[--m];
                sb.Append(ch);
            }
        }

        while (m > 0)
            sb.Append(str1[--m]);

        while (n > 0)
            sb.Append(str2[--n]);

        return new string(sb.ToString().Reverse().ToArray());
    }
}