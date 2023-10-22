namespace Sandbox.Solutions.Medium;

public class SearchInRotatedSortedArray
{
    public int Search(int[] nums, int target)
    {
        int left = 0, right = nums.Length - 1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            if (nums[mid] == target)
                return mid;

            //determine if mid is on the left side of the pivot or right side
            if (nums[left] <= nums[mid])
            {
                //here we check if pivot is on the right side, we check if from left to mid are no changes in increasing of the sequence
                if (target >= nums[left] && target < nums[mid]) //here we check if it indeed is in the left part
                    right = mid - 1;
                else
                    left = mid + 1; //then it is in the right part
            }
            else
            {
                //here we check if pivot is on the left side
                if (target > nums[mid] && target <= nums[right]) //be check for sure if it is in the right part
                    left = mid + 1;
                else
                    right = mid - 1; // then it is in the left part
            }
        }

        return -1;
    }
}