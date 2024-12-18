namespace Sandbox.Solutions.Hard;

public class StoneGame3
{
    private const string Alice = nameof(Alice);
    private const string Bob = nameof(Bob);
    private const string Tie = nameof(Tie);

    public string StoneGameIII(int[] stoneValue)
    {
        // alice tries to maximise the score, bob tries to minimize
        // do in recursion
        // do caching of the index
        var cache = new Dictionary<int, int>(stoneValue.Length);
        var result = Recurse(0);

        if (result == 0)
            return Tie;

        return result > 0 ? Alice : Bob;

        int Recurse(int index)
        {
            if (cache.TryGetValue(index, out var value))
                return value;

            // out-of-bounds
            if (index > stoneValue.Length - 1)
                return 0;

            var sum = 0;
            var val = int.MinValue;

            for (var i = 0; i < 3 && index + i < stoneValue.Length; i++)
            {
                sum += stoneValue[index + i];
                // Maximize Alice's score by minimizing Bob's score (inverted result)
                val = Math.Max(val, sum - Recurse(index + i + 1));
            }

            cache.TryAdd(index, val);
            return val;
        }
    }
}