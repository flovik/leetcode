using System.Drawing;

namespace Sandbox.Solutions.Medium;

public class MaximumPointsInsideTheSquare
{
    public int MaxPointsInsideSquare(int[][] points, string s)
    {
        var existingTags = new HashSet<char>(s.Length);
        var pq = new PriorityQueue<int, int>(points.Length);

        for (int i = 0; i < points.Length; i++)
        {
            var point = points[i];
            var priority = Math.Max(Math.Abs(point[0]), Math.Abs(point[1]));
            pq.Enqueue(i, priority);
        }

        var result = 0;
        var currentSide = -1;
        while (pq.Count != 0)
        {
            pq.TryPeek(out _, out var p);

            if (currentSide < p)
            {
                result = existingTags.Count;
                currentSide = p;
            }

            var index = pq.Dequeue();

            if (!existingTags.Add(s[index]))
                return result;
        }

        return existingTags.Count;
    }
}