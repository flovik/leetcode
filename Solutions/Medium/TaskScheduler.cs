namespace Sandbox.Solutions.Medium;

public class TaskScheduler
{
    private readonly PriorityQueue<char, int> _maxHeap = new(new MaxHeapComparer());
    private readonly IDictionary<char, int> _dict = new Dictionary<char, int>();

    private class MaxHeapComparer : IComparer<int>
    {
        public int Compare(int x, int y) => y.CompareTo(x);
    }

    public int LeastInterval(char[] tasks, int n)
    {
        // as values are ordered in decreasing order in max heap, we can calculate number of
        // tasks and in-between

        foreach (var task in tasks)
        {
            if (_dict.ContainsKey(task))
                _dict[task]++;
            else
                _dict.Add(task, 1);
        }

        foreach (var (key, value) in _dict)
        {
            _maxHeap.Enqueue(key, value);
        }

        var result = 0;

        while (_maxHeap.Count > 0)
        {
            // n = cooldown period, n + 1 is a full cycle period (one task and it will cooldown in n steps, so n + 1)
            var cycle = n + 1;
            var remaining = new List<(char, int)>();

            // until cycle is exhausted, pop elements out of the queue
            while (cycle > 0 && _maxHeap.Count > 0)
            {
                var biggestTask = _maxHeap.Dequeue();
                var biggestTaskFrequency = _dict[biggestTask];

                // if its frequency is more than once, lower it's frequency
                if (biggestTaskFrequency > 1)
                    remaining.Add((biggestTask, biggestTaskFrequency - 1));

                _dict[biggestTask] = biggestTaskFrequency - 1;

                result++;
                cycle--;
            }

            // popped elements are still have frequency are added to the queue
            foreach (var (item, priority) in remaining)
            {
                _maxHeap.Enqueue(item, priority);
            }

            // add idle time into time count
            if (_maxHeap.Count == 0)
                break;

            // not used cycle time is appended as Idle time
            result += cycle;
        }

        return result;
    }
}