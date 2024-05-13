using NUnit.Framework.Constraints;
using System;

namespace Sandbox.Solutions.Medium;

public class MinimumSubstringPartitionofEqualCharacterFrequency
{
    private Dictionary<char, int> _dictionary;

    public int MinimumSubstringsInPartition(string s)
    {
        //_dictionary = new Dictionary<char, int>(s.Length);
        var dp = new int[s.Length];
        Array.Fill(dp, s.Length);

        for (var i = 0; i < s.Length; i++)
        {
            var charFreq = new int[26];
            for (var j = i; j >= 0; j--)
            {
                charFreq[s[j] - 'a']++;
                if (IsBalanced(charFreq))
                {
                    if (j == 0)
                        dp[i] = 1;
                    else
                        dp[i] = Math.Min(dp[i], dp[j - 1] + 1);
                }
            }

            //_dictionary.Clear();
        }

        return dp[s.Length - 1];
    }

    public bool IsBalanced(int[] charFreq)
    {
        int minFreq = 1001, maxFreq = 0;
        foreach (var freq in charFreq)
        {
            if (freq > 0)
            {
                minFreq = Math.Min(minFreq, freq);
                maxFreq = Math.Max(maxFreq, freq);
            }
        }
        return minFreq == maxFreq;
    }

    private bool IsSameFrequency(char s)
    {
        if (!_dictionary.TryAdd(s, 1))
            _dictionary[s]++;

        var frequency = _dictionary[s];
        return _dictionary.All(c => c.Value == frequency);
    }

    /*
     * ababcc
     *
     * on each iteration we compute possible partitions and if they are valid
     * i = 0 base case, it is 1, from 'a' we can create just one partition
     * i = 1, j = 1, add 'b', we have two partitions 'a' and 'b', they are valid, so 2
     * i = 1, j = 0, add 'a', 'ab' is valid, now min is 1 partition
     * i = 2, j = 2, add 'a', we have 'ab' from last partition, so 'ab' and 'a' becomes 2 partitions -> ab a
     * i = 2, j = 1, add 'b', we have 'a' and 'ba', 2 partitions -> a ba
     * i = 2, j = 0, add 'a', we have 'aba', can't create 1 partition, remains 2
     * i = 3, j = 3, add 'b' to 'aba' (which is 2 partitions -> ab a or a ba), so we have 'ab' 'a' 'b' or 'a' 'ba' 'b' and it's the same thing, 3 partitions
     * i = 3, j = 2, add 'a', 'ab' and 'ab' -> 2 partitions
     * i = 3, j = 1, add 'b', 'a' 'bab' can't create partition
     * i = 3, j = 0, add 'a', 'abab' -> 1 partition
     */
}