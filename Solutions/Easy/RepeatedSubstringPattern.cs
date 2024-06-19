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
        return false;
    }
}