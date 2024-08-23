namespace Sandbox.Solutions.Medium;

public class MinimumDeletionstoMakeCharacterFrequenciesUnique
{
    public int MinDeletions(string s)
    {
        var letters = new int[26];

        // count frequencies
        foreach (var c in s)
        {
            letters[c - 97]++;
        }

        var result = 0;
        var set = new HashSet<int>(s.Length);

        for (int i = 0; i < 26; i++)
        {
            var cur = letters[i];

            if (set.Contains(cur))
            {
                while (cur > 0 && set.Contains(cur))
                {
                    result++;
                    cur--;
                }
            }

            set.Add(cur);
        }

        return result;
    }
}