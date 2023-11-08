namespace Sandbox.Solutions.Medium;

public class TimeBasedKeyValueStore
{
    private readonly IDictionary<string, IList<(int, string)>> _map = new Dictionary<string, IList<(int, string)>>();

    public void Set(string key, string value, int timestamp)
    {
        if (!_map.ContainsKey(key))
            _map.Add(key, new List<(int, string)>(new[] { (timestamp, value) }));
        else
            _map[key].Add((timestamp, value));
    }

    public string Get(string key, int timestamp)
    {
        // binary search by timestamp
        if (!_map.ContainsKey(key))
            return "";

        if (_map[key].Count == 0)
            return "";

        var collection = _map[key];
        return BinarySearch(timestamp, collection);
    }

    private string BinarySearch(int timestamp, IList<(int, string)> collection)
    {
        int left = 0, right = collection.Count;
        while (left < right)
        {
            var mid = left + (right - left) / 2;

            if (collection[mid].Item1 > timestamp)
                right = mid;
            else
                left = mid + 1;
        }

        return left > 0 && left <= collection.Count ? collection[right - 1].Item2 : "";
    }
}