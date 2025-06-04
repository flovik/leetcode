namespace Sandbox.Solutions.Medium;

public class SeparateBlackAndWhiteBalls
{
    public long MinimumSteps(string s)
    {
        long count = 0;

        int left = 0, right = s.Length - 1;

        while (left < right)
        {
            while (left < right && s[right] == '1')
                right--;

            while (left < right & s[left] == '0')
                left++;

            count += right - left;
            left++;
            right--;
        }

        return count;
    }
}
