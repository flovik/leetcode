namespace Sandbox.Solutions.Medium;

public class MinimumSizeSubarraySum
{
    public int MinSubArrayLen(int target, int[] nums)
    {
        // sliding window
        var result = int.MaxValue;
        var sum = 0;

        // left and right pointers, when right pointer gets out-of-bounds, we can finish
        for (int left = 0, right = 0; right < nums.Length; right++)
        {
            sum += nums[right];

            while (sum >= target)
            {
                result = Math.Min(result, right - left + 1);
                sum -= nums[left];
                left++;
            }
        }

        return result == int.MaxValue ? 0 : result;
    }
}