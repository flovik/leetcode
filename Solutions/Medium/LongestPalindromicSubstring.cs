namespace Sandbox.Solutions.Medium;

public class LongestPalindromicSubstring
{
    public string LongestPalindrome(string s)
    {
        // search all substrings of 2 length and 3 length
        // and go outwards, return the longest one
        var answer = s[0].ToString();

        for (int i = 0, j = 1; j < s.Length; i++, j++)
        {
            if (IsPalindrome(s, i, j))
                CheckPalindromes(s, i, j);

            if (j < s.Length -1 && IsPalindrome(s, i, j + 1))
                CheckPalindromes(s, i, j + 1);
        }

        return answer;

        void CheckPalindromes(string s, int i, int j)
        {
            while (i > 0 && j < s.Length - 1)
            {
                if (s[i - 1] == s[j + 1])
                {
                    i--;
                    j++;
                }
                else
                    break;
            }

            if (answer.Length < j - i + 1)
                answer = s[i..(j + 1)];
        }
    }

    private bool IsPalindrome(string s, int start, int end)
    {
        // start and end to not allocate more memory for string
        while (start < end)
        {
            if (s[start++] != s[end--])
                return false;
        }

        return true;
    }
}