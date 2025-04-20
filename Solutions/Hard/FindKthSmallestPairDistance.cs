namespace Sandbox.Solutions.Hard;

public class FindKthSmallestPairDistance
{
    public int SmallestDistancePair(int[] nums, int k)
    {
        Array.Sort(nums);

        // how many pairs can we form when distance equals X?
        // binary search + sliding window
        // [10, 20, 30, 40, 50]
        // range is from 0..40
        // mid is 20, how many pairs can we form when distance equals X? 7 (10, 20), (10, 30), (20, 30), (20, 40), (30, 40), (30, 50), (40, 50) 
        // move right, 0..20, mid is 10, how many pairs? 4, not enough, then move left
        // 11..20, again 4 pairs, move, again 4 pairs
        // 16..20, 18..20, 20..20

        // lower bound is zero, higher bound is diff between max and min in sorted array
        int left = 0, right = nums[^1] - nums[0];

        while (left < right)
        {
            var mid = (left + right) / 2;

            if (NumberOfPairsSmallerThanOrEqualToK(mid, nums, k))
                left = mid + 1;
            else
                right = mid;
        }

        return left;
    }

    private bool NumberOfPairsSmallerThanOrEqualToK(int midpoint, int[] nums, int k)
    {
        // sliding window to count pairs with distances less than or equal to midpoint
        // as long as the distance between right and left is within allowed range, move right
        // once we find a distance greater than midpoint, we know that all elements between left and right
        // form valid pairs with the element at left
        // add this to count and move left forward
        int left = 0, right = 0;

        var count = 0;

        while (right < nums.Length)
        {
            while (nums[right] - nums[left] > midpoint)
                left++;

            count += right - left;
            right++;
        }

        return count < k;
    }
}