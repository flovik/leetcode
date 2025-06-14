﻿namespace Sandbox.Solutions.Medium;

public class MinimumNumberOfChangesToMakeBinaryStringBeautiful
{
    public int MinChanges(string s)
    {
        var count = 0;

        for (var i = 0; i < s.Length; i += 2)
        {
            if (s[i] != s[i + 1])
                count++;
        }

        return count;
    }
}