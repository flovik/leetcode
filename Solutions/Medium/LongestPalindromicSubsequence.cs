namespace Sandbox.Solutions.Medium;

public class LongestPalindromicSubsequence
{
    private int[][] _cache;

    public int LongestPalindromeSubseq(string s)
    {
        _cache = new int[s.Length][];

        for (int i = 0; i < s.Length; i++)
        {
            _cache[i] = new int[s.Length];
        }

        return LongestPalindromeSubseq(s, 0, s.Length - 1);
    }

    private int LongestPalindromeSubseq(string s, int left, int right)
    {
        // the same character
        if (left == right)
            return 1;

        // "aa"
        if (left > right)
            return 0;

        if (_cache[left][right] != 0)
            return _cache[left][right];

        return _cache[left][right] = s[left] == s[right]
            ? 2 + LongestPalindromeSubseq(s, left + 1, right - 1)
            : Math.Max(LongestPalindromeSubseq(s, left + 1, right), LongestPalindromeSubseq(s, left, right - 1));
    }
}