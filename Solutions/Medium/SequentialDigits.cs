namespace Sandbox.Solutions.Medium;

public class SequentialDigits
{
    public IList<int> SequentialDigitsSol(int low, int high)
    {
        var list = new List<int>();

        for (int i = 1; i < 9; i++)
        {
            var value = i;

            while (value < high)
            {
                if (value % 10 == 9)
                    break;

                var next = value % 10 + 1;
                value = value * 10 + next;

                if (value >= low && value <= high)
                    list.Add(value);
            }
        }

        list.Sort();
        return list;
    }
}