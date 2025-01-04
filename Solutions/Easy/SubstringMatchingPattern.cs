using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox.Solutions.Easy;

internal class SubstringMatchingPattern
{
    public bool HasMatch(string s, string p)
    {
        var first = p[..p.IndexOf('*')];
        var second = p[(p.IndexOf('*') + 1)..];

        var firstPos = s.IndexOf(first);

        if (firstPos == -1)
            return false;

        var secondPos = s.IndexOf(second, firstPos + first.Length);

        return secondPos == -1 ? false : true;
    }
}