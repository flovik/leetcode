namespace Sandbox.Solutions.Medium;

public class LengthOfLongestFibonacciSubsequence
{
    public int LenLongestFibSubseq(int[] arr)
    {
        var dp = new HashSet<int>(arr.Length);
        var max = 0;

        foreach (var t in arr)
        {
            dp.Add(t);
        }

        for (var i = 0; i < arr.Length; i++)
        {
            for (var j = i + 1; j < arr.Length; j++)
            {
                var len = 2;
                int a = arr[i], b = arr[j];

                while (dp.Contains(a + b))
                {
                    b = a + b;
                    a = b - a;
                    len++;
                }

                max = Math.Max(max, len);
            }
        }

        return max <= 2 ? 0 : max;
    }
}