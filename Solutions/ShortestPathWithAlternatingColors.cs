using System.Reflection.Metadata;

namespace Sandbox.Solutions;

public class ShortestPathWithAlternatingColors
{
    public int[] ShortestAlternatingPaths(int n, int[][] redEdges, int[][] blueEdges)
    {
        var redDict = new Dictionary<int, HashSet<int>>(n);
        var blueDict = new Dictionary<int, HashSet<int>>(n);

        for (var i = 0; i < n; i++)
        {
            redDict.TryAdd(i, []);
            blueDict.TryAdd(i, []);
        }

        foreach (var red in redEdges)
        {
            redDict[red[0]].Add(red[1]);
        }

        foreach (var blue in blueEdges)
        {
            blueDict[blue[0]].Add(blue[1]);
        }

        var ans = new int[n];
        Array.Fill(ans, int.MaxValue);

        // from, color (false for red, true for blue), moves
        var queue = new Queue<(int, bool, int)>(n);

        // start from both 0 node with red edge and right edge
        queue.Enqueue((0, false, 0));
        queue.Enqueue((0, true, 0));

        while (queue.Count > 0)
        {
            var (node, color, moves) = queue.Dequeue();

            ans[node] = Math.Min(ans[node], moves);

            var dict = color ? redDict : blueDict;

            foreach (var to in dict[node].ToList())
            {
                // alternate the color on next move
                queue.Enqueue((to, !color, moves + 1));
                dict[node].Remove(to); // visited
            }
        }

        for (var i = 0; i < n; i++)
        {
            ans[i] = ans[i] == int.MaxValue ? -1 : ans[i];
        }

        return ans;
    }
}