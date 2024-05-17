namespace Sandbox.Solutions.Medium;

public class LongestStringChain
{
    public int LongestStrChain(string[] words)
    {
        // sort by length
        Array.Sort(words, (s, s1) => s.Length.CompareTo(s1.Length));
        var dp = new int[words.Length];
        Array.Fill(dp, 1);

        for (var i = 0; i < dp.Length; i++)
        {
            for (var j = 0; j < i; j++)
            {
                if (words[j].Length != words[i].Length - 1)
                    continue;

                // delete one character from current and compare with each previous strings if match
                for (var k = 0; k < words[i].Length; k++)
                {
                    var substring = words[i].Remove(k, 1);
                    if (words[j].Equals(substring))
                        dp[i] = Math.Max(dp[i], dp[j] + 1);
                }
            }
        }

        return dp.Max();
    }
}