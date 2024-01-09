namespace Sandbox.Solutions.Medium;

public class WordBreakSolution
{
    public bool WordBreak(string s, IList<string> wordDict)
    {
        // save in a dp array if the previous words up until i can be constructed
        // take leetcode, {"leet", "code"}
        // we will have FFFTFFFF (for 'leet'), for that iterate every word possible and check the previous index with the len of the word
        // then we will have FFFTFFFT (for 'code') because it is of length 4 and the previous index is also True
        var dp = new bool[s.Length + 1];
        dp[0] = true; // empty string can be constructed from

        for (var i = 1; i <= s.Length; i++)
        {
            foreach (var word in wordDict)
            {
                if (word.Length > i)
                    continue;

                // compare word with the substring of the searched word and look if the previous index can be constructed
                if (s.Substring(i - word.Length, word.Length) == word && dp[i - word.Length])
                    dp[i] = true;
            }
        }

        return dp[^1];
    }

    private bool InefficientSolution(string s, IList<string> wordDict)
    {
        // inefficient
        var dict = wordDict.ToHashSet();

        return CheckWordBreak(s);

        bool CheckWordBreak(string str)
        {
            if (string.IsNullOrEmpty(str))
                return true;

            for (var i = 1; i <= str.Length; i++)
            {
                var prefix = str[..i];

                if (dict.Contains(prefix) && CheckWordBreak(str[i..]))
                    return true;
            }

            return false;
        }
    }
}