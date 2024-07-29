namespace Sandbox.Solutions.Medium;

public class MinimumTimetoMakeRopeColorful
{
    public int MinCost(string colors, int[] neededTime)
    {
        var right = 1;
        var result = 0;

        while (right < colors.Length)
        {
            var color = colors[right - 1];

            if (colors[right] == color)
            {
                var count = neededTime[right - 1];
                var max = neededTime[right - 1];
                while (right < colors.Length && colors[right] == color)
                {
                    max = Math.Max(max, neededTime[right]);
                    count += neededTime[right];
                    right++;
                }

                result += count - max;
            }

            right++;
        }

        return result;
    }
}