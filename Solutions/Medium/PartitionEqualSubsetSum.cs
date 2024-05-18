namespace Sandbox.Solutions.Medium;

public class PartitionEqualSubsetSum
{
    public bool CanPartition(int[] nums)
    {
        // O (n sum(nums)) time complexity
        // save sums in set
        // start from backwards
        // and with each iteration add the current value to all values in the sum set
        // if sum is already higher, don't add it to the set

        // subset sum equals to total sum / 2, so the half of the total sum
        // if the nums sum is odd, we have no way to get the right answer

        var numsSum = nums.Sum();

        if (numsSum % 2 == 1)
            return false;

        var target = numsSum / 2;

        var setSum = new HashSet<int>(nums.Length) { 0 };

        for (int i = nums.Length - 1; i >= 0; i--)
        {
            foreach (var existingSum in setSum.ToHashSet())
            {
                var possibleTargetSum = nums[i] + existingSum;
                if (possibleTargetSum == target)
                    return true;

                if (possibleTargetSum < target)
                    setSum.Add(possibleTargetSum);
            }
        }

        return false;
    }

    public bool CanPartitionDp(int[] nums)
    {
        // knapsack 0/1
        var sum = nums.Sum();

        if (sum % 2 == 1)
            return false;

        sum /= 2;

        var dp = new bool[sum + 1];
        dp[0] = true;

        foreach (var num in nums)
        {
            for (int j = sum; j > 0; j--)
            {
                if (j < num)
                    continue;

                dp[j] = dp[j - num] || dp[j];
            }
        }

        return dp[sum];
    }
}