namespace Sandbox.Solutions.Medium;

public class MaximumSubarray
{
    public int MaxSubArray(int[] nums)
    {
        // kadane's algorithm
        var localMax = nums[0];
        var max = nums[0];

        for (var i = 1; i < nums.Length; i++)
        {
            localMax = Math.Max(nums[i], nums[i] + localMax);
            max = Math.Max(max, localMax);
        }

        return max;
    }
}