namespace Sandbox.Solutions.Medium;

public class CapacityToShipPackagesWithinDDays
{
    public int ShipWithinDays(int[] weights, int days)
    {
        // binary search, monotonicity remember?
        // least weight capacity of the ship that will result in all the packages being shipped within D days
        // the left is max(weight[i]) and right is the sum(weights) and binary search between those values an appropriate value

        int left = weights.Max(), right = weights.Sum();

        while (left < right)
        {
            int mid = left + (right - left) / 2;
            if (Feasible(weights, days, mid))
                right = mid;
            else
                left = mid + 1;
        }

        return left;
    }

    private bool Feasible(int[] weights, int days, int totalCapacity)
    {
        // imagine we have the totalCapacity of 10 and 55 which is 32, see how much we can place packages into it
        // and if can place everything within given days, return true

        var totalDays = 0;
        var currentCapacity = totalCapacity;

        foreach (var weight in weights)
        {
            currentCapacity -= weight;
            if (currentCapacity >= 0)
                continue;

            totalDays++;

            // the package is too heavy, so place it for the next day
            currentCapacity = totalCapacity - weight;
        }

        // last day package also should be delivered
        return (totalDays + 1) <= days;
    }
}