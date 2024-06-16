namespace Sandbox.Solutions.Medium;

public class FindKPairswithSmallestSums
{
    public class MaxHeapComparer : IComparer<int>
    {
        public int Compare(int a, int b) => b.CompareTo(a);
    }

    public IList<IList<int>> KSmallestPairs(int[] nums1, int[] nums2, int k)
    {
        var result = new List<IList<int>>(k);

        var pq = new PriorityQueue<int[], int>(k, new MaxHeapComparer());

        foreach (var num1 in nums1)
        {
            foreach (var num2 in nums2)
            {
                if (pq.Count == k)
                {
                    if (pq.Peek()[0] + pq.Peek()[1] > num1 + num2)
                        pq.Dequeue();
                    else
                        break;
                }

                pq.Enqueue(new[] { num1, num2 }, num1 + num2);
            }
        }

        while (k > 0)
        {
            result.Add(pq.Dequeue());
            k--;
        }

        return result;
    }
}