namespace Sandbox.Solutions.Medium;

public class AlternatingGroupsII
{
    public int NumberOfAlternatingGroups(int[] colors, int k)
    {
        // 0 is red, 1 is blue
        var arr = new int[colors.Length * 2];

        Array.Copy(colors, 0, arr, 0, colors.Length);
        Array.Copy(colors, 0, arr, colors.Length, colors.Length);

        int left = 0, right = 1, count = 0, curK = 1;
        var isRed = colors[0] == 0;

        while (left < colors.Length && right < arr.Length)
        {
            if (arr[right] == 0 && !isRed || arr[right] == 1 && isRed)
            {
                isRed = !isRed;
                curK++;
            }
            else
            {
                curK = 1;
                left = right;
            }

            if (curK >= k)
            {
                count++;
                left++;
            }

            right++;
        }

        return count;
    }
}