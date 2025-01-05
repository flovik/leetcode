using System.Text;

namespace Sandbox.Solutions.Medium;

internal class ShiftingLetters2
{
    private char[] _letters = new char[26];

    public string ShiftingLetters(string s, int[][] shifts)
    {
        // shifts[i] = [start, end, direction]
        // from start to end (inclusive), direction = 1 (forward) else backward
        for (var i = 0; i < 26; i++)
        {
            _letters[i] = (char)('a' + i);
        }

        // calculate the count of particular ranges
        var dict = new Dictionary<(int, int), int>(s.Length);

        foreach (var shift in shifts)
        {
            var add = shift[2] == 1 ? 1 : -1;
            var range = (shift[0], shift[1]);

            dict.TryAdd(range, 0);
            dict[range] += add;
        }

        var sShifts = new int[s.Length];

        foreach (var ((from, to), shift) in dict)
        {
            for (var i = from; i <= to; i++)
            {
                sShifts[i] += shift;
            }
        }

        var sb = new StringBuilder(s.Length);

        for (var i = 0; i < s.Length; i++)
        {
            var index = s[i] - 'a';
            var next = (index + sShifts[i]) % 26;

            if (next < 0)
                next += 26;

            sb.Append(_letters[next]);
        }

        return sb.ToString();
    }

    public string ShiftingLettersLineSweep(string s, int[][] shifts)
    {
        var dict = new int[s.Length + 1];

        // accumulate shifts to the beginning and end of each interval
        foreach (var shift in shifts)
        {
            var add = shift[2] == 1 ? 1 : -1;
            dict[shift[0]] += add;
            dict[shift[1] + 1] += -add; // because we do prefix sum, we need to subtract next range position to exclude(!) current added prefix sum!
        }

        // prefix sum
        for (var i = 1; i < dict.Length; i++)
        {
            dict[i] += dict[i - 1];
        }

        var sb = new StringBuilder(s.Length);

        for (int i = 0; i < s.Length; i++)
        {
            var index = s[i] - 'a';
            var next = 'a' + (index + dict[i] % 26 + 26) % 26;
            sb.Append((char)next);
        }

        return sb.ToString();
    }
}