namespace Sandbox.Solutions.Easy;

public class LastStoneWeight
{
    private readonly PriorityQueue<int, int> _maxHeap = new(new MaxHeapComparer());

    private class MaxHeapComparer : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            return y.CompareTo(x);
        }
    }

    public int LastStoneWeight2(int[] stones)
    {
        // heavies 2 stones and smash together
        // x == y, both are destroyed
        // x != y, x - y stone remained
        // at most one stone left
        foreach (var stone in stones)
        {
            _maxHeap.Enqueue(stone, stone);
        }

        while (_maxHeap.Count > 1)
        {
            var x = _maxHeap.Dequeue();
            var y = _maxHeap.Dequeue();

            var value = Math.Abs(x - y);
            if (value != 0)
                _maxHeap.Enqueue(value, value);
        }

        return _maxHeap.Count > 0 ? _maxHeap.Peek() : 0;
    }
}