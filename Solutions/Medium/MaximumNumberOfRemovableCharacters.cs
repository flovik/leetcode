namespace Sandbox.Solutions.Medium;

public class MaximumNumberOfRemovableCharacters
{
    public int MaximumRemovals(string s, string p, int[] removable)
    {
        // if I remove K characters from s, is p still a subsequence? 
        // binary search K if that's the case

        // how to find if p is a subsequence? 
        // two pointers - start with each character in p, try to find it from start of s, when an occurence is found
        // move p pointer next and s pointer next, until you get to the end of p string

        int left = 0, right = removable.Length - 1;

        while (left <= right)
        {
            var mid = (left + right) / 2;

            var set = new HashSet<int>(removable[..(mid + 1)]);

            if (CanConstructSubsequence(s, p, set))
                left = mid + 1;
            else
                right = mid - 1;
        }

        return left;
    }

    private static bool CanConstructSubsequence(string s, string p, HashSet<int> set)
    {
        var pLeft = 0;

        for (var sLeft = 0; sLeft < s.Length && pLeft < p.Length; sLeft++)
        {
            if (set.Contains(sLeft))
                continue;

            if (s[sLeft] == p[pLeft])
                pLeft++;
        }

        return pLeft == p.Length;
    }
}
