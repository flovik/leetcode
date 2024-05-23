namespace Sandbox.Solutions.Medium;

public class PartitiontoKEqualSumSubsets
{
    public bool CanPartitionKSubsets(int[] nums, int k)
    {
        var sum = nums.Sum();

        if (sum % k != 0)
            return false;

        var target = sum / k;
        var visitedIndexes = new bool[nums.Length];

        return Backtrack(k);

        bool Backtrack(int curIteration, int current = 0, int start = 0)
        {
            if (curIteration == 1)
                return true;
            if (current == target)
                return Backtrack(curIteration - 1);

            for (var i = start; i < nums.Length; i++)
            {
                if (visitedIndexes[i] || current + nums[i] > target)
                    continue;

                visitedIndexes[i] = true;

                if (Backtrack(curIteration, current + nums[i], i))
                    return true;

                visitedIndexes[i] = false;
            }

            return false;
        }
    }
}