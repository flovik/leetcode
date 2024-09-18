namespace Sandbox.Solutions.Medium;

public class FindPeakElement
{
    public int FindPeakElementSol(int[] nums)
    {
        if (nums.Length == 1)
            return 0;

        if (nums[0] > nums[1])
            return 0;

        if (nums[^1] > nums[^2])
            return nums.Length - 1;

        int left = 1, right = nums.Length - 2;
        while (left < right)
        {
            var mid = (left + right) / 2;

            if (nums[mid] > nums[mid - 1] && nums[mid] > nums[mid + 1])
                return mid;

            if (nums[mid + 1] > nums[mid])
                left = mid + 1;
            else
                right = mid - 1;
        }

        return left;
    }
}