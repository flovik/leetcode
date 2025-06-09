namespace Sandbox.Solutions.Hard;

public class MinimumDifficultyOfAJobSchedule
{
    private const int MaxValue = 1_000_000;
    private int[][] _cache = [];

    public int MinDifficulty(int[] jobDifficulty, int d)
    {
        var len = jobDifficulty.Length;
        if (len < d)
            return -1;

        _cache = new int[len][];

        for (var i = 0; i < len; i++)
        {
            _cache[i] = new int[d + 1];
            Array.Fill(_cache[i], -1);
        }

        var res = Backtrack(jobDifficulty, d, 0);
        return res;
    }

    private int Backtrack(int[] jobDifficulty, int d, int index)
    {
        if (index == jobDifficulty.Length && d > 0)
            return MaxValue;

        if (d == 0)
            return index < jobDifficulty.Length ? MaxValue : 0;

        if (_cache[index][d] != -1)
            return _cache[index][d];

        var max = 0;
        var minCut = MaxValue;

        for (var i = index; i < jobDifficulty.Length; i++)
        {
            max = Math.Max(jobDifficulty[i], max);
            var nextCutMax = Backtrack(jobDifficulty, d - 1, i + 1);

            minCut = Math.Min(minCut, max + nextCutMax);
        }

        return _cache[index][d] = minCut;
    }
}