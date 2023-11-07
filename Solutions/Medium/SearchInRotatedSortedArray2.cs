namespace Sandbox.Solutions.Medium;

public class SearchInRotatedSortedArray2
{
    public int Search(int[] nums, int target)
    {
        if (nums.Length == 1)
            return nums[0] == target ? 0 : -1;

        int left = 0, right = nums.Length - 1;

        while (left <= right)
        {
            var mid = left + (right - left) / 2;

            if (nums[mid] == target)
                return mid;

            // increasing (no need to find pivot)
            if (nums[mid] >= nums[left] && nums[mid] <= nums[right])
            {
                if (target < nums[mid])
                    right = mid - 1;
                else
                    left = mid + 1;
            }

            // pivot on the left
            else if (nums[left] > nums[mid] && nums[mid] < nums[right])
            {
                // if target is still on the left
                if (target < nums[mid] || target > nums[mid] && target > nums[right])
                    right = mid - 1;
                else
                    left = mid + 1;
            }

            // pivot on the right
            else
            {
                if (target < nums[mid] && target >= nums[left])
                    right = mid - 1;
                else
                    left = mid + 1;
            }
        }

        return -1;
    }

    // public int Search(int[] nums, int target)
    // {
    //     if (nums.Length == 1)
    //         return nums[0] == target ? 0 : -1;
    //
    //     int left = 0, right = nums.Length - 1;
    //
    //     // find minimum element using binary search
    //     while (left < right)
    //     {
    //         var mid = left + (right - left) / 2;
    //         if (nums[left] <= nums[mid] && nums[left] <= nums[right])
    //             break;
    //
    //         if (nums[left] >= nums[mid] && nums[left] > nums[right])
    //         {
    //             left++;
    //             right = mid;
    //         }
    //         else
    //             left = mid + 1;
    //     }
    //     // now left is the pivot
    //     // search right part of the pivot
    //
    //     return 1;
    // }

    // private int BinarySearch(int[] nums, int target)
    // {
    //     int left = 0, right = nums.Length - 1;
    //     while (left <= right)
    //     {
    //         var mid = left + (right - left) / 2;
    //         if (nums[mid] == target)
    //             return mid;
    //
    //         if (nums[mid] > target)
    //             right = mid - 1;
    //         else
    //             left = mid + 1;
    //     }
    //
    //     return -1;
    // }
}