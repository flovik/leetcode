using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox.Solutions.Medium;

internal class StoneGame
{
    private readonly Dictionary<(int, int), int> _cache = [];

    public bool StoneGameSol(int[] piles)
    {
        var count = Backtrack(piles, 0, piles.Length - 1);
        return count > 0;
    }

    private int Backtrack(int[] piles, int left, int right)
    {
        if (left == right)
            return piles[left];

        if (_cache.ContainsKey((left, right)))
            return _cache[(left, right)];

        var leftStone = piles[left] - Backtrack(piles, left + 1, right);
        var rightStone = piles[right] - Backtrack(piles, left, right - 1);

        var max = Math.Max(leftStone, rightStone);
        _cache.TryAdd((left, right), max);
        return max;
    }
}