using System.Collections.Concurrent;

namespace Sandbox.Solutions.Medium;

public class TopKFrequentElements
{
    private PriorityQueue<int, int> pQueue = new PriorityQueue<int, int>(new MaxHeapComparer());
    private IDictionary<int, int> dict = new Dictionary<int, int>();
    public int[] TopKFrequent(int[] nums, int k)
    {
        // one solution is to use a max heap, two most popular solutions in the heap are the answer
        // second solution is using quickselect by Hoare, watch another submission

        // to have a better results, I'll pass a custom comparer to the queue so instead of default min heap I have a max heap
        // also I need a dictionary to save all the values of my numbers

        foreach (var num in nums)
        {
            if (!dict.ContainsKey(num))
            {
                dict.Add(num, 1);
            }
            else
            {
                dict[num]++;
            }
        }

        // add each value of dictionary to max heap
        foreach (var (key, value) in dict)
        {
            pQueue.Enqueue(key, value);
        }

        var res = new int[k];
        int i = 0;

        while (k > 0)
        {
            res[i++] = pQueue.Dequeue();
            k--;
        }

        return res;
    }

    public int[] TopKFrequentUsingQuickselect(int[] nums, int k)
    {
        // quickselect is good in "find kth something", kth smallest, kth largest, kth most frequent
        // approach is similar to quicksort:
        // choose a pivot and define its position in a sorted array in a linear time using partitioning algorithm

        // all elements on the left are less frequent than the pivot, on the right are more frequent
        // steps:
        // 1. build hashmap "element - frequency", array of unique elements
        // 2. choose a random pivot and put it in its place on a sorted array, on the left less frequent, on the right more frequent. It should be placed in its perfect place
        // 3. the pivot is (N-k)th less frequent element. Return the right part of the array.

        // for partition is used Lomuto's Partition Scheme

        // we don't process both parts of the array, because we are not interested in the left part

        foreach (var num in nums)
        {
            if (!dict.ContainsKey(num))
            {
                dict.Add(num, 1);
            }
            else
            {
                dict[num]++;
            }
        }

        // arr of frequencies to their corresponding value
        var arr = new List<(int, int)>();
        foreach (var (key, value) in dict)
        {
            arr.Add((value, key));
        }

        int start = 0, end = arr.Count - 1, largestElement = arr.Count - k;

        while (start < end)
        {
            int pivotIndex = Partition(arr, start, end);
            if (pivotIndex < largestElement) start = pivotIndex + 1;
            else if (pivotIndex > largestElement) end = pivotIndex - 1;
            else
            {
                var mostFrequentElements = arr.GetRange(largestElement, k);
                return mostFrequentElements.Select(el => el.Item2).ToArray();
            }
        }

        var res = arr.GetRange(largestElement, k);
        return res.Select(el => el.Item2).ToArray();
    }

    private static int Partition(IList<(int, int)> nums, int start, int end)
    {
        var pivotIndex = start;

        while (start <= end)
        {
            while (start <= end && nums[start].Item1 <= nums[pivotIndex].Item1) start++;
            while (start <= end && nums[end].Item1 > nums[pivotIndex].Item1) end--;
            if (start > end) break;
            (nums[start], nums[end]) = (nums[end], nums[start]);
        }

        (nums[pivotIndex], nums[end]) = (nums[end], nums[pivotIndex]);
        return end;
    }
}

public class MaxHeapComparer : IComparer<int>
{
    public int Compare(int x, int y)
    {
        if (y < x) return -1;
        if (y > x) return 1;
        return 0;
    }
}