namespace Sandbox.Solutions.Medium;

public class FindFirstAndLastPositionOfElementInSortedArray
{
    public int[] SearchRange(int[] nums, int target)
    {
        var index = BinarySearch(nums, target, 0, nums.Length - 1);

        if (index == nums.Length || nums[index] != target)
            return new[] { -1, -1 };

        // find next target value which will be the upper bound
        var rightBound = BinarySearch(nums, target + 1, index, nums.Length - 1) - 1;

        return new[] { index, rightBound };
    }

    private int BinarySearch(int[] nums, int target, int left, int right)
    {
        while (left < right)
        {
            var mid = (left + right) / 2;

            // low <= mid < high
            if (nums[mid] < target)
                left = mid + 1;
            else
                right = mid;
        }

        return left;
    }
}