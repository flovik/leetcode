namespace Sandbox.Solutions.Medium;

public class MaximumWidthRamp
{
    public int MaxWidthRamp(int[] nums)
    {
        var max = 0;
        var st = new Stack<int>(nums.Length);

        // stack contains furthers from the left smallest numbers
        for (int i = 0; i < nums.Length; i++)
        {
            if (st.Count == 0 || (st.TryPeek(out var num) && nums[num] > nums[i]))
                st.Push(i);
        }

        // from the furthest right find best ramp 
        for (int i = nums.Length - 1; i >= 0; i--)
        {
            while (st.Count > 0 && st.TryPeek(out var num) && nums[num] < nums[i])
            {
                max = Math.Max(max, i - num);
                st.Pop();
            }
        }

        return max;
    }
}