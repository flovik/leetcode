namespace Sandbox.Solutions.Medium;

public class RotateFunction
{
    public int MaxRotateFunction(int[] nums)
    {
        // compute F(1) - F(0), then F(2) - F(1)
        // you'll have a relation, which will be equal to
        // Sum(nums) - (nums.Length - 1) * nums[(nums.Length - 1) - k]
        var sum = nums.Sum();
        var n = nums.Length;
        int max = 0, prev = 0;

        for (int i = 0; i < n; i++)
        {
            prev += i * nums[i];
        }

        max = prev;

        for (int i = 1; i < n; i++)
        {
            var prevIndex = i - 1;
            var relation = sum - n * nums[n - 1 - prevIndex];

            var cur = prev + relation;
            max = Math.Max(max, cur);

            prev = cur;
        }

        return max;
    }
}