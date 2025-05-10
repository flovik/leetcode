namespace Sandbox.Solutions.Medium;

public class HouseRobber4
{
    public int MinCapability(int[] nums, int k)
    {
        int left = nums.Min(), right = nums.Max();

        while (left < right)
        {
            var mid = left + (right - left) / 2;

            if (CanStealFromHouses(nums, k, mid))
                right = mid;
            else
                left = mid + 1;
        }

        return left;
    }

    private bool CanStealFromHouses(int[] nums, int k, int money)
    {
        var count = 0;

        for (var i = 0; i < nums.Length; i++)
        {
            if (nums[i] > money)
                continue;

            count++;
            i += 1;
        }

        return count >= k;
    }
}