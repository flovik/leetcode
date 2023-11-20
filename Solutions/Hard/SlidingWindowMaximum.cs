namespace Sandbox.Solutions.Hard;

internal class SlidingWindowMaximum
{
    private readonly PriorityQueue<(int, int), int> priorityQueue = new(new MaxHeapComparer());

    private class MaxHeapComparer : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            return y.CompareTo(x);
        }
    }

    public int[] MaxSlidingWindow(int[] nums, int k)
    {
        // set the values in place of the nums array and specifically where start is leaving
        int start = 0, end = 0;
        while (end < nums.Length)
        {
            // enqueue the number itself and the index
            priorityQueue.Enqueue((nums[end], end), nums[end]);

            if (end - start + 1 == k)
            {
                while (priorityQueue.Peek().Item2 < start)
                {
                    // drop outside window values
                    priorityQueue.Dequeue();
                }

                nums[start] = priorityQueue.Peek().Item1;
                start++;
            }

            end++;
        }

        return nums[..start];
    }
}