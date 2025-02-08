namespace Sandbox.Solutions.Medium;

public class GetEqualSubstringsWithinBudget
{
    public int EqualSubstring(string s, string t, int maxCost)
    {
        int left = 0, right = 0, length = 0, curCost = 0;

        while (right < s.Length)
        {
            var cost = Math.Abs((t[right] - 'a') - (s[right] - 'a'));

            if (curCost + cost <= maxCost)
            {
                curCost += cost;
                right++;
            }
            else
            {
                curCost -= Math.Abs((t[left] - 'a') - (s[left] - 'a'));
                left++;
            }

            length = Math.Max(length, right - left);
        }

        return length;
    }
}