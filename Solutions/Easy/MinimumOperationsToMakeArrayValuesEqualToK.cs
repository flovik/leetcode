namespace Sandbox.Solutions.Easy;

public class MinimumOperationsToMakeArrayValuesEqualToK
{
    public int MinOperations(int[] nums, int k)
    {
        // all elements should be higher than k
        if (nums.Any(e => e < k))
            return -1;

        var set = new HashSet<int>(nums);
        set.Remove(k);
        return set.Count;
    }
}