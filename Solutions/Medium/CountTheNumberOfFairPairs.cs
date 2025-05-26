namespace Sandbox.Solutions.Medium;

public class CountTheNumberOfFairPairs
{
    public long CountFairPairs(int[] nums, int lower, int upper)
    {
        long count = 0;

        Array.Sort(nums);

        for (int i = 0; i < nums.Length; i++)
        {
            var left = BinarySearch(nums, lower - nums[i], i + 1);
            var right = BinarySearch(nums, upper - nums[i] + 1, i + 1) - 1;

            if (left <= right)
                count += right - left + 1;
        }

        return count;
    }

    private int BinarySearch(int[] nums, int target, int start)
    {
        int left = start, right = nums.Length;

        while (left < right)
        {
            var mid = left + (right - left) / 2;

            if (nums[mid] >= target)
                right = mid;
            else
                left = mid + 1;
        }

        return left;
    }
}