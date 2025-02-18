using System.Resources;

namespace Sandbox.Solutions.Hard;

public class NamingCompany
{
    public long DistinctNames(string[] ideas)
    {
        long result = 0;

        var dict = new Dictionary<char, HashSet<string>>(ideas.Length);

        // group the ideas into groups of characters to their suffix
        // c -> offee, t -> offee
        foreach (var idea in ideas)
        {
            var ch = idea[0];
            dict.TryAdd(ch, []);
            dict[ch].Add(idea[1..]);
        }

        var keys = dict.Keys.ToArray();
        for (int i = 0; i < keys.Length; i++)
        {
            for (int j = i + 1; j < keys.Length; j++)
            {
                var setA = dict[keys[i]];
                var setB = dict[keys[j]];

                int commonSuffixes = setA.Intersect(setB).Count();
                result += 2 * (setA.Count - commonSuffixes) * (setB.Count - commonSuffixes);
            }
        }

        return result;
    }
}