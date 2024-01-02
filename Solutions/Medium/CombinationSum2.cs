namespace Sandbox.Solutions.Medium;

public class CombinationSum2Solution
{
    private readonly IList<IList<int>> _result = new List<IList<int>>(150);
    private int[] _candidates;

    public IList<IList<int>> CombinationSum2(int[] candidates, int target)
    {
        Array.Sort(candidates);
        _candidates = candidates;
        BacktrackCombinationSum(new List<int>(candidates.Length), 0, target, 0);
        return _result;
    }

    private void BacktrackCombinationSum(IList<int> current, int currentSum, int target, int start)
    {
        if (currentSum == target)
            _result.Add(new List<int>(current));

        if (currentSum > target)
            return;

        for (int i = start; i < _candidates.Length; i++)
        {
            if (i != start && _candidates[i] == _candidates[i - 1])
                continue;

            current.Add(_candidates[i]);
            BacktrackCombinationSum(current, currentSum + _candidates[i], target, i + 1);
            current.RemoveAt(current.Count - 1);
        }
    }
}