namespace Sandbox.Solutions.Medium;
public class MaximumBeautyOfAnArrayAfterApplyingOperation
{
    public int MaximumBeauty(int[] nums, int k)
    {
        Array.Sort(nums);
        var len = 0;
        int left = 0, right = 0;

        while (right < nums.Length)
        {
            while (nums[right] - nums[left] > 2 * k)
                left++;

            len = Math.Max(len, right - left + 1);
            right++;
        }

        return len;
    }
}
