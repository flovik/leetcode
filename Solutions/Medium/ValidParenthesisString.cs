using NUnit.Framework.Constraints;

namespace Sandbox.Solutions.Medium;

public class ValidParenthesisString
{
    public bool CheckValidString(string s)
    {
        var dp = new bool[s.Length + 1][];

        for (int i = 0; i <= s.Length; i++)
        {
            dp[i] = new bool[s.Length + 1];
        }

        // (*)) - very understandable test case
        // count of opening bracket should be 0
        dp[s.Length][0] = true;

        for (int i = s.Length - 1; i >= 0; i--)
        {
            for (int openBrackets = 0; openBrackets < s.Length; openBrackets++)
            {
                var answer = false;

                // at each step, are OpenBrackets count enough to close the next substring?
                if (s[i] == '*')
                {
                    answer = dp[i + 1][openBrackets + 1]; // (
                    answer = answer || dp[i + 1][openBrackets]; // _

                    // )
                    if (openBrackets > 0)
                        answer = answer || dp[i + 1][openBrackets - 1];
                }
                else if (s[i] == '(')
                {
                    answer = dp[i + 1][openBrackets + 1];
                }
                else if (s[i] == ')')
                {
                    if (openBrackets > 0)
                        answer = dp[i + 1][openBrackets - 1];
                }

                dp[i][openBrackets] = answer;
            }
        }

        return dp[0][0];
    }

    /*     0 1 2 3 - count of open parenthesis
     *     ( * ) )
     *   ( T T T F
     *   * F T T T
     *   ) F F T F
     *   ) F T F F
     *     T
     *
     *  go from left bottom to right, at every iteration consider if with current num of open parenthesis to close that substring
     *  last row - one parenthesis is enough to have a valid string
     *  prev row - now we should have precisely two open parenthesis to have a valid
     *  prev row - here we have a *, so we could consider every possible way + current num of open, so on i = 1, we should have 1 open and * (as open),
     *  on i = 2, we have 2 open and * (as empty) and i = 3, where * is ( closed to satisfy
     *  first row, the current character is (, so it itself is an open bracket
     */

    public bool CheckValidStringBacktrack(string s)
    {
        // TLE
        return Backtrack("", 0);

        bool Backtrack(string current, int index)
        {
            if (current.Length >= 2 && current[^2] == '(' && current[^1] == ')')
                current = current[..^2];

            if (index == s.Length)
                return current == "";

            if (s[index] == '*')
            {
                return Backtrack(current + ")", index + 1) ||
                        Backtrack(current + "(", index + 1) ||
                        Backtrack(current, index + 1);
            }

            return Backtrack(current + s[index], index + 1);
        }
    }
}