namespace Sandbox.Solutions.Medium;

public class CombinationSumSolution
{
    private int _target;
    private int[] _candidates;
    private readonly IList<IList<int>> _result = new List<IList<int>>(150);

    public IList<IList<int>> CombinationSum(int[] candidates, int target)
    {
        _target = target;
        _candidates = candidates;

        Array.Sort(_candidates);

        BacktrackCombinationSum(new List<int>(10), 0, 0);

        return _result;
    }

    private void BacktrackCombinationSum(IList<int> current, int currentSum, int start)
    {
        if (currentSum == _target)
            _result.Add(new List<int>(current));

        if (currentSum >= _target)
            return;

        for (int i = start; i < _candidates.Length; i++)
        {
            current.Add(_candidates[i]);
            BacktrackCombinationSum(current, currentSum + _candidates[i], i);
            current.RemoveAt(current.Count - 1);
        }
    }
}