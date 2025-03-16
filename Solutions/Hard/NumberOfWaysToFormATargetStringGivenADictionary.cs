using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace Sandbox.Solutions.Hard;

public class NumberOfWaysToFormATargetStringGivenADictionary
{
    private const int mod = 1_000_000_007;

    public int NumWays(string[] words, string target)
    {
        var len = words[0].Length;
        var dp = new long[target.Length + 1][];

        for (int i = 0; i < target.Length + 1; i++)
        {
            dp[i] = new long[len + 1];
        }

        Array.Fill(dp[0], 1);

        // instead of searching every character every time, compute a frequency arr, (character, index)
        var freq = new Dictionary<(char, int), int>(words.Length);

        for (var i = 0; i < words.Length; i++)
        {
            for (var j = 0; j < words[i].Length; j++)
            {
                freq.TryAdd((words[i][j], j), 0);
                freq[(words[i][j], j)]++;
            }
        }

        // look into each character of target, look for in words
        for (var i = 0; i < target.Length; i++)
        {
            for (var j = i; j < len; j++)
            {
                long matches = freq.GetValueOrDefault((target[i], j), 0);
                long value = dp[i][j] * matches % mod;

                dp[i + 1][j + 1] = dp[i + 1][j];
                dp[i + 1][j + 1] = (dp[i + 1][j + 1] + value) % mod;
            }
        }

        return (int)(dp[^1][^1] % mod);
    }

    /*
     * take a simple example, think of it as a 3D dp, you'll process each character one by one for every word and count
     * the matches of characters, the number of matches will multiply with previous iterations
     * i = 0, j = 0, you have only one match, so there is one way to construct b using abba (a) and baab (b)
     * i = 0, j = 1, one match, you multiple with i - 1, j - 1, which is 1, but you have to the left already computed
     * value from previous iteration, so it means it is 2 now, you can construct b from 'ab' and 'ba' in two ways
     * repeat the process for each character
         a b b a            a b a b
         b a a b            b a b a
       1 1 1 1 1            a b b a
     b 0 1 2 3 4            b a a b
     a 0 0 1 3 6          1 1 1 1 1
     b 0 0 0 1 4        a 0 2 4 6 8     here on i = 0, j = 0, a has two match from 2 words, that means multiplier is 2 now
                        b 0 0 4 12 24
                        b 0 0 0 8 32
                        a 0 0 0 0 16
    */
}