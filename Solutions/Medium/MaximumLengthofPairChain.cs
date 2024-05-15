namespace Sandbox.Solutions.Medium;

public class MaximumLengthofPairChain
{
    public int FindLongestChain(int[][] pairs)
    {
        Array.Sort(pairs, (ints, ints1) => ints[1].CompareTo(ints1[1]));

        var dp = new int[pairs.Length];
        Array.Fill(dp, 1);

        for (var i = 0; i < pairs.Length; i++)
        {
            var start = pairs[i][0];

            for (var j = 0; j < i; j++)
            {
                var fromEnd = pairs[j][1];

                if (fromEnd < start)
                {
                    dp[i] = Math.Max(dp[i], dp[j] + 1);
                }
            }
        }

        return dp[^1];
    }

    public int FindLongestChainGreedy(int[][] pairs)
    {
        Array.Sort(pairs, (ints, ints1) => ints[1].CompareTo(ints1[1]));

        // remove overlapping intervals
        var result = 0;
        var previous = int.MinValue;
        foreach (var pair in pairs)
        {
            if (pair[0] > previous)
            {
                result++;
                previous = pair[1];
            }
        }

        return result;
    }
}