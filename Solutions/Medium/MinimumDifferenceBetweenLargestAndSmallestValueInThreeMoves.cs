namespace Sandbox.Solutions.Medium;

public class MinimumDifferenceBetweenLargestAndSmallestValueInThreeMoves
{
    public int MinDifference(int[] nums)
    {
        if (nums.Length <= 4) return 0;

        // min difference between min and max in nums, at most 3 moves
        Array.Sort(nums);

        // get min and max in the remaining window of sorted numbers, when 3 are removed
        var windowLength = nums.Length - 3;

        int left = 0, right = windowLength - 1;
        var min = int.MaxValue;

        while (right < nums.Length)
        {
            min = Math.Min(min, nums[right] - nums[left]);

            left++;
            right++;
        }

        return min;
    }
}