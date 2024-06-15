namespace Sandbox.Topics.Sorting;

public class RadixSort
{
    public void Sort(int[] nums)
    {
        var max = nums.Max();
        var count = new int[max + 1];

        // count number of each number
        foreach (var num in nums)
        {
            count[num]++;
        }

        // prefix sum
        for (int i = 1; i < count.Length; i++)
        {
            count[i] = count[i - 1];
        }

        var sortedArray = new int[nums.Length];
        for (var i = nums.Length - 1; i >= 0; i--)
        {
            var cur = nums[i];
            var pos = count[cur] - 1;
            sortedArray[pos] = cur;
            count[cur]--;
        }
    }
}