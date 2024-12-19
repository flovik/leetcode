namespace Sandbox.Solutions.Hard;

public class ConcatenatedWords
{
    public IList<string> FindAllConcatenatedWordsInADict(string[] words)
    {
        var list = new List<string>(words.Length);
        var set = new HashSet<string>(words);

        foreach (var word in words)
        {
            var dp = new bool[word.Length + 1];
            dp[0] = true;

            for (var i = 0; i < word.Length; i++)
            {
                if (!dp[i])
                    continue;

                var len = 1;
                while (len + i <= word.Length)
                {
                    var subString = word.Substring(i, len);
                    if (word != subString && set.Contains(subString))
                        dp[i + len] = true;

                    len++;
                }
            }

            if (dp[^1] && dp.Count(e => e) > 1)
                list.Add(word);
        }

        return list;
    }
}