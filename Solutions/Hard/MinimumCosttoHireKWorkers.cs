namespace Sandbox.Solutions.Hard;

public class MinimumCosttoHireKWorkers
{
    public double MincostToHireWorkers(int[] quality, int[] wage, int k)
    {
        // we need smallest ratio
        // sort by rate ascending, take first k, min rate to use is the max rate of k workers we hired
        var arr = new int[quality.Length][];

        for (int i = 0; i < quality.Length; i++)
        {
            arr[i] = new[] { quality[i], wage[i] };
        }

        // quality / wage ratio ascending
        Array.Sort(arr, (a, b) => ((double) b[0] / b[1]).CompareTo((double) a[0] / a[1]));

        var pq = new PriorityQueue<int, int>(k, Comparer<int>.Create((a, b) => b.CompareTo(a)));
        var result = double.MaxValue;
        var totalQuality = 0;

        // we have the current ratio and total quality, we pick the biggest ratio (which is in ascending order)
        foreach (var worker in arr)
        {
            pq.Enqueue(worker[0], worker[0]);
            totalQuality += worker[0];
            var currentRatio = (double) worker[1] / worker[0];

            // as we pick next worker with bigger ratio, we increase the ratio of whole group
            // but remove the worker with highest quality to possibly reduce the cost
            if (pq.Count > k)
                totalQuality -= pq.Dequeue();

            if (pq.Count == k)
                result = Math.Min(result, totalQuality * currentRatio);
        }

        return result;
    }
}