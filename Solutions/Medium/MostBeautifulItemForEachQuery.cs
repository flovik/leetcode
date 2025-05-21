using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox.Solutions.Medium;
internal class MostBeautifulItemForEachQuery
{
    public int[] MaximumBeauty(int[][] items, int[] queries)
    {
        var result = new int[queries.Length];

        Array.Sort(items, (a, b) =>
        {
            if (a[0] == b[0])
                return a[1].CompareTo(b[1]);

            return a[0].CompareTo(b[0]);
        });

        // merge intervals and take previous intervals max beauty and compare to current
        var list = new List<int[]>(items.Length) { items[0] };

        for (int i = 1; i < items.Length; i++)
        {
            if (items[i][0] == list[^1][0]) list[^1][1] = Math.Max(list[^1][1], items[i][1]);
            else
            {
                list.Add(items[i]);
                list[^1][1] = Math.Max(list[^1][1], list[^2][1]);
            }
        }

        for (var i = 0; i < queries.Length; i++)
        {
            var query = queries[i];
            var index = BinarySearch(list, query);

            if (query < list[index][0])
                result[i] = 0;
            else
                result[i] = list[index][1];
        }

        return result;
    }

    private int BinarySearch(List<int[]> items, int target)
    {
        int left = 0, right = items.Count - 1;
        var answer = 0;

        while (left <= right)
        {
            var mid = (left + right) / 2;

            if (items[mid][0] <= target)
            {
                answer = mid;
                left = mid + 1;
            }
            else
                right = mid - 1;
        }

        return answer;
    }
}
