namespace Sandbox.Solutions.Medium;

public class LastStoneWeight2
{
    public int LastStoneWeightII(int[] stones)
    {
        var sumSet = new HashSet<int>(stones.Length * stones.Length) { stones[0] };

        for (var i = 1; i < stones.Length; i++)
        {
            var stone = stones[i];
            var sums = sumSet.ToArray();

            sumSet.Clear();
            foreach (var sum in sums)
            {
                sumSet.Add(Math.Abs(sum + stone));
                sumSet.Add(Math.Abs(sum - stone));
            }
        }

        var min = int.MaxValue;
        foreach (var i in sumSet)
        {
            if (i >= 0 && i < min)
                min = i;
        }

        return min;
    }

    public int LastStoneWeightIIDp(int[] stones)
    {
        var sum = stones.Sum();
        var dp = new int[sum / 2 + 1];
        foreach (var stone in stones)
        {
            for (var j = sum / 2; j >= stone; j--)
            {
                dp[j] = Math.Max(dp[j], dp[j - stone] + stone);
            }
        }

        return sum - 2 * dp[^1];
    }
}