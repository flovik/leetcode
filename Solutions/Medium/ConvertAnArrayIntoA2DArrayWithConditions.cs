namespace Sandbox.Solutions.Medium;

public class ConvertAnArrayIntoA2DArrayWithConditions
{
    public IList<IList<int>> FindMatrix(int[] nums)
    {
        var result = new List<IList<int>>();
        var dict = new int[201];

        foreach (var num in nums)
        {
            dict[num]++;
        }

        while (dict.Any(e => e > 0))
        {
            var list = new List<int>();

            for (var i = 0; i < 201; i++)
            {
                if (dict[i] == 0)
                    continue;

                list.Add(i);
                dict[i]--;
            }

            result.Add(list);
        }

        return result;
    }
}