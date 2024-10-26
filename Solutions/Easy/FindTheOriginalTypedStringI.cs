namespace Sandbox.Solutions.Easy;

public class FindTheOriginalTypedStringI
{
    public int PossibleStringCount(string word)
    {
        // if a sub-sequence includes more characters, add its length - 1
        var result = 1;
        var ch = ' ';

        foreach (var c in word)
        {
            if (ch == c)
                result++;
            else
                ch = c;
        }

        return result;
    }
}