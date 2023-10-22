namespace Sandbox.Solutions.Easy;

public class MergeSortedArray
{
    public void Merge(int[] nums1, int m, int[] nums2, int n)
    {
        //start from back of main array and from back of secondary array
        //check if nums2[i] > nums1[j] put at the back of nums1
        //if nums2[i] < nums1[j], put the value of main array there

        int i = m - 1; //index first values
        int j = n - 1;
        int wholeSize = m + n - 1;
        while (i >= 0 && j >= 0)
        {
            if (nums1[i] > nums2[j])
            {
                nums1[wholeSize--] = nums1[i--];
            }
            else
            {
                nums1[wholeSize--] = nums2[j--];
            }
        }

        //nums1 exhausted, insert remaining elements from nums2
        while (j >= 0)
        {
            nums1[wholeSize--] = nums2[j--];
        }
    }
}