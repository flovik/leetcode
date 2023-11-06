namespace Sandbox.Solutions.Medium;

public class KokoEatingBananas
{
    public int MinEatingSpeed(int[] piles, int h)
    {
        // binary search, when you see some kind of monotonicity, you apply binary search
        // here a big role plays the boundaries you set for left and right and the condition

        int left = 1, right = piles.Max();

        while (left < right)
        {
            var mid = left + (right - left) / 2;
            if (Feasible(piles, mid, h)) // that value is good, is there any better?
                right = mid;
            else
                left = mid + 1;
        }

        return left;
    }

    private bool Feasible(int[] piles, int mid, int h)
    {
        // calculate if each pile is enough to be eaten in the mid bananas/hour
        // (pile - 1) / mid + 1 = Math.Ceiling (pile / mid)
        var totalTime = piles.Sum(pile => (pile - 1) / mid + 1);
        return totalTime <= h;
    }
}