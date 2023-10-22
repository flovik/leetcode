namespace Sandbox.Solutions.Medium;

public class GroupAnagrams
{
    private IDictionary<string, IList<string>> _groups = new Dictionary<string, IList<string>>();
    public IList<IList<string>> GroupAnagramsSol(string[] strs)
    {
        foreach (var str in strs)
        {
            var group = str.ToCharArray();
            Array.Sort(group);
            var groupStr = new string(group);
            if (_groups.ContainsKey(groupStr)) _groups[groupStr].Add(str);
            else _groups.Add(new KeyValuePair<string, IList<string>>(groupStr, new List<string>(){str}));
        }

        var result = new List<IList<string>>();
        foreach (var group in _groups)
        {
            result.Add(group.Value);
        }

        return result;
    }
}