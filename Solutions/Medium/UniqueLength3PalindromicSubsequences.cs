namespace Sandbox.Solutions.Medium;

public class UniqueLength3PalindromicSubsequences
{
    public int CountPalindromicSubsequence(string s)
    {
        // store first occurence of the character and last, in between calculate distinct characters
        var first = new int[26];
        var last = new int[26];
        var result = 0;

        Array.Fill(first, int.MaxValue);
        Array.Fill(last, int.MinValue);

        for (int i = 0; i < s.Length; i++)
        {
            var ch = s[i] - 'a';
            first[ch] = Math.Min(first[ch], i);
            last[ch] = Math.Max(last[ch], i);
        }

        var set = new HashSet<char>(26);
        for (int i = 0; i < 26; i++)
        {
            set.Clear();
            if (first[i] < last[i])
            {
                var span = s.Substring(first[i] + 1, last[i] - first[i] - 1);
                set.UnionWith(span);
                result += set.Count;
            }
        }

        return result;
    }
}