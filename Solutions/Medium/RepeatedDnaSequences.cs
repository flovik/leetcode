using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox.Solutions.Medium;

public class RepeatedDnaSequences
{
    public IList<string> FindRepeatedDnaSequences(string s)
    {
        var dict = new Dictionary<string, int>(s.Length);
        int left = 0, right = 9;

        while (right < s.Length)
        {
            var str = s[left..(right + 1)];

            dict.TryAdd(str, 0);
            dict[str]++;
            left++;
            right++;
        }

        return dict.Where(e => e.Value > 1).Select(e => e.Key).ToList();
    }
}