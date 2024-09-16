namespace Sandbox.Solutions.Hard;

public class IPO
{
    public int FindMaximizedCapital(int k, int w, int[] profits, int[] capital)
    {
        int n = profits.Length, currentCapital = w;
        var arr = new int[n][];
        var profit = new PriorityQueue<int, int>(k, Comparer<int>.Create((x, y) => y - x));

        for (int i = 0; i < n; i++)
        {
            arr[i] = new[] { profits[i], capital[i] };
        }

        Array.Sort(arr, (a, b) => a[1].CompareTo(b[1]));

        var index = 0;
        while (k > 0)
        {
            // loop thru projects until we are out of current capital, don't return to visited
            for (; index < n; index++)
            {
                var project = arr[index];
                if (project[1] > currentCapital)
                    break;

                profit.Enqueue(project[0], project[0]);
            }

            if (profit.Count == 0)
                break;

            // best project out of current iteration, old ones are still in the max heap!
            currentCapital += profit.Dequeue();
            k--;
        }

        return currentCapital;
    }
}