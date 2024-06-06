namespace Sandbox.Solutions.Medium;

public class NextGreaterElement2
{
    public int[] NextGreaterElements(int[] nums)
    {
        // next greater number for every element in nums
        var monoStack = new Stack<int>(nums.Length);
        var nextGreater = new int[nums.Length];

        Array.Fill(nextGreater, -1);

        var n = nums.Length;

        // loop twice
        // on first loop we will have in stack remaining elements that didn't manage to find biggest element
        // so second loop will find their biggest element
        for (int i = 0; i < n * 2; i++)
        {
            while (monoStack.Count > 0 && nums[monoStack.Peek()] < nums[i % n])
            {
                var st = monoStack.Pop();
                nextGreater[st] = i % n;
            }

            monoStack.Push(i % n);
        }

        for (int i = 0; i < nextGreater.Length; i++)
        {
            if (nextGreater[i] == -1)
                continue;

            nextGreater[i] = nums[nextGreater[i]];
        }

        return nextGreater;
    }

    /*
     * why?
     * imagine you have arr
     * 1 2 2 4 3
     *
     * on first loop you'll have next indexes
     * 1 3 3 -1 -1
     * and in stack
     * 4 3
     *
     * so on second loop we will find the value for 3, which is the 4 left in the stack
     * and will gave
     * 1 3 3 -1 3
     */
}