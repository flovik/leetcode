namespace Sandbox.Solutions.Medium;

public class FindAllAnagramsinaString
{
    public IList<int> FindAnagrams(string s, string p)
    {
        if (p.Length > s.Length)
            return new List<int>();

        var list = new List<int>(s.Length);
        var map = new Dictionary<char, int>(p.Length);
        var set = new HashSet<char>(p.Length);

        foreach (var c in p)
        {
            if (map.ContainsKey(c))
                map[c]++;
            else
                map.Add(c, 1);
        }

        int left = 0, right = -1;
        var isValid = p.Length;

        while (right != p.Length - 1)
        {
            right++;

            if (!map.ContainsKey(s[right]))
                continue;

            map[s[right]]--;
            isValid--;

            if (map[s[right]] <= 0)
                set.Add(s[right]);
        }

        while (right < s.Length)
        {
            if (isValid <= 0 && set.Count == map.Count)
                list.Add(left);

            if (map.ContainsKey(s[left]))
            {
                map[s[left]]++;
                isValid++;

                if (map[s[left]] > 0)
                    set.Remove(s[left]);
            }

            left++;
            right++;

            if (right == s.Length || !map.ContainsKey(s[right]))
                continue;

            map[s[right]]--;
            isValid--;

            if (map[s[right]] <= 0)
                set.Add(s[right]);
        }

        return list;
    }
}