using System.Collections;

namespace Sandbox.Solutions.Hard;

public class RussianDollEnvelopes
{
    public int MaxEnvelopes(int[][] envelopes)
    {
        // by sorting widths ascending you have bigger envelopes
        // but what if width are the same, but heights are different?
        // sort them in descending order
        // by sorting width, we reduce the problem to finding LIS in only heights!
        // why descending? because by the binary search algorithm, having values in ascending order
        // will just extend the array, hereby making the result higher than it should be
        Array.Sort(envelopes, (ints, ints1) =>
        {
            // descending on height
            if (ints[0] == ints1[0])
                return ints1[1].CompareTo(ints[1]);

            // ascending on width
            return ints[0].CompareTo(ints1[0]);
        });

        // remember LIS problem, you had two solutions
        // one dp, another binary search. apply the binary search
        var len = 0;
        var dp = new int[envelopes.Length];
        dp[0] = envelopes[0][1];

        foreach (var envelope in envelopes)
        {
            var target = envelope[1];

            // extend
            if (target > dp[len])
            {
                len++;
                dp[len] = target;
            }

            // replace
            else
            {
                var index = Array.BinarySearch(dp, 0, len + 1, target);

                // closest value to searched value
                if (index < 0)
                    index = ~index;

                dp[index] = target;
            }
        }

        return len + 1;
    }

    private int BinarySearch(int[] list, int start, int end, int target)
    {
        while (start < end)
        {
            var mid = (start + end) / 2;
            if (list[mid] == target)
                return mid;
            if (list[mid] < target)
                start = mid + 1;
            else
                end = mid - 1;
        }

        return start;
    }
}