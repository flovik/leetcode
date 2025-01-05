using System.Text;

namespace Sandbox.Solutions.Medium;

internal class ShiftingLetters
{
    private char[] _letters = new char[26];

    public string ShiftingLettersSol(string s, int[] shifts)
    {
        for (var i = 0; i < 26; i++)
        {
            _letters[i] = (char)('a' + i);
        }

        // prefix sum from right to left
        for (int i = shifts.Length - 2; i >= 0; i--)
        {
            shifts[i] += shifts[i + 1] % 26;
        }

        var sb = new StringBuilder(s.Length);

        for (var i = 0; i < shifts.Length; i++)
        {
            var index = s[i] - 'a';
            var next = (index + shifts[i]) % 26;
            sb.Append(_letters[next]);
        }

        return sb.ToString();
    }
}