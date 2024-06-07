namespace Sandbox.Solutions.Medium;

public class MaximumSubarrayMinProduct
{
    public int MaxSumMinProduct(int[] nums)
    {
        // same as largest rectangle in histogram
        // get next smaller and prev smaller to find from where to look for the leftmost and rightmost values
        var monoStack = new Stack<int>(nums.Length);
        var nextSmaller = new int[nums.Length];
        var prevSmaller = new int[nums.Length];
        long area = 0;

        Array.Fill(nextSmaller, -1);
        Array.Fill(prevSmaller, -1);

        for (int i = 0; i < nums.Length; i++)
        {
            while (monoStack.Count > 0 && nums[monoStack.Peek()] > nums[i])
            {
                var st = monoStack.Pop();
                nextSmaller[st] = i;
            }

            if (monoStack.Count > 0)
                prevSmaller[i] = monoStack.Peek();

            monoStack.Push(i);
        }

        for (int i = 0; i < nums.Length; i++)
        {
            var height = nums[i];
            var rightMost = nextSmaller[i] == -1 ? nums.Length - 1 : nextSmaller[i] - 1;
            var leftMost = prevSmaller[i] == -1 ? 0 : prevSmaller[i] + 1;
            long sum = 0;

            while (leftMost <= rightMost)
            {
                sum += nums[leftMost];
                leftMost++;
            }

            area = Math.Max(area, height * (sum));
        }

        return (int) (area % 1_000_000_007);
    }
}