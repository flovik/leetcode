namespace Sandbox.Solutions.Easy;

public class BinarySearch
{
    public int Search(int[] nums, int target)
    {
        if (nums.Length == 1 && nums[0] == target)
            return 0;

        int left = 0, right = nums.Length - 1;
        while (left <= right)
        {
            var mid = (left + right) / 2;
            if (nums[mid] == target)
                return mid;
            if (nums[mid] < target)
                left = mid + 1;
            else
                right = mid - 1;
        }

        return -1;
    }
}