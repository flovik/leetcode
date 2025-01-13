using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox.Solutions.Medium;

internal class MinimumLengthOfStringAfterOperations
{
    public int MinimumLength(string s)
    {
        var dict = new int[26];

        for (int i = 0; i < s.Length; i++)
        {
            dict[s[i] - 'a']++;

            if (dict[s[i] - 'a'] == 3)
                dict[s[i] - 'a'] = 1;
        }

        return dict.Sum();
    }
}