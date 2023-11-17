namespace Sandbox.Solutions.Medium;

public class LongestSubstringWithoutRepeatingCharacters
{
    private readonly ISet<char> _characterSet = new HashSet<char>();

    public int LengthOfLongestSubstring(string s)
    {
        // len of longest substring without repeating characters.
        // hash set to track repeated characters
        // move right pointer until you get to the first repeating character
        // then move left until no more repeated characters are encountered and repeat

        int len = 0, i = 0, j = 0;

        while (j <= s.Length - 1)
        {
            if (!_characterSet.Contains(s[j]))
            {
                _characterSet.Add(s[j]);
                j++;
                if (_characterSet.Count > len)
                    len = _characterSet.Count;
            }
            else
            {
                _characterSet.Remove(s[i]);
                i++;
            }
        }

        return len;
    }
}