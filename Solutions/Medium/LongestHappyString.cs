using System.Text;

namespace Sandbox.Solutions.Medium;

public class LongestHappyString
{
    private class MaxHeapComparer : IComparer<int>
    {
        public int Compare(int a, int b) => b.CompareTo(a);
    }

    public string LongestDiverseString(int a, int b, int c)
    {
        // only a b c
        // no aaa, bbb, ccc as substring
        // at most As, Bs and Cs
        var sb = new StringBuilder(a + b + c);
        var pq = new PriorityQueue<char, int>(a + b + c, new MaxHeapComparer());
        pq.Enqueue('a', a);
        pq.Enqueue('b', b);
        pq.Enqueue('c', c);

        while (pq.Count > 0)
        {
            pq.TryPeek(out var ch, out var count);

            if (count <= 0)
                break;

            if (sb.Length == 0 || sb[^1] != ch)
            {
                sb.Append(ch);

                if (count > 1)
                    sb.Append(ch);

                pq.DequeueEnqueue(ch, count - 2);
            }
            else
            {
                pq.TryDequeue(out var bigCh, out var bigCount);

                if (!pq.TryPeek(out var nextCh, out var nextCount) || nextCount == 0)
                    break;

                sb.Append(nextCh);
                pq.DequeueEnqueue(nextCh, nextCount - 1);
                pq.Enqueue(bigCh, bigCount);
            }
        }

        return sb.ToString();
    }
}