namespace Sandbox.Topics.Sorting;

// divide and conquer
// makes in place
// O(nlogn)
// worst case O(n^2) - decreasing order of elements
public class QuickSort
{
    // steps
    // pick an element random (I'll pick last element)
    // index at start, walk entire array from pivot
    // element that is smaller than pivot, put at start
    // put smaller numbers than pivot to the left, bigger to right
    // base case - empty list or one element

    public void Sort(int[] arr, int start, int end)
    {
        // empty list or only one element
        if (end <= start)
            return;

        var partition = Partition(arr, start, end);

        // after finding a pivot, we sort left side and right side

        Sort(arr, start, partition - 1);
        Sort(arr, partition + 1, end);
    }

    private int Partition(int[] arr, int start, int end)
    {
        // pick last element as the pivot
        var pivot = arr[end];

        // all the elements smaller than arr[pivot] go the left side of the pivot
        // and all the elements greater than arr[pivot] go the right side of the pivot
        var j = start - 1;

        for (var i = start; i < end; i++)
        {
            if (arr[i] <= pivot)
            {
                j++; // increment the start pointer as it's now smaller than the pivot
                (arr[i], arr[j]) = (arr[j], arr[i]);
            }
        }

        // j is the position of the pivot
        (arr[end], arr[j + 1]) = (arr[j + 1], arr[end]);
        return j + 1;
    }
}