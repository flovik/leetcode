namespace Sandbox.Solutions.Hard;

public class LFUCache
{
    private readonly Dictionary<int, (int, int)> _frequencyCache;
    private readonly Dictionary<int, LinkedList<int>> _lruCache;
    private readonly Dictionary<int, LinkedListNode<int>> _nodes;

    private static int _maxCapacity;
    private static int _minFrequency;

    public LFUCache(int capacity)
    {
        _frequencyCache = new Dictionary<int, (int, int)>(capacity);
        _lruCache = new Dictionary<int, LinkedList<int>>(capacity);
        _nodes = new Dictionary<int, LinkedListNode<int>>(capacity);
        _maxCapacity = capacity;
        _minFrequency = 0;
    }

    public int Get(int key)
    {
        if (!_frequencyCache.TryGetValue(key, out var frequencyPair))
            return -1;

        // remove old value from previous frequency
        var frequency = frequencyPair.Item1;
        var keys = _lruCache[frequency];
        keys.Remove(_nodes[key]);

        if (keys.Count == 0 && _minFrequency == frequency)
            ++_minFrequency;

        // add the new value to the next frequency
        var value = frequencyPair.Item2;
        AddToCache(key, frequency + 1, value);
        return value;
    }

    public void Put(int key, int value)
    {
        if (_frequencyCache.ContainsKey(key))
        {
            var frequencyAndValue = _frequencyCache[key];
            _frequencyCache[key] = (frequencyAndValue.Item1, value);
            Get(key);
            return;
        }

        // evict LRU, LFU
        if (_frequencyCache.Count == _maxCapacity)
        {
            if (_lruCache.TryGetValue(_minFrequency, out var lru))
            {
                var evictKey = lru.First!.Value;
                lru.RemoveFirst();
                _frequencyCache.Remove(evictKey);
                _nodes.Remove(evictKey);
            }
        }

        _minFrequency = 1;
        AddToCache(key, 1, value);
    }

    private void AddToCache(int key, int frequency, int value)
    {
        _frequencyCache.TryAdd(key, (frequency, value));
        _frequencyCache[key] = (frequency, value);

        _lruCache.TryAdd(frequency, []);
        var node = _lruCache[frequency].AddLast(key);

        _nodes.TryAdd(key, node);
        _nodes[key] = node;
    }
}