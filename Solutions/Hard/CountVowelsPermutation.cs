namespace Sandbox.Solutions.Hard;

public class CountVowelsPermutation
{
    private const int Mod = 1_000_000_007;
    private readonly Dictionary<char, long[]> _cache = [];
    private readonly char[] _chars = ['a', 'e', 'i', 'o', 'u'];

    public int CountVowelPermutation(int n)
    {
        foreach (var c in _chars)
        {
            var arr = new long[n];
            _cache.Add(c, arr);
            Array.Fill(arr, -1);
        }

        var count = 0;
        foreach (var c in _chars)
        {
            var value = Backtrack(c, n - 1);
            count = (count + (int)(value % Mod)) % Mod;
        }

        return count;
    }

    private long Backtrack(char ch, int n)
    {
        if (n == 0)
            return 1;

        // return cached value
        if (_cache[ch][n] != -1)
            return _cache[ch][n];

        long count = 0;

        switch (ch)
        {
            case 'a':
                count += Backtrack('e', n - 1) % Mod;
                break;

            case 'e':
                count += Backtrack('a', n - 1) % Mod;
                count += Backtrack('i', n - 1) % Mod;
                break;

            case 'i':
                count += Backtrack('a', n - 1) % Mod;
                count += Backtrack('e', n - 1) % Mod;
                count += Backtrack('o', n - 1) % Mod;
                count += Backtrack('u', n - 1) % Mod;
                break;

            case 'o':
                count += Backtrack('i', n - 1) % Mod;
                count += Backtrack('u', n - 1) % Mod;
                break;

            case 'u':
                count += Backtrack('a', n - 1) % Mod;
                break;
        }

        // cache value
        return _cache[ch][n] = count;
    }
}