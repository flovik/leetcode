namespace Sandbox.Solutions.Medium;

public class SumOfSubarrayMinimums
{
    public int SumSubarrayMins(int[] arr)
    {
        // two solutions I've come up with are:
        // 1. sliding window O (n * (arr.len - 1))
        // 2. monotonic stack O (n) - hard came up with

        // every contiguous sub array
        const int mod = 1_000_000_007;
        int n = arr.Length;
        long sum = 0;
        var st = new Stack<int>(n);
        var nextSmaller = new int[n];
        var prevSmaller = new int[n];

        Array.Fill(nextSmaller, -1);
        Array.Fill(prevSmaller, -1);

        for (int i = 0; i < arr.Length; i++)
        {
            while (st.Count > 0 && arr[st.Peek()] >= arr[i])
            {
                var pop = st.Pop();
                nextSmaller[pop] = i;
            }

            if (st.Count > 0 && arr[st.Peek()] <= arr[i])
                prevSmaller[i] = st.Peek();

            st.Push(i);
        }

        // calculate in how many sub arrays current number is the smallest
        for (int i = 0; i < nextSmaller.Length; i++)
        {
            // if is -1, then it is the smallest in the current sub array
            var prev = prevSmaller[i] != -1 ? i - prevSmaller[i] : i + 1; // all until previous smaller | every from left side
            var next = nextSmaller[i] != -1 ? nextSmaller[i] - i : arr.Length - i; // all until next smaller | every from right side

            sum += (long) arr[i] * next % mod * prev % mod;
            sum %= mod;
        }

        return (int) sum;
    }
}