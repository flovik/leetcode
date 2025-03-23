namespace Sandbox.Solutions.Medium;

public class NumberOfWaysToArriveAtDestination
{
    private const int mod = 1_000_000_007;

    public int CountPaths(int n, int[][] roads)
    {
        // how many ways you can travel from intersection 0 to intersection n - 1 int he shortest amount of time
        // find shortest path for all edges

        var dict = new Dictionary<int, List<(int, long)>>(n);

        for (int i = 0; i < n; i++)
        {
            dict.Add(i, []);
        }

        foreach (var road in roads)
        {
            int from = road[0], to = road[1], cost = road[2];
            dict[from].Add((to, cost));
            dict[to].Add((from, cost));
        }

        var time = new long[n];
        Array.Fill(time, long.MaxValue);
        time[0] = 0;

        var pq = new PriorityQueue<int, long>(n);
        pq.Enqueue(0, 0);

        var dp = new int[n];
        dp[0] = 1;

        var visited = new HashSet<(int, int)>(n);

        while (pq.Count > 0)
        {
            int node = pq.Dequeue();
            long currentTime = time[node];

            foreach (var (neighbor, cost) in dict[node])
            {
                if (visited.Contains((node, neighbor)))
                    continue;

                long newTime = currentTime + cost;
                if (newTime < time[neighbor])
                {
                    time[neighbor] = newTime;
                    dp[neighbor] = dp[node];  // Found a new shortest path, so reset count
                    pq.Enqueue(neighbor, newTime);
                }
                else if (newTime == time[neighbor])
                {
                    // Found an alternative path with the same shortest distance
                    dp[neighbor] = (dp[neighbor] + dp[node]) % mod;
                }

                visited.Add((node, neighbor));
            }
        }

        return dp[^1];
    }
}