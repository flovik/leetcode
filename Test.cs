using Sandbox.Solutions.Medium;
using System;

namespace Sandbox;

public class Test
{
    private int _path = 1;
    private Dictionary<(int, int), int> _cache = [];

    public int LongestIncreasingPath(int[][] matrix)
    {
        var len = matrix.Length;

        for (int i = 0; i < len; i++)
        {
            for (var j = 0; j < matrix[i].Length; j++)
            {
                Backtrack(matrix, i, j);
            }
        }

        return _path;
    }

    private int Backtrack(int[][] matrix, int i, int j)
    {
        var index = (i, j);

        if (_cache.TryGetValue(index, out var res))
            return res;

        _cache.TryAdd(index, 1);

        if (i > 0 && matrix[i - 1][j] > matrix[i][j])
            _cache[index] = Math.Max(_cache[index], Backtrack(matrix, i - 1, j) + 1);

        if (j > 0 && matrix[i][j - 1] > matrix[i][j])
            _cache[index] = Math.Max(_cache[index], Backtrack(matrix, i, j - 1) + 1);

        if (i < matrix.Length - 1 && matrix[i + 1][j] > matrix[i][j])
            _cache[index] = Math.Max(_cache[index], Backtrack(matrix, i + 1, j) + 1);

        if (j < matrix[i].Length - 1 && matrix[i][j + 1] > matrix[i][j])
            _cache[index] = Math.Max(_cache[index], Backtrack(matrix, i, j + 1) + 1);

        _path = Math.Max(_path, _cache[index]);
        return _cache[index];
    }
}