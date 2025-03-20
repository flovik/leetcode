namespace Sandbox.Solutions.Hard;

internal class MinimumCostToCutAStick
{
    private readonly Dictionary<(int, int), int> _cache = [];

    public int MinCost(int n, int[] cuts)
    {
        var newCuts = new int[cuts.Length];
        Array.Copy(cuts, newCuts, cuts.Length);
        var result = Backtrack(newCuts, 0, n);
        return result;

        int Backtrack(int[] cuts, int start, int end)
        {
            var curStickLen = end - start;
            var min = int.MaxValue;

            if (_cache.ContainsKey((start, end)))
                return _cache[(start, end)];

            for (var i = 0; i < cuts.Length; i++)
            {
                // to know which cut to make next, compare the cut with the boundary of start and end
                if (cuts[i] > start && cuts[i] < end)
                {
                    var left = Backtrack(cuts, start, cuts[i]);
                    var right = Backtrack(cuts, cuts[i], end);

                    min = Math.Min(min, left + right);
                }
            }

            // base case, if no cuts are left
            if (min == int.MaxValue)
                return 0;

            return _cache[(start, end)] = curStickLen + min;
        }
    }
}