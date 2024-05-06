namespace Sandbox.Solutions.Medium;

public class CheapestFlightsWithingKStops
{
    public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int k)
    {
        // dijkstra's - GIVES TLE
        var adjacencyList = new LinkedList<(int, int)>[n];

        for (var i = 0; i < n; i++)
            adjacencyList[i] = new LinkedList<(int, int)>();

        foreach (var flight in flights)
        {
            var from = flight[0];
            var to = flight[1];
            var curWeight = flight[2];

            adjacencyList[from].AddLast((to, curWeight));
        }

        var pq = new PriorityQueue<int, (int, int)>(n);
        var result = -1;

        foreach (var (to, weight) in adjacencyList[src])
            pq.Enqueue(to, (0, weight)); // to, stops, w

        while (pq.Count != 0)
        {
            pq.TryDequeue(out var from, out var priority);
            var stop = priority.Item1;
            var weight = priority.Item2;

            // can be cycling, those no matter more
            if (stop > k)
                continue;

            // stops in scope of k
            if (stop <= k && from == dst && (result == -1 || result > weight))
                result = weight;

            foreach (var (to, nextWeight) in adjacencyList[from])
                pq.Enqueue(to, (stop + 1, weight + nextWeight));
        }

        return result;
    }

    public int FindCheapestPriceBellmanFord(int n, int[][] flights, int src, int dst, int k)
    {
        var distance = new int[n];
        Array.Fill(distance, int.MaxValue);

        distance[src] = 0;

        for (var i = 0; i <= k; i++)
        {
            var temp = new int[n];
            Array.Copy(distance, temp, n);

            foreach (var flight in flights)
            {
                var from = flight[0];
                var to = flight[1];
                var weight = flight[2];

                if (distance[from] == int.MaxValue)
                    continue;

                temp[to] = Math.Min(temp[to], distance[from] + weight);
            }

            distance = temp;
        }

        return distance[dst] == int.MaxValue ? -1 : distance[dst];
    }
}