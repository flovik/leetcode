using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox.Solutions.Medium;

internal class WordSubsets
{
    public IList<string> WordSubsetsSol(string[] words1, string[] words2)
    {
        var dict = new int[26];

        // merge words2 into one
        var temp = new int[26];
        foreach (var word2 in words2)
        {
            foreach (var ch in word2)
            {
                temp[ch - 'a']++;
            }

            for (var i = 0; i < 26; i++)
            {
                dict[i] = Math.Max(dict[i], temp[i]);
            }

            Array.Clear(temp);
        }

        var list = new List<string>(words1.Length);
        var count = new int[26];

        foreach (var word in words1)
        {
            foreach (var ch in word)
            {
                count[ch - 'a']++;
            }

            if (IsUniversal(count, dict))
                list.Add(word);

            Array.Clear(count);
        }

        return list;
    }

    private bool IsUniversal(int[] a, int[] b)
    {
        for (int i = 0; i < 26; i++)
        {
            if (a[i] < b[i])
                return false;
        }

        return true;
    }
}