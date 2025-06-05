namespace Sandbox.Solutions.Hard;

public class NumberOfWaysToStayInTheSamePlaceAfterSomeSteps
{
    private const int Mod = 1_000_000_007;
    private long[][] _cache = [];

    public int NumWays(int steps, int arrLen)
    {
        _cache = new long[steps][];
        for (var i = 0; i < steps; i++)
        {
            _cache[i] = new long[steps];
            Array.Fill(_cache[i], -1);
        }

        var count = Backtrack(steps, arrLen, 0);

        return (int)(count % Mod);
    }

    private long Backtrack(int steps, int arrLen, int index)
    {
        if (steps == 0)
            return index == 0 ? 1 : 0;

        // return cached value
        if (_cache[steps - 1][index] != -1)
            return _cache[steps - 1][index];

        long count = 0;

        // stay
        count += Backtrack(steps - 1, arrLen, index) % Mod;

        // go left
        if (index > 0)
            count += Backtrack(steps - 1, arrLen, index - 1) % Mod;

        // go right
        if (index < arrLen - 1)
            count += Backtrack(steps - 1, arrLen, index + 1) % Mod;

        // cache value
        return _cache[steps - 1][index] = count;
    }
}