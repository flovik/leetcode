namespace Sandbox.Solutions.Medium;

public class LongestConsecutineSequence
{
    public int LongestConsecutive(int[] nums)
    {
        // o(n) time
        // maybe use the idea behind counting sort?

        // apply an offset to numbers, because counting can't work with negative numbers
        // constraint is that nums[i] >= -10^9 and <= 10^9, so applying an offset of 10^9 is acceptable to fit integers

        int offset = (int)Math.Pow(10, 9);

        for (int i = 0; i < nums.Length; i++)
        {
            nums[i] += offset;
        }

        // find the biggest element in the sequence
        int biggest = nums[0];
        foreach (var num in nums)
        {
            if (num > biggest) biggest = num;
        }

        // allocate array of frequencies each number
        int[] frequencies = new int[biggest + 1];
        foreach (var num in nums)
        {
            frequencies[num] += 1;
        }

        int numsIndex = 0;
        // return back the values in the nums based on the frequencies of each index
        foreach (var (frequency, index) in frequencies.Select((item, index) => (item, index)))
        {
            if (frequency == 0) continue;
            for (int i = 0; i < frequency; i++)
            {
                nums[numsIndex++] = index - offset;
            }
        }

        // calculate longest frequency
        // TODO didn't finish because I came up with a better solution on the fly, see LongestConsecutive2

        return 0;
    }

    public int LongestConsecutive2(int[] nums)
    {
        // use sortedSet, it won't affect performance as elements are inserted and deleted
        // it's a red-black tree, O (log(n)) for inserts

        var sortedSet = new SortedSet<int>(nums);

        int longestSequence = 0;
        int currentLongestSequence = 0;
        int previous = int.MinValue;

        foreach (var num in sortedSet)
        {
            if (num - 1 != previous) currentLongestSequence = 1;
            else currentLongestSequence++;

            previous = num;

            if (currentLongestSequence > longestSequence) longestSequence = currentLongestSequence;
        }

        return longestSequence;
    }
}