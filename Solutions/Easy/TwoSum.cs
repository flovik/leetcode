using System;

namespace Sandbox.Solutions.Easy;

public class TwoSum
{
    private IDictionary<int, int> numToIndexDictionary = new Dictionary<int, int>();
    public int[] TwoSums(int[] nums, int target)
    {
        for (int i = 0; i < nums.Length; i++)
        {
            int difference;
            if (target < nums[i]) difference = target - nums[i];
            else difference = Math.Abs(target - nums[i]);

            if (numToIndexDictionary.ContainsKey(difference)) return new[] { numToIndexDictionary[difference], i };
            if (!numToIndexDictionary.ContainsKey(nums[i])) { numToIndexDictionary.Add(nums[i], i); }
        }

        return new int[1];
    }
}