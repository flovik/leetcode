namespace Sandbox.Solutions.Hard;

public class SmallestRangeCoveringElementsFromKLists
{
    public int[] SmallestRange(IList<IList<int>> nums)
    {
        // smallest range that includes at least one number from each of K lists
        var set = new int[nums.Count];
        var result = new[] { 10000, 20000 };

        var list = new List<(int, int)>();

        for (var i = 0; i < nums.Count; i++)
        {
            list.AddRange(nums[i].Select(e => (e, i)));
        }

        list.Sort((a, b) => a.Item1.CompareTo(b.Item1));

        int left = 0, right = 0;
        var covered = 0;

        while (right < list.Count)
        {
            if (set[list[right].Item2] == 0)
                covered++;

            set[list[right].Item2]++;

            while (covered == nums.Count)
            {
                if (list[right].Item1 - list[left].Item1 < result[1] - result[0])
                {
                    result[0] = list[left].Item1;
                    result[1] = list[right].Item1;
                }

                if (set[list[left].Item2] == 1)
                    covered--;

                set[list[left].Item2]--;
                left++;
            }

            right++;
        }

        return result;
    }
}