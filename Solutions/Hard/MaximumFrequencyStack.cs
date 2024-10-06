namespace Sandbox.Solutions.Hard;

public class MaximumFrequencyStack
{
    private class MaxHeapComparer : IComparer<(int, DateTime)>
    {
        public int Compare((int, DateTime) a, (int, DateTime) b)
        {
            return b.Item1 == a.Item1 ? b.Item2.CompareTo(a.Item2) : b.Item1.CompareTo(a.Item1);
        }
    }

    // stack-like data structure to push elements to the stack and pop the most frequent element from the stack.
    public class FreqStack
    {
        private readonly PriorityQueue<int, (int, DateTime)> _maxHeap;
        private readonly IDictionary<int, int> _freqDictionary;

        public FreqStack()
        {
            _maxHeap = new PriorityQueue<int, (int, DateTime)>(new MaxHeapComparer());
            _freqDictionary = new Dictionary<int, int>();
        }

        // pushes an integer val onto the top of the stack
        public void Push(int val)
        {
            _freqDictionary.TryAdd(val, 0);
            _freqDictionary[val]++;

            _maxHeap.Enqueue(val, (_freqDictionary[val], DateTime.Now));
        }

        // removes and returns the most frequent element in the stack
        // if a tie, remove closest to the stack's top
        public int Pop()
        {
            var pop = _maxHeap.Dequeue();
            _freqDictionary[pop]--;

            return pop;
        }
    }
}