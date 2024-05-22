namespace Sandbox.Solutions.Medium;

public class CombinationSum4
{
    public int CombinationSum4Sol(int[] nums, int target)
    {
        var dp = new int[target + 1];
        dp[0] = 1;
        Array.Sort(nums);

        for (var i = 1; i <= target; i++)
        {
            foreach (var num in nums)
            {
                if (i < num)
                    continue;

                dp[i] += dp[i - num];
            }
        }

        return dp[target];
    }
}