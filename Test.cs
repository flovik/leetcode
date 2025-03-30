using System.Text;

namespace Sandbox;

public class Test
{
    private const int diff = 26;

    public int MaxActiveSectionsAfterTrade(string s)
    {
        // one trade to max active
        // 1. convert contigious block of '1' that is surrounded by '0' to all '0'
        // 2. afterwasrd, convert a contigious block of '0' that is surrounded by '1' to all '1's

        // return max of 1's
        // consider s is surrounded with 1 to left and right of S string
        var activeCount = s.Count(e => e == '1');
        var answer = activeCount;
        var augm = '1' + s + '1';

        // sliding window
        var leftZeroFirst = augm.IndexOf('0');
        var leftZeroLast = augm.IndexOf('1', leftZeroFirst + 1) - 1;

        while (leftZeroLast != -1)
        {
            var rigthZeroFirst = augm.IndexOf('0', leftZeroLast + 1);
            var rigthZeroLast = augm.IndexOf('1', rigthZeroFirst + 1) - 1;

            if (rigthZeroLast == -1)
                break;

            var existingOnes = rigthZeroFirst - leftZeroLast - 1;

            var active = rigthZeroLast - leftZeroFirst + 1;

            answer = Math.Max(answer, activeCount - existingOnes + active);

            leftZeroFirst = rigthZeroFirst;
            leftZeroLast = rigthZeroLast;
        }

        return answer;
    }

    public IList<int> PartitionLabels(string s)
    {
        var list = new List<int>();
        var dict = new int[26];

        for (int i = 0; i < s.Length; i++)
        {
            dict[s[i] - 'a']++;
        }

        int left = 0, right = 0;
        var set = new HashSet<char>(26);

        while (right < s.Length)
        {
            set.Add(s[left]);

            while (!set.All(e => dict[e - 'a'] == 0) && right < s.Length)
            {
                if (!set.Contains(s[right]))
                    set.Add(s[right]);

                dict[s[right] - 'a']--;
                right++;
            }

            list.Add(right - left);
            set.Clear();
            left = right;
        }

        return list;
    }

    public int ReverseDegree(string s)
    {
        var sum = 0;

        for (int i = 0; i < s.Length; i++)
        {
            var ch = s[i];

            var num = (i + 1) * (diff - (ch - 'a'));
            sum += num;
        }

        return sum;
    }
}