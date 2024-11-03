namespace Sandbox.Solutions.Medium;

public class EvaluateDivision
{
    public double[] CalcEquation(IList<IList<string>> equations, double[] values, IList<IList<string>> queries)
    {
        // if no variable, return -1
        var result = new double[queries.Count];

        var dict = new Dictionary<string, List<(string, double)>>(equations.Count);

        for (var i = 0; i < equations.Count; i++)
        {
            var equation = equations[i];
            dict.TryAdd(equation[0], []);
            dict.TryAdd(equation[1], []);

            dict[equation[0]].Add((equation[1], values[i]));
            dict[equation[1]].Add((equation[0], 1 / values[i]));
        }

        for (int i = 0; i < queries.Count; i++)
        {
            var query = queries[i];
            if (!dict.ContainsKey(query[0]) || !dict.ContainsKey(query[1]))
            {
                result[i] = -1;
                continue;
            }

            result[i] = Dfs(query[0], query[1], [query[0]], 1);
        }

        return result;

        double Dfs(string node, string target, HashSet<string> visited, double value)
        {
            if (node == target)
                return value;

            visited.Add(node);

            var nodes = dict[node].Where(e => !visited.Contains(e.Item1)).ToList();
            foreach (var (to, toValue) in nodes)
            {
                var ans = Dfs(to, target, visited, value * toValue);
                if (ans == -1)
                    continue;

                return ans;
            }

            return -1;
        }
    }
}