namespace Sandbox.Solutions.Medium;

public class Subsets2
{
    public IList<IList<int>> SubsetsWithDup(int[] nums)
    {
        // return all possible subsets
        // no duplicates
        var result = new HashSet<IList<int>>();

        // sort the nums array
        Array.Sort(nums);

        // by adding capacity, Add becomes O(1) instead O(n) while Count != Capacity
        BacktrackSubsets(result, nums, 0, new List<int>(nums.Length + 1));
        return result.ToList();
    }

    private void BacktrackSubsets(ISet<IList<int>> result, int[] nums, int start, IList<int> current)
    {
        result.Add(new List<int>(current));

        for (var i = start; i < nums.Length; i++)
        {
            // skip duplicates (don't skip the starting num of current subset)
            if (start != i && nums[i] == nums[i - 1])
                continue;

            current.Add(nums[i]);
            BacktrackSubsets(result, nums, i + 1, current);
            current.RemoveAt(current.Count - 1);
        }
    }
}