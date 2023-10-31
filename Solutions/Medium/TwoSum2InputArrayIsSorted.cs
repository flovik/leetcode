namespace Sandbox.Solutions.Medium;

public class TwoSum2InputArrayIsSorted
{
    public int[] TwoSum(int[] numbers, int target)
    {
        // O(1) space
        // two pointers

        for (int i = 0, j = numbers.Length - 1; i < numbers.Length; i++, j--)
        {
            var cur = numbers[i] + numbers[j];
            if (cur == target)
                return new[] { i + 1, j + 1 };

            if (target < cur)
                i--;
            else
                j++;
        }

        return new int[2];
    }

    // public int[] TwoSumBinarySearch(int[] numbers, int target)
    // {
    //     // binary search, because it is already sorted
    //     // return indexes of both numbers that add up to target
    //
    //
    // }
}