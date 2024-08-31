using NUnit.Framework.Constraints;

namespace Sandbox.Solutions.Medium;

public class CarPooling
{
    public bool CarPoolingSol(int[][] trips, int capacity)
    {
        var pq = new PriorityQueue<int, int>(trips.Length);
        var curCapacity = 0;

        foreach (var trip in trips)
        {
            pq.Enqueue(trip[0], trip[1]); // new people
            pq.Enqueue(-trip[0], trip[2]); // people are going out
        }

        while (pq.Count > 0)
        {
            // while the same point is at the start of queue, consider adding all of them
            pq.TryPeek(out _, out var point);

            while (pq.TryPeek(out var people, out var distance) && point == distance)
            {
                curCapacity += people;
                pq.Dequeue();
            }

            if (curCapacity > capacity)
                return false;
        }

        return true;
    }

    public bool CarPoolingSol2(int[][] trips, int capacity)
    {
        var max = trips.Select(trip => trip[2]).Prepend(0).Max();
        var prefix = new int[max + 1];

        foreach (var trip in trips)
        {
            prefix[trip[1]] += trip[0];
            prefix[trip[2]] -= trip[0];
        }

        var curCapacity = 0;
        foreach (var num in prefix)
        {
            curCapacity += num;

            if (curCapacity > capacity)
                return false;
        }

        return true;
    }
}