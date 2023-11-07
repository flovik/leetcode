namespace Sandbox.Solutions.Medium;

public class FindMinimumInRotatedArray
{
    public int FindMin(int[] nums)
    {
        // 3 4 5 1 2
        // just an observation, draw every possible solution and move left, right pointers
        int left = 0, right = nums.Length - 1;

        while (left <= right)
        {
            var mid = left + (right - left) / 2;
            if (nums[left] <= nums[mid] && nums[left] <= nums[right])
                return left;

            if (nums[left] >= nums[mid] && nums[left] > nums[right])
            {
                left++;
                right = mid;
            }
            else
                left = mid + 1;
        }

        return nums[left];
    }
}