using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox.Solutions.Medium;

public class MaximumProductOfTheLengthOfTwoPalindromicSubsequences
{
    private int _count = 0;

    public int MaxProduct(string s)
    {
        Backtrack(s, 0, new StringBuilder(s.Length), new StringBuilder(s.Length));
        return _count;
    }

    private void Backtrack(string s, int index, StringBuilder s1, StringBuilder s2)
    {
        if (IsPalindrome(s1.ToString()) && IsPalindrome(s2.ToString()))
            _count = Math.Max(_count, s1.Length * s2.Length);

        if (index > s.Length - 1)
            return;

        // add current char to s1
        s1.Append(s[index]);
        Backtrack(s, index + 1, s1, s2);
        s1.Remove(s1.Length - 1, 1);

        // add current char to s2
        s2.Append(s[index]);
        Backtrack(s, index + 1, s1, s2);
        s2.Remove(s2.Length - 1, 1);

        // skip current char entirely
        Backtrack(s, index + 1, s1, s2);
    }

    private static bool IsPalindrome(string s)
    {
        int left = 0, right = s.Length - 1;
        while (left < right)
        {
            if (s[left] != s[right])
                return false;

            left++;
            right--;
        }

        return true;
    }
}