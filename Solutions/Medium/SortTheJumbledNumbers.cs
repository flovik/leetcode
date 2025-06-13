using System.Text;

namespace Sandbox.Solutions.Medium;

public class SortTheJumbledNumbers
{
    public int[] SortJumbled(int[] mapping, int[] nums)
    {
        var dict = new Dictionary<int, int>(nums.Length);
        var result = new (int, int)[nums.Length];

        for (var i = 0; i < nums.Length; i++)
        {
            result[i] = (nums[i], i);
        }

        foreach (var t in nums)
        {
            var num = t;
            var sb = new StringBuilder();

            while (num > 0)
            {
                var ch = num % 10;
                sb.Append(mapping[ch]);
                num /= 10;
            }

            if (t == 0)
                sb.Append(mapping[0]);

            var st = new string(sb.ToString().Reverse().ToArray());
            var number = int.Parse(st);
            dict.TryAdd(t, number);
        }

        Array.Sort(result, (a, b) => dict[a.Item1] == dict[b.Item1]
            ? a.Item2.CompareTo(b.Item2)
            : dict[a.Item1].CompareTo(dict[b.Item1]));

        return result.Select(a => a.Item1).ToArray();
    }
}