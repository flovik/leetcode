namespace Sandbox.Solutions.Medium;

public class MinimumNumberOfOperationsToMakeArrayEmpty
{
    public int MinOperations(int[] nums)
    {
        var result = 0;
        var dict = new Dictionary<int, int>();

        for (int i = 0; i < nums.Length; i++)
        {
            dict.TryAdd(nums[i], 0);
            dict[nums[i]]++;
        }

        foreach (var (_, count) in dict)
        {
            if (count == 1)
                return -1;

            if (count % 3 == 0)
                result += count / 3;
            else
                result += count / 3 + 1;
        }

        return result;
    }
}