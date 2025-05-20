namespace Sandbox.Solutions.Medium;

public class MinimumLimitOfBallsInABag
{
    public int MinimumSize(int[] nums, int maxOperations)
    {
        // penalty is the max number of balls in a bag, minimize it
        int left = 1, right = nums.Max();

        while (left < right)
        {
            var mid = left + (right - left) / 2;

            if (FitsMaxOperationsBagCount(nums, maxOperations, mid))
                right = mid;
            else
                left = mid + 1;
        }

        return left;
    }

    private bool FitsMaxOperationsBagCount(int[] nums, int maxOperations, int bag)
    {
        var count = nums.Sum(num => (int)Math.Ceiling(num * 1.0 / bag));
        return count <= maxOperations + nums.Length;
    }
}