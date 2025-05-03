namespace Sandbox.Solutions.Hard;

public class MinimumNumberOfRemovalsToMakeMountainArray
{
    public int MinimumMountainRemovals(int[] nums)
    {
        // peaks at one points and then falls down from that point
        // binary search from one point before, find peak, inverse binary search the other side? LIS?
        // iterate from left to right and from right to left to find LIS for each number, then
        // for each number take (LIS from left - numbers on left) + (LIS from right - numbers on right)

        var lisLeft = new int[nums.Length];
        var lisRight = new int[nums.Length];

        var lis = new int[nums.Length];
        Array.Fill(lis, 1);

        var index = 0;

        for (var i = 1; i < nums.Length; i++)
        {
            if (nums[i] > lis[index])
            {
                index++;
                lis[index] = nums[i];

                lisLeft[i] = index + 1;
            }
            else
            {
                var ndx = BinarySearch(lis, nums[i], 0, index);
                lis[ndx] = nums[i];

                lisLeft[i] = lisLeft[ndx];
            }
        }

        Array.Reverse(nums);
        Array.Clear(lis);

        lis[0] = nums[0];
        index = 0;

        for (var i = 1; i < nums.Length; i++)
        {
            if (nums[i] > lis[index])
            {
                index++;
                lis[index] = nums[i];

                lisRight[i] = index + 1;
            }
            else
            {
                var ndx = BinarySearch(lis, nums[i], 0, index);
                lis[ndx] = nums[i];

                lisRight[i] = lisRight[ndx];
            }
        }

        Array.Reverse(lisRight);
        var min = int.MaxValue;

        for (int i = 0; i < nums.Length; i++)
        {
            if (lisLeft[i] > 1 && lisRight[i] > 1)
            {
                var value = nums.Length - lisLeft[i] - lisRight[i] + 1;
                min = Math.Min(min, value);
            }
        }

        return min;
    }

    private static int BinarySearch(int[] nums, int target, int start, int end)
    {
        int left = start, right = end;

        while (left < right)
        {
            var mid = left + (right - left) / 2;

            if (nums[mid] == target)
                return mid;

            if (nums[mid] > target)
                right = mid;
            else
                left = mid + 1;
        }

        return left;
    }
}