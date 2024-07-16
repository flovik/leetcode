namespace Sandbox.Solutions.Medium;

public class BestTeamWithNoConflicts
{
    public int BestTeamScore(int[] scores, int[] ages)
    {
        var players = new int[scores.Length][];

        for (int i = 0; i < scores.Length; i++)
        {
            players[i] = new[] { scores[i], ages[i] };
        }

        Array.Sort(players, (a, b) => a[1] == b[1] ? a[0].CompareTo(b[0]) : a[1].CompareTo(b[1]));
        var dp = new int[players.Length];
        dp[0] = players[0][0];

        for (int i = 1; i < players.Length; i++)
        {
            var curPlayer = players[i];
            dp[i] = curPlayer[0];

            for (int j = 0; j < i; j++)
            {
                var prevPlayer = players[j];
                if (curPlayer[1] > prevPlayer[1] && curPlayer[0] < prevPlayer[0])
                    continue;

                dp[i] = Math.Max(dp[i], dp[j] + curPlayer[0]);
            }
        }

        return dp.Max();
    }
}