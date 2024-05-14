namespace Sandbox.Solutions.Medium;

public class LargestDivisibleSubset
{
    public IList<int> LargestDivisibleSubsetSol(int[] nums)
    {
        Array.Sort(nums);
        var dp = new int[nums.Length];
        Array.Fill(dp, 1);
        var previous = new int[nums.Length]; // stores indexes when max was changed
        dp[0] = 1;

        var max = dp[0];
        var maxIndex = 0;

        // the same as longest increasing sequence
        // at each step take Max of the current number if you can mod it to 0
        for (var i = 0; i < nums.Length; i++)
        {
            for (var j = 0; j < i; j++)
            {
                if (nums[i] % nums[j] == 0 && dp[j] + 1 > dp[i])
                {
                    dp[i] = dp[j] + 1;
                    previous[i] = j;

                    if (dp[i] > max)
                    {
                        max = dp[i];
                        maxIndex = i;
                    }
                }
            }
        }

        var result = new List<int>(max);

        while (max != 0)
        {
            result.Add(nums[maxIndex]);
            maxIndex = previous[maxIndex];
            max--;
        }

        return result;
    }

    /*
     * 1 3 6 9 81
     *
     * dp
     * 1 0 0 0 0
     * take every i until j and see if you can take % == 0 off of it
     * 3 % 1 == 0, dp[3] = 2
     * 1 2 0 0 0
     * 6 % 1, dp[6] = 2, 6 % 3 == 0, dp[6] = dp[3] + 1 = 3
     * 1 2 3 0 0
     * 9 % 6 != 0, so dp[9] = 3
     * 1 2 3 3 4
     */
}