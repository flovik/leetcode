namespace Sandbox.Solutions.Medium;

internal class PalindromicSubstrings
{
    public int CountSubstrings(string s)
    {
        var result = 0;

        for (int i = 0; i < s.Length; i++)
        {
            if (IsPalindrome(s, i, i))
                CheckPalindromes(s, i, i);

            if (i < s.Length - 1 && IsPalindrome(s, i, i + 1))
                CheckPalindromes(s, i, i + 1);
        }

        return result;

        void CheckPalindromes(string s, int start, int end)
        {
            result++;
            while (start > 0 && end < s.Length - 1)
            {
                if (s[start - 1] == s[end + 1])
                {
                    start--;
                    end++;
                    result++;
                }
                else
                    break;
            }
        }
    }

    private bool IsPalindrome(string s, int start, int end)
    {
        while (start < end)
        {
            if (s[start++] != s[end--])
                return false;
        }

        return true;
    }
}