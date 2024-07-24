namespace Sandbox.Solutions.Hard;

public class MedianOfTwoSortedArrays
{
    //public double FindMedianSortedArrays(int[] nums1, int[] nums2)
    //{
    //    // O (log (n + m)
    //    // find approximate location of the median and compare the elements around it

    //    var len1 = nums1.Length;
    //    var len2 = nums2.Length;

    //    if (len1 > len2)
    //        return FindMedianSortedArrays(nums2, nums1);

    //    // binary search
    //    int left = 0, right = len1;

    //    // compare values around
    //}

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