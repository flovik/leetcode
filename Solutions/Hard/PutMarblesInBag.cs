namespace Sandbox.Solutions.Hard;

public class PutMarblesInBag
{
    public long PutMarbles(int[] weights, int k)
    {
        // you need to make k - 1 cuts, each cut adds the sum of the adjacent weights to the total score (where the cut was done)
        // first and last element of the array is always added
        // finding the maximum and minimum possible sums of k-1 adjacent pair costs
        // for every pair (i, i + 1) add them in priority queue and pick K-1 largest for maximum and K-1 smallest for minimum
        // formula = weight(0) + weight(^1) + Sum (cuts(i, i+1))

        var minHeap = new PriorityQueue<int, int>(weights.Length);
        var maxHeap = new PriorityQueue<int, int>(weights.Length, Comparer<int>.Create((a, b) => b.CompareTo(a)));

        for (int i = 0; i < weights.Length - 1; i++)
        {
            minHeap.Enqueue(weights[i] + weights[i + 1], weights[i] + weights[i + 1]);
            maxHeap.Enqueue(weights[i] + weights[i + 1], weights[i] + weights[i + 1]);
        }

        var min = weights[0] + weights[^1];
        var max = weights[0] + weights[^1];

        for (int i = 0; i < k - 1; i++)
        {
            min += minHeap.Dequeue();
            max += maxHeap.Dequeue();
        }

        return max - min;
    }
}