namespace Sandbox.Solutions.Medium;

public class Permutations
{
    private readonly IList<IList<int>> _result = new List<IList<int>>(100);

    public IList<IList<int>> Permute(int[] nums)
    {
        Array.Sort(nums);
        BacktrackPermutation(new List<int>(nums.Length), nums, nums.Length);
        return _result;
    }

    private void BacktrackPermutation(IList<int> current, int[] currentNums, int numsLength)
    {
        if (current.Count == numsLength)
        {
            _result.Add(new List<int>(current));
            return;
        }

        foreach (var num in currentNums)
        {
            current.Add(num);
            BacktrackPermutation(current, currentNums.Where(a => a != num).ToArray(), numsLength);
            current.RemoveAt(current.Count - 1);
        }
    }
}