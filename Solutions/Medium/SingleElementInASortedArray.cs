namespace Sandbox.Solutions.Medium;

public class SingleElementInASortedArray
{
    public int SingleNonDuplicate(int[] nums)
    {
        // the array is odd, because all duplicate are even + 1 single number, so the number I look for is 
        // situated in the odd part of the array after applying binary search
        var len = nums.Length;
        int left = 0, right = len - 1;

        while (left < right)
        {
            var mid = left + (right - left) / 2;

            var leftValue = mid - 1 >= 0 ? nums[mid - 1] : -1;
            var midValue = nums[mid];
            var rightValue = mid + 1 < nums.Length ? nums[mid + 1] : -1;

            // found single element
            if (leftValue != midValue && midValue != rightValue)
            {
                left = mid;
                break;
            }

            if (leftValue == midValue)
            {
                // even number of elements to the right
                if ((len - mid + 1) % 2 == 0) right = mid - 2;
                else left = mid + 1;
            }
            else
            {
                if ((len - mid) % 2 == 0) right = mid - 1;
                else left = mid + 2;
            }
        }

        return nums[left];
    }
}