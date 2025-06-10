namespace Sandbox.Solutions.Hard;

public class ArithmeticSlices2
{
    public int NumberOfArithmeticSlices(int[] nums)
    {
        if (nums.Length < 3)
            return 0;

        // each number has their own sequences, when you compute difference with current number, take only the sequences
        // equal to the current difference
        var dp = new Dictionary<long, int>[nums.Length];
        var count = 0;

        for (var i = 0; i < nums.Length; i++)
        {
            dp[i] = [];
        }

        for (var i = 1; i < nums.Length; i++)
        {
            for (var j = 0; j < i; j++)
            {
                var seq = (long)nums[i] - nums[j];

                if (dp[j].TryGetValue(seq, out var len))
                {
                    count += len;
                    dp[i].TryAdd(seq, 0);
                    dp[i][seq] += len + 1;
                }
                // we should accumulate previous subsequences too
                else
                {
                    dp[i].TryAdd(seq, 0);
                    dp[i][seq]++;
                }
            }
        }

        return count;
    }
}