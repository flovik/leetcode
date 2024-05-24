namespace Sandbox.Solutions.Medium;

public class MinimumCostForTickets
{
    public int MincostTickets(int[] days, int[] costs)
    {
        var last = days[^1];
        var dp = new int[last + 1];
        Array.Fill(dp, int.MaxValue);
        dp[0] = 0;

        var currentDaysIndex = 0;
        for (var i = 1; i <= last; i++)
        {
            if (i != days[currentDaysIndex])
            {
                dp[i] = dp[i - 1];
                continue;
            }

            for (var j = 0; j < costs.Length; j++)
            {
                var index = j switch
                {
                    0 => Math.Clamp(i - 1, 0, last),
                    1 => Math.Clamp(i - 7, 0, last),
                    2 => Math.Clamp(i - 30, 0, last),
                    _ => 0
                };

                dp[i] = Math.Min(dp[i], dp[index] + costs[j]);
            }

            currentDaysIndex++;
        }

        return dp[last];
    }
}