namespace Sandbox.Solutions.Medium;

public class BestSightseeingPair
{
    public int MaxScoreSightseeingPair(int[] values)
    {
        var max = 0;
        for (int i = 1; i < values.Length; i++)
        {
            var profit = values[i] + values[i - 1] - 1;
            max = Math.Max(profit, max);

            values[i] = Math.Max(values[i], values[i - 1] - 1);
        }

        return max;
    }
}