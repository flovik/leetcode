namespace Sandbox.Solutions.Medium;

public class MinimizedMaximumOfProductsDistributedToAnyStore
{
    public int MinimizedMaximum(int n, int[] quantities)
    {
        int left = 1, right = quantities.Max();

        while (left < right)
        {
            var mid = left + (right - left) / 2;

            if (CanDistributeProductsToNStores(n, quantities, mid))
                right = mid;
            else
                left = mid + 1;
        }

        return left;
    }

    private bool CanDistributeProductsToNStores(int n, int[] quantities, int target)
    {
        var stores = 0;

        foreach (var quantity in quantities)
        {
            stores += (int)Math.Ceiling((double)quantity / target);

            if (stores > n)
                return false;
        }

        return stores <= n;
    }
}