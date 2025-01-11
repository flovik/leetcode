namespace Sandbox.Solutions.Medium;

public class ConstructKPalindromeStrings
{
    public bool CanConstruct(string s, int k)
    {
        if (s.Length < k)
            return false;

        var chars = new int[26];
        foreach (var ch in s)
        {
            chars[ch - 'a']++;
        }

        var oddCount = chars.Count(e => e != 0 && e % 2 == 1);
        return oddCount <= k;
    }
}