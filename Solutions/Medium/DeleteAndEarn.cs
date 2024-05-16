namespace Sandbox.Solutions.Medium;

public class DeleteAndEarn
{
    public int DeleteAndEarnSol(int[] nums)
    {
        var dict = new Dictionary<int, int>(nums.Length);
        var max = 0;

        // track each number and their frequency
        foreach (var num in nums)
        {
            if (!dict.TryAdd(num, num))
                dict[num] += num;

            max = Math.Max(max, num);
        }

        if (dict.Count == 1)
            return dict[nums[0]];

        var dp = new int[max + 1];

        dp[1] = dict.GetValueOrDefault(1, 0);
        dp[2] = Math.Max(dp[0], dict.GetValueOrDefault(2, 0));

        // house robber style, pick previous or prev-previous + current
        for (int i = 2; i < dp.Length; i++)
        {
            var current = dict.GetValueOrDefault(i, 0);
            dp[i] = Math.Max(dp[i - 1], dp[i - 2] + current);
        }

        return dp[^1];
    }
}