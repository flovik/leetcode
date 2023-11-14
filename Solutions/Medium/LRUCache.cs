namespace Sandbox.Solutions.Medium;

public class LRUCache
{
    private readonly int _capacity;
    private readonly IDictionary<int, LinkedListNode<DoublyNodeData>> _cache;
    private readonly LinkedList<DoublyNodeData> _cacheLinkedList;

    public LRUCache(int capacity)
    {
        _capacity = capacity;
        _cache = new Dictionary<int, LinkedListNode<DoublyNodeData>>(capacity);
        _cacheLinkedList = new LinkedList<DoublyNodeData>();
    }

    public int Get(int key)
    {
        _cache.TryGetValue(key, out var node);
        if (node is null)
            return -1;

        // remove updates node O(1)
        _cacheLinkedList.Remove(node);

        // and insert to the back as the most fresh O(1)
        _cacheLinkedList.AddLast(node);

        return node.Value.Data;
    }

    public void Put(int key, int value)
    {
        // if we have the node in the dictionary
        if (_cache.TryGetValue(key, out var node))
        {
            // update its value and freshness O(1)
            node.Value.Data = value;

            // remove updates node O(1)
            _cacheLinkedList.Remove(node);

            // and insert to the back as the most fresh O(1)
            _cacheLinkedList.AddLast(node);
        }
        else
        {
            // add value to linked list as last (most fresh)
            var newNode = _cacheLinkedList.AddLast(new DoublyNodeData(value, key));

            // if capacity is passed, delete the oldest node and update list and dictionary
            if (_cache.Count == _capacity)
            {
                var removedFirst = _cacheLinkedList.First;
                _cacheLinkedList.RemoveFirst();
                _cache.Remove(removedFirst.Value.DictionaryKey);
            }

            _cache.Add(key, newNode);
        }
    }
}

public class DoublyNodeData
{
    public int Data { get; set; }
    public int DictionaryKey { get; set; }

    public DoublyNodeData(int data, int dictionaryKey)
    {
        Data = data;
        DictionaryKey = dictionaryKey;
    }
}