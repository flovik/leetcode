namespace Sandbox.Solutions.Hard;

public class SplitArrayLargestSum
{
    public int SplitArray(int[] nums, int k)
    {
        // search in range of the nums prefix sum and find the sum that would fit into K sub-arrays
        int left = nums[0], right = nums.Sum(), result = int.MaxValue;

        while (left <= right)
        {
            var mid = left + (right - left) / 2;

            var (canFit, largestSum) = CanFit(mid, nums, k);
            if (canFit)
            {
                result = Math.Min(result, largestSum);
                right = mid;
            }
            else
                left = mid + 1;
        }

        return result;
    }

    private (bool, int) CanFit(int target, int[] nums, int k)
    {
        int count = 1, currentTarget = 0, result = 0;

        foreach (var num in nums)
        {
            if (currentTarget + num > target)
            {
                result = Math.Max(result, currentTarget);
                currentTarget = 0;
                count++;
            }

            currentTarget += num;
        }

        result = Math.Max(result, currentTarget);
        return (count <= k, result);
    }
}