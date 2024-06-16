namespace Sandbox.Solutions.Medium;

public class UglyNumber2
{
    public int NthUglyNumber(int n)
    {
        // n - pos int whose prime factors are limited to 2, 3 and 5
        // return nth ugly number
        var pq = new PriorityQueue<long, long>(n);
        pq.Enqueue(1, 1);

        var set = new HashSet<long>(n) { 1 };

        var uglyNumbersCount = 1;

        while (uglyNumbersCount != n)
        {
            var cur = pq.Dequeue();

            var list = new List<(long, long)>(3);

            if (!set.Contains(cur * 2))
            {
                set.Add(cur * 2);
                list.Add((cur * 2, cur * 2));
            }

            if (!set.Contains(cur * 3))
            {
                set.Add(cur * 3);
                list.Add((cur * 3, cur * 3));
            }

            if (!set.Contains(cur * 5))
            {
                set.Add(cur * 5);
                list.Add((cur * 5, cur * 5));
            }

            pq.EnqueueRange(list);

            uglyNumbersCount++;
        }

        return (int) pq.Peek();
    }
}