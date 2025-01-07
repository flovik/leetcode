namespace Sandbox.Solutions.Easy;

public class StringMatchingInAnArray
{
    public IList<string> StringMatching(string[] words)
    {
        var set = new HashSet<string>(words.Length);
        var visited = new bool[words.Length];

        for (var i = 0; i < words.Length; i++)
        {
            for (var j = 0; j < words.Length; j++)
            {
                if (i == j || visited[j])
                    continue;

                if (words[i].Contains(words[j]))
                {
                    set.Add(words[j]);
                    visited[j] = true;
                }
            }
        }

        return [.. set];
    }
}