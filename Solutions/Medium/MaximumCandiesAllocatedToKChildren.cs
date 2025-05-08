namespace Sandbox.Solutions.Medium;

public class MaximumCandiesAllocatedToKChildren
{
    public int MaximumCandies(int[] candies, long k)
    {
        var max = candies.Max();
        int left = 0, right = max;

        while (left < right)
        {
            var mid = (left + right + 1) / 2;

            if (!CanAllocateCandiesToChildrenFromEachPile(candies, k, mid))
                right = mid - 1;
            else
                left = mid;
        }

        return left;
    }

    private bool CanAllocateCandiesToChildrenFromEachPile(int[] candies, long k, long candiesPerChild)
    {
        long countOfChildren = 0;

        foreach (var pile in candies)
        {
            var count = pile / candiesPerChild;
            countOfChildren += count;
        }

        return countOfChildren >= k;
    }
}