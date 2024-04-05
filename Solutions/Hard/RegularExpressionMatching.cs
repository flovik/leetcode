namespace Sandbox.Solutions.Hard;

public class RegularExpressionMatching
{
    public bool IsMatch(string s, string p)
    {
        var dp = new bool[s.Length + 1, p.Length + 1];

        dp[0, 0] = true;

        // initialize first row, we can have .* or a*b* which can match to T in some cases
        for (int i = 1; i <= p.Length; i++)
        {
            if (p[i - 1] == '*' && dp[0, i - 2])
                dp[0, i] = true;
        }

        for (int i = 1; i <= s.Length; i++)
        {
            for (int j = 1; j <= p.Length; j++)
            {
                if (s[i - 1] == p[j - 1] && dp[i - 1, j - 1] || // characters match
                    p[j - 1] == '.' && dp[i - 1, j - 1]) // any character
                {
                    dp[i, j] = true;
                }
                else if (p[j - 1] == '*') // star case
                {
                    if (dp[i, j - 2]) // no characters
                    {
                        dp[i, j] = true;
                    }
                    else if (dp[i - 1, j] && (p[j - 2] == '.' || p[j - 2] == s[i - 1])) // 1 or more occurrences
                    {
                        dp[i, j] = true;
                    }
                }
            }
        }

        return dp[s.Length, p.Length];
    }
}

/*
 * draw a 2D array
 *
 * empty with empty is true
 * match characters, if the character is the same OR a dot
 * take the T[i-1,j-1] because you take the already computed value before
 *
 * but here is an edge case with *
 * you should match whether we take 0 characters of the previous character (j - 2)!
 * OR one character or more of the previous character (i - 1)!
 *
 * a.* and a, analyze why it's correct, in that case we will take 0 characters (j - 2)
 * a.* ac, here we take 1 character (i - 1)!
 *
 * don't forget to check if the value next to star is equal to current value
 * if it's a . (any character), it matches any character (acbcd) whatever
 *     a . * b
 *   T F F F F
 * a F T F T F
 * c F F T T F
 * c F F F T F
 * b F F F
 *
 *     a * b
 *   T F F F
 * b F F F T
 *
 *
 */