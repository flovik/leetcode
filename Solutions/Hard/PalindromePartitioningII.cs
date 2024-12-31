using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox.Solutions.Hard;

public class PalindromePartitioningII
{
    public int MinCut(string s)
    {
        var dp = Enumerable.Range(0, s.Length).ToArray(); // every character is a palindrome in itself
        for (int i = 0; i < s.Length; i++)
        {
            CalculatePalindromes(s, dp, i, i); // iterate all 3's palindromes and expand
            CalculatePalindromes(s, dp, i, i + 1); // iterate all 2's palindromes and expand
        }

        return dp[^1];
    }

    private void CalculatePalindromes(string s, int[] dp, int left, int right)
    {
        while (left >= 0 && right < s.Length && s[left] == s[right])
        {
            var newCut = left == 0 ? 0 : dp[left - 1] + 1;
            dp[right] = Math.Min(dp[right], newCut);

            left--;
            right++;
        }
    }
}