using System;

namespace Sandbox.Solutions.Hard;

public class MinimumNumberOfOperationsToMakeArrayContinuous
{
    public int MinOperations(int[] nums)
    {
        var totalLen = nums.Length;
        var min = int.MaxValue;

        var arr = nums.Distinct().ToArray();
        Array.Sort(arr);

        var len = arr.Length;

        for (var i = 0; i < arr.Length; i++)
        {
            var curNum = arr[i] - 1 + totalLen;

            var index = Array.BinarySearch(arr, curNum);

            if (index < 0)
                index = ~index;

            if (index == len || arr[index] != curNum)
                index--;

            var value = totalLen - (index - i + 1);
            min = Math.Min(min, value);
        }

        return min;
    }
}