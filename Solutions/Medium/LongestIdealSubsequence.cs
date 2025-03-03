namespace Sandbox.Solutions.Medium;

public class LongestIdealSubsequence
{
    public int LongestIdealString(string s, int k)
    {
        var dp = new int[26];

        for (var i = 0; i < s.Length; i++)
        {
            var ch = s[i] - 'a';

            var to = Math.Clamp(ch - k, 0, 25);
            var from = Math.Clamp(ch + k, 0, 25);

            var best = 0;

            while (to <= from)
            {
                best = Math.Max(best, dp[to]);
                to++;
            }

            dp[ch] = best + 1;
        }

        return dp.Max();
    }
}