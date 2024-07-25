using Sandbox.Solutions.Easy;

namespace Sandbox.Solutions.Hard;

public class MedianOfTwoSortedArrays
{
    public double FindMedianSortedArrays(int[] nums1, int[] nums2)
    {
        // O (log (n + m)
        // find approximate location of the median and compare the elements around it

        var len1 = nums1.Length;
        var len2 = nums2.Length;

        if (len1 < len2)
            return FindMedianSortedArrays(nums2, nums1);

        if (len2 == 0)
            return EdgeCase(nums1);

        // binary search
        int left = 0, right = len1 - 1;
        var half = (len1 + len2) / 2;
        int curElement1 = 0, curElement2 = 0, nextElement1 = 0, nextElement2 = 0;

        while (left <= right)
        {
            // find middle of second array
            var mid1 = (left + right) / 2;

            // find middle of the other array by subtracting half and middle of second array
            var mid2 = half - (mid1 + 1) - 1;

            // handle out-of-bounds
            curElement1 = mid1 < 0 ? int.MinValue : nums1[mid1];
            curElement2 = mid2 < 0 ? int.MinValue : nums2[mid2];
            nextElement1 = mid1 + 1 >= len1 ? int.MaxValue : nums1[mid1 + 1];
            nextElement2 = mid2 + 1 >= len2 ? int.MaxValue : nums2[mid2 + 1];

            // partition correct
            if (curElement1 <= nextElement2 && curElement2 <= nextElement1)
                break;
            if (curElement1 > curElement2)
                right = mid1 - 1;
            else
                left = mid1 + 1;
        }

        // compare values
        // odd
        if ((len1 + len2) % 2 == 1)
            return Math.Min(nextElement1, nextElement2);

        // even
        return (Math.Max(curElement1, curElement2) + (double) Math.Min(nextElement1, nextElement2)) / 2;
    }

    private double EdgeCase(int[] nums)
    {
        if (nums.Length % 2 == 1)
            return nums[nums.Length / 2];

        return (nums[nums.Length / 2 - 1] + (double) nums[nums.Length / 2]) / 2;
    }

    #region Merge arrays

    public double FindMedianSortedArraysConcat(int[] nums1, int[] nums2)
    {
        // O (m+n) solution
        // concat two arrays into one (as in merge sort, because both arrays are sorted)
        var arr = MergeArrays(nums1, nums2);
        var length = arr.Length;

        if (length % 2 == 1)
            return arr[length / 2];

        return (arr[length / 2 - 1] + (double) arr[length / 2]) / 2;
    }

    private int[] MergeArrays(int[] nums1, int[] nums2)
    {
        var arr = new int[nums1.Length + nums2.Length];

        int index1 = 0, index2 = 0;

        while (index1 < nums1.Length && index2 < nums2.Length)
        {
            if (nums1[index1] < nums2[index2])
            {
                arr[index1 + index2] = nums1[index1];
                index1++;
            }
            else
            {
                arr[index1 + index2] = nums2[index2];
                index2++;
            }
        }

        // exhausted nums1
        while (index1 < nums1.Length)
        {
            arr[index1 + index2] = nums1[index1];
            index1++;
        }

        // exhausted nums2
        while (index2 < nums2.Length)
        {
            arr[index1 + index2] = nums2[index2];
            index2++;
        }

        return arr;
    }

    #endregion Merge arrays
}