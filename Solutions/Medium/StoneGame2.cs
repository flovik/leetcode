using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox.Solutions.Medium;

internal class StoneGame2
{
    private int[] _prefix;
    private Dictionary<(int, int), int> _cache = new();

    public int StoneGameII(int[] piles)
    {
        _prefix = new int[piles.Length];
        Array.Copy(piles, _prefix, piles.Length);

        for (int i = 1; i < piles.Length; i++)
        {
            _prefix[i] += _prefix[i - 1];
        }

        return Backtrack(piles, 0, 1);
    }

    private int Backtrack(int[] piles, int startIndex, int m)
    {
        if (_cache.ContainsKey((startIndex, m)))
            return _cache[(startIndex, m)];

        int max = 0, i = startIndex;
        var total = startIndex == 0 ? _prefix[^1] : _prefix[^1] - _prefix[startIndex - 1];

        while (i < piles.Length && i < startIndex + m * 2)
        {
            var stonesCount = i - startIndex + 1;
            var score = startIndex != 0 ? _prefix[i] - _prefix[startIndex - 1] : _prefix[i];
            var nextScore = Backtrack(piles, i + 1, Math.Max(stonesCount, m));
            max = Math.Max(max, score + (total - score - nextScore));
            i++;
        }

        _cache.TryAdd((startIndex, m), max);
        return max;
    }
}