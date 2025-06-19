namespace Sandbox.Solutions.Medium;

public class FindTheLengthOfLongestCommonPrefix
{
    public int LongestCommonPrefix(int[] arr1, int[] arr2)
    {
        // length of longest common prefix between all pairs in arr1 and arr2

        var max = 0;
        var set = new HashSet<string>(arr1.Select(e => e.ToString()));

        foreach (var num in arr1)
        {
            var str = num.ToString();

            for (var i = 1; i <= str.Length; i++)
            {
                set.Add(str[..i]);
            }
        }

        foreach (var num in arr2)
        {
            var str = num.ToString();

            for (var i = 1; i <= str.Length; i++)
            {
                if (set.Contains(str[..i]))
                    max = Math.Max(max, i);
            }
        }

        return max;
    }
}