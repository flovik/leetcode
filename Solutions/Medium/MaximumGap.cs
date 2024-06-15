namespace Sandbox.Solutions.Medium;

public class MaximumGapSol
{
    public int MaximumGap(int[] nums)
    {
        if (nums.Length < 2)
            return 0;

        var max = nums.Max();
        int exp = 1; // 1, 10, 100, 1000, ...
        var digits = 10;

        var sortedArray = new int[nums.Length];

        while (max / exp > 0)
        {
            var count = new int[digits];

            // calculate each digit
            foreach (var num in nums)
            {
                count[num / exp % 10]++;
            }

            // prefix sum
            for (int i = 1; i < count.Length; i++)
            {
                count[i] += count[i - 1];
            }

            for (int i = nums.Length - 1; i >= 0; i--)
            {
                var cur = count[nums[i] / exp % 10] - 1;
                sortedArray[cur] = nums[i];
                count[nums[i] / exp % 10]--;
            }

            for (int i = 0; i < nums.Length; i++)
            {
                nums[i] = sortedArray[i];
            }

            exp *= 10;
        }

        var maxResult = 0;
        for (int i = 1; i < sortedArray.Length; i++)
        {
            maxResult = Math.Max(maxResult, sortedArray[i] - sortedArray[i - 1]);
        }

        return maxResult;
    }
}