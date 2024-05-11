using System.Collections;

namespace Sandbox.Solutions.Hard;

public class ReconstructItinerary
{
    public IList<string> FindItinerary(IList<IList<string>> tickets)
    {
        // graph must be eulerian since we know that a eulerian path exists
        // hierholzer's algorithm to find Eulerian path in the path which is a valid reconstruction
        // put neighbours in a min-heap, we always visit the smallest possible neighbor first in our trip

        var dict = new Dictionary<string, PriorityQueue<string, string>>(tickets.Count);
        var st = new Stack<string>();
        foreach (var ticket in tickets)
        {
            if (!dict.ContainsKey(ticket[0]))
                dict[ticket[0]] = new PriorityQueue<string, string>();

            dict[ticket[0]].Enqueue(ticket[1], ticket[1]);
        }

        var result = new List<string>(dict.Count + 1);

        // start from JFK and traverse
        Dfs("JFK");

        result.Reverse();
        return result;

        void Dfs(string departure)
        {
            while (dict.TryGetValue(departure, out var pq) && pq.Count != 0)
            {
                Dfs(pq.Dequeue());
            }

            result.Add(departure);
        }
    }
}