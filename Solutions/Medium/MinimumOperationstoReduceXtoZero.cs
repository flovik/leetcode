namespace Sandbox.Solutions.Medium;

public class MinimumOperationstoReduceXtoZero
{
    public int MinOperations(int[] nums, int x)
    {
        // place in map first num and base case, in case right numbers are sufficient to satisfy the condition
        var map = new Dictionary<int, int>(nums.Length - 1) { { 0, -1 } };
        var result = int.MinValue;

        // totalSum - x
        var target = -x + nums.Sum();

        if (target == 0)
            return nums.Length;

        // map + prefix sum, find longest subarray that adds up to our target
        int sum = 0;

        for (var i = 0; i < nums.Length; i++)
        {
            sum += nums[i];
            var subArraySum = map.GetValueOrDefault(sum - target, -2);

            if (subArraySum != -2)
                result = Math.Max(result, i - subArraySum);

            map.Add(sum, i);
        }

        return result == int.MinValue ? -1 : nums.Length - result;
    }
}