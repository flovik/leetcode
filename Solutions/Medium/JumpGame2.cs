namespace Sandbox.Solutions.Medium;

public class JumpGame2
{
    public int Jump(int[] nums)
    {
        var result = 0;
        var currentMax = 0;
        var nextMax = 0;
        var n = nums.Length;

        // keep track of the maximum reachable index from the current position and the next position
        for (var i = 0; i < n - 1; i++)
        {
            nextMax = Math.Max(nextMax, i + nums[i]);

            if (i != currentMax)
                continue;

            result++;
            currentMax = nextMax;
        }

        return result;
    }
}