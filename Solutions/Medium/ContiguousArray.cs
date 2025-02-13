namespace Sandbox.Solutions.Medium;

public class ContiguousArray
{
    public int FindMaxLength(int[] nums)
    {
        // prefix sum + dict
        var dict = new Dictionary<int, int>(nums.Length) { { 0, 0 } }; // base case
        int prefix = 0, result = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] == 1) prefix++;
            else prefix--;

            if (dict.TryGetValue(prefix, out int value))
                result = Math.Max(result, i - value + 1);

            dict.TryAdd(prefix, i + 1); // point to next index
        }

        return result;
    }
}