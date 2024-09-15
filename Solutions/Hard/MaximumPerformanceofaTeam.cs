namespace Sandbox.Solutions.Hard;

public class MaximumPerformanceofaTeam
{
    public int MaxPerformance(int n, int[] speed, int[] efficiency, int k)
    {
        long result = 0, curSum = 0;
        var arr = new (int, int)[n];
        var pq = new PriorityQueue<int, int>(k);

        for (var i = 0; i < speed.Length; i++)
        {
            arr[i] = (speed[i], efficiency[i]);
        }

        Array.Sort(arr, (a, b) => b.Item2.CompareTo(a.Item2));

        for (var i = 0; i < arr.Length; i++)
        {
            pq.Enqueue(arr[i].Item1, arr[i].Item1);
            curSum += arr[i].Item1;

            if (pq.Count > k)
                curSum -= pq.Dequeue();

            result = Math.Max(result, curSum * arr[i].Item2);
        }

        return (int) (result % 1_000_000_007);
    }
}