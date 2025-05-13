namespace Sandbox.Solutions.Medium;

public class MinimumLengthOfStringAfterDeletingSimilarEnds
{
    public int MinimumLength(string s)
    {
        // contains a, b, c; if both ends have the same character, remove all of them; continue until valid
        int left = 0, right = s.Length - 1;
        var count = 0;

        while (left < right && s[left] == s[right])
        {
            var ch = s[left];

            while (left < right && s[left] == ch)
            {
                count++;
                left++;
            }

            while (left <= right && s[right] == ch)
            {
                count++;
                right--;
            }
        }

        return s.Length - count;
    }
}