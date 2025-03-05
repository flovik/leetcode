namespace Sandbox.Solutions.Medium;

public class FlipStringToMonotoneIncreasing
{
    public int MinFlipsMonoIncr(string s)
    {
        // monotone increasing
        // meaning leading zeroes followed by ones
        var zeroes = new int[s.Length + 1];
        var ones = 0;

        for (int i = 0; i < s.Length; i++)
        {
            zeroes[i + 1] = zeroes[i];

            if (s[i] == '1')
                zeroes[i + 1]++;
        }

        var min = zeroes[^1];

        for (int i = s.Length - 1; i >= 0; i--)
        {
            if (s[i] == '0')
                ones++;
            else
                zeroes[i + 1]--;

            min = Math.Min(min, zeroes[i + 1] + ones);
        }

        return min;
    }
}