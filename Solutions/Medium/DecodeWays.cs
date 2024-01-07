namespace Sandbox.Solutions.Medium;

public class DecodeWays
{
    public int NumDecodings(string s)
    {
        // climbing stairs with some decisions
        // as you can make COMBINATIONS of stairs, you can create combinations of words
        // best case scenario it's the fibonacci sequence
        // leading zeros
        if (s[0] == '0')
            return 0;

        // dp[i] represents the number of ways to decode the substring s[:i]
        // iterate through the string and update the dp array based on the current
        // digit and the previous digits

        var previous = 1; // empty string (one way to decode it)
        var current = 1; // first letter (one way to decode it)
        int result = 1;

        for (var i = 2; i <= s.Length; i++)
        {
            var temp = 0;
            if (s[i - 1] != '0')
                temp += current;

            if (s[i - 2] == '1' || (s[i - 2] == '2' && s[i - 1] <= '6'))
                temp += previous;

            previous = current;
            current = temp;
            result = temp;
        }

        return result;
    }
}

/*
 * draw a decision tree
 * go step by step with each character and see what you can compute
 * you can you have the i character itself and possibly i + 1 (if it is not zero or less than 7), 27 and higher are not in the mapping
 *
 * 2263
 * at every point of my recursion 2, 2, 6, 3
 * I can decode one character or two and make a decision
 * can I decode 2? yes, then 1 + DecodeWays(s[i..]), so 1 + the rest of the string
 * so remember, from the first position we could decode in two ways, one character and two characters
 * is 22 a valid decoding? yes, then again 1 + s[(i + 1)..], we can decode two ways
 * by going in such a manner, we analyze all the possibilities in recursive brute force fashion, which generates 2^n complexity
 * to improve, cache the results
 *
 * we have the DecodeWays(s[i..]), which is 263 and repeat the same process
 * so memoization will prune one of the tree branches and minify the complexity to O(n)
 */