using System;

namespace Sandbox.Solutions.Medium;

public class KthLargestElementInAnArray
{
    public int FindKthLargest(int[] nums, int k)
    {
        // sorting, heap solutions
        // quickselect

        // similar to quicksort
        // we take the whole array and partition into 2 parts
        // the left part is less than the right part of the array

        // randomly pick a pivot (rigtmost), the pivot decides what goes in the left half and what goes into the right half
        // start at the beginning and make sure to place the lower values to the left of pivot
        // we have a pivot pointer, that indicates when we found a value that is less than pivot
        // the elements higher than the pivot remain in the same spot and the pivot index stays the same
        // when we get to the pivot (rightmost in our case), insert the elements in the remaining slots then swap last element with pivot element
        // always swap the elements with pivot index and current number, in that case the elements will be put in their natural order

        // when everything is arranged, we look at the value of 'length - k', if the value is less than pivot index, then the target element is in the right side of the pivot,
        // if it is more than pivot, the target is in the left, and if it is equal to pivot index, that is the target value
        // recursively partition the rest of the arrays based on that conditions
        int start = 0, end = nums.Length - 1, largestElement = nums.Length - k;
        // range of numbers to search in the partition
        while (start < end)
        {
            // partition the array and find the pivot index
            int pivotIndex = Partition(nums, start, end);
            // if pivot is less than largest, largest is in the right part
            if (pivotIndex < largestElement) start = pivotIndex + 1;
            else if (pivotIndex > largestElement) end = pivotIndex - 1;
            else return nums[pivotIndex];
        }

        return nums[start];
    }

    private static int Partition(int[] nums, int start, int end)
    {
        // pivot is placed at the start (can be changed to end)
        int pivotIndex = start;
        // start and end move towards each other
        while (start <= end)
        {
            // move start while numbers are smaller than the pivot
            while (start <= end && nums[start] <= nums[pivotIndex]) start++;
            // move end while numbers are bigger than the pivot
            while (start <= end && nums[end] > nums[pivotIndex]) end--;
            // if start is bigger than end, then current pivot is (here we are sure the array is partitioned correctly)
            if (start > end) break;
            // found a number that stopped move of the pivot (smaller than the pivot in the nums[end] while loop or nums[start] while loop)
            (nums[start], nums[end]) = (nums[end], nums[start]);
        }

        // swap pivotIndex with end, because all start numbers are smaller than the pivot
        (nums[end], nums[pivotIndex]) = (nums[pivotIndex], nums[end]);
        return end;
    }
}