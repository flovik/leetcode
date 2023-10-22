namespace Sandbox.Solutions.Medium;

public class SortColors
{
    public void Solution(int[] nums)
    {
        int zeros = 0, ones = 0, twos = 0;
        foreach (var num in nums)
        {
            switch (num)
            {
                case 0:
                    zeros++;
                    break;
                case 1:
                    ones++;
                    break;
                case 2:
                    twos++;
                    break;
            }
        }

        int index = 0;
        while (zeros != 0)
        {
            nums[index++] = 0;
            zeros--;
        }

        while (ones != 0)
        {
            nums[index++] = 1;
            ones--;
        }

        while (twos != 0)
        {
            nums[index++] = 2;
            twos--;
        }
    }
}