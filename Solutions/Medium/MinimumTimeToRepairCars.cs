namespace Sandbox.Solutions.Medium;

public class MinimumTimeToRepairCars
{
    public long RepairCars(int[] ranks, int cars)
    {
        long low = 1, high = 1L * ranks[0] * cars * cars;

        // how many cars can mechanic[i] repair within "mid" time
        while (low < high)
        {
            var mid = low + (high - low) / 2;

            if (CanConstruct(ranks, cars, mid))
                high = mid;
            else
                low = mid + 1;
        }

        return low;
    }

    private bool CanConstruct(int[] ranks, int cars, long time)
    {
        long count = 0;

        foreach (var rank in ranks)
        {
            var timeToRepair = (long)Math.Sqrt(1.0 * time / rank);
            count += timeToRepair;
        }

        return count >= cars;
    }
}