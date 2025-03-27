namespace Sandbox.Solutions.Medium;

public class MinimumIndexOfAValidSplit
{
    public int MinimumIndex(IList<int> nums)
    {
        var dict = new Dictionary<int, int>(nums.Count);

        for (int i = 0; i < nums.Count; i++)
        {
            dict.TryAdd(nums[i], 0);
            dict[nums[i]]++;
        }

        var dominant = 0;
        var max = 0;

        foreach (var (key, value) in dict)
        {
            if (value > max)
            {
                max = value;
                dominant = key;
            }
        }

        var count = 0;
        for (int i = 0; i < nums.Count; i++)
        {
            if (nums[i] == dominant)
                count++;

            // both parts need to satisfy condition
            var isLeftPart = count * 2 > i + 1;
            var isRightPart = (max - count) * 2 > nums.Count - i - 1;

            if (isLeftPart && isRightPart)
                return i;
        }

        return -1;
    }
}