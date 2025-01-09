using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox.Solutions.Easy;

public class CountingWordsWithAGivenPrefix
{
    public int PrefixCount(string[] words, string pref)
    {
        return words.Where(word => word.StartsWith(pref)).Count();
    }
}