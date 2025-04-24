namespace Sandbox.Solutions.Medium;

public class TakeKOfEachCharacterFromLeftAndRight
{
    public int TakeCharacters(string s, int k)
    {
        // s contains a, b and c
        // take leftmost and rightmost one by one to have each char at least K
        // instead of thinking about left end and right end, think about the middle of the array
        // and see how can you extend it that it satisfies the condition

        // find maximum subsequence that satisfies the condition of the problem

        if (k == 0)
            return 0;

        int maxLen = 0;
        var dict = new int[3];

        foreach (var ch in s)
        {
            dict[ch - 'a']++;
        }

        if (!SatisfiesCondition())
            return -1;

        int left = 0, right = 0;

        while (right < s.Length)
        {
            dict[s[right] - 'a']--;

            while (left <= right && !SatisfiesCondition())
            {
                maxLen = Math.Max(maxLen, right - left);
                dict[s[left] - 'a']++;
                left++;
            }

            right++;
        }

        if (SatisfiesCondition())
            maxLen = Math.Max(maxLen, right - left);

        return s.Length - maxLen;

        bool SatisfiesCondition() => dict.All(e => e >= k);
    }
}