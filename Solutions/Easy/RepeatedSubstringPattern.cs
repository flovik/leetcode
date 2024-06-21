using System.Text;

namespace Sandbox.Solutions.Easy;

public class RepeatedSubstringPattern
{
    public bool RepeatedSubstringPatternBruteForce(string s)
    {
        var pattern = new StringBuilder(s.Length / 2);

        // append one character at a time to pattern and find a match
        for (int i = 0; i < s.Length / 2; i++)
        {
            pattern.Append(s[i]);

            if (s.Length % pattern.Length == 0 && IsMatch(s, pattern.ToString()))
                return true;
        }

        return false;
    }

    private bool IsMatch(string s, string pattern)
    {
        for (int i = 0; i < s.Length; i += pattern.Length)
        {
            var possibleMatch = s[i..(pattern.Length + i)];

            if (!pattern.Equals(possibleMatch))
                return false;
        }

        return true;
    }

    public bool RepeatedSubstringPatternKMP(string s)
    {
        var prefix = new int[s.Length];
        int left = 0, right = 1;

        while (right < s.Length)
        {
            if (s[right] == s[left])
            {
                prefix[right] = ++left;
                right++;
            }
            else
            {
                if (left == 0)
                    right++;
                else
                    left = prefix[left - 1];
            }
        }

        // string should be divisible by the repeated substring
        return prefix[^1] != 0 && prefix[^1] % (s.Length - prefix[^1]) == 0;
    }
}