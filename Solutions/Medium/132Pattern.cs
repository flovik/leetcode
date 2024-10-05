namespace Sandbox.Solutions.Medium;

public class _132Pattern
{
    public bool Find132pattern(int[] nums)
    {
        var n = nums.Length;
        var st = new Stack<int>(n);
        int[] nextGreater = new int[n], min = new int[n];

        Array.Copy(nums, min, n);
        Array.Fill(nextGreater, -1);

        // find 1 - min value possible to the left for current
        for (int i = 1; i < nums.Length; i++)
        {
            min[i] = Math.Min(min[i - 1], nums[i]);
        }

        // while we iterate from right to left, we need to find Next Greater Element
        // and by comparing with min of the current element we can find the answer
        for (var i = n - 1; i >= 0; i--)
        {
            while (st.Count > 0 && nums[st.Peek()] < nums[i])
            {
                if (nums[i] > min[i] && nums[st.Peek()] > min[i])
                    return true;

                nextGreater[st.Pop()] = i;
            }

            st.Push(i);
        }

        return false;
    }
}