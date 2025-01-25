namespace Sandbox.Solutions.Medium;

public class OptimalPartitionOfString
{
    public int PartitionString(string s)
    {
        var chars = new int[26];
        var result = 1;

        for (int i = 0; i < s.Length; i++)
        {
            var ch = s[i] - 'a';

            if (chars[ch] == 1)
            {
                result++;
                Array.Clear(chars);
            }

            chars[ch]++;
        }

        return result;
    }
}