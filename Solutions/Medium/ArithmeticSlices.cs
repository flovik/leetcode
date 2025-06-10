namespace Sandbox.Solutions.Medium;

public class ArithmeticSlices
{
    public int NumberOfArithmeticSlices(int[] nums)
    {
        if (nums.Length < 3)
            return 0;

        // each number has their own sequences, when you compute difference with current number, take only the sequences
        // equal to the current difference
        var dp = new Dictionary<int, int>[nums.Length];
        var count = 0;

        for (var i = 0; i < nums.Length; i++)
        {
            dp[i] = [];
        }

        dp[1].Add(nums[1] - nums[0], 1);

        for (var i = 2; i < nums.Length; i++)
        {
            var seq = nums[i] - nums[i - 1];

            if (dp[i - 1].TryGetValue(seq, out var len))
            {
                count += len;
                dp[i].TryAdd(seq, len + 1);
            }
            else dp[i].TryAdd(seq, 1);
        }

        return count;
    }
}