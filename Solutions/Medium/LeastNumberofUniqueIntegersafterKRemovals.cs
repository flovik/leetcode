namespace Sandbox.Solutions.Medium;

public class LeastNumberofUniqueIntegersafterKRemovals
{
    public int FindLeastNumOfUniqueInts(int[] arr, int k)
    {
        // greedy, priority queue, dictionary
        var dict = new Dictionary<int, int>(arr.Length);

        foreach (var i in arr)
        {
            dict.TryAdd(i, 0);
            dict[i]++;
        }

        var pq = new PriorityQueue<int, int>(dict.Count);

        foreach (var (key, val) in dict)
        {
            pq.Enqueue(key, val);
        }

        while (k > 0)
        {
            pq.TryPeek(out _, out var p);

            if (k < p)
                break;

            pq.Dequeue();
            k -= p;
        }

        return pq.Count;
    }
}