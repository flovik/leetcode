using System.Text;

namespace Sandbox.Solutions.Medium;

public class SortCharactersByFrequency
{
    private class MaxHeapComparer : IComparer<int>
    {
        public int Compare(int a, int b) => b.CompareTo(a);
    }

    public string FrequencySort(string s)
    {
        var map = new Dictionary<char, int>(s.Length);

        foreach (var c in s)
        {
            map.TryAdd(c, 0);
            map[c]++;
        }

        var pq = new PriorityQueue<char, int>(map.Count, new MaxHeapComparer());

        foreach (var (key, value) in map)
        {
            pq.Enqueue(key, value);
        }

        var sb = new StringBuilder(pq.Count);
        while (pq.Count > 0)
        {
            pq.TryDequeue(out var element, out var p);

            for (int i = 0; i < p; i++)
            {
                sb.Append(element);
            }
        }

        return sb.ToString();
    }
}