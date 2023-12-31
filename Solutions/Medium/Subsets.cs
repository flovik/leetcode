namespace Sandbox.Solutions.Medium;

public class SubsetsSolution
{
    public IList<IList<int>> Subsets(int[] nums)
    {
        // return all possible subsets
        // no duplicates
        var result = new List<IList<int>>();

        // by adding capacity, Add becomes O(1) instead O(n) while Count != Capacity
        BacktrackSubsets(result, nums, 0, new List<int>(nums.Length + 1));
        return result;
    }

    private void BacktrackSubsets(ICollection<IList<int>> result, int[] nums, int start, IList<int> current)
    {
        result.Add(new List<int>(current));

        for (int i = start; i < nums.Length; i++)
        {
            current.Add(nums[i]);
            BacktrackSubsets(result, nums, i + 1, current);
            current.RemoveAt(current.Count - 1);
        }
    }
}