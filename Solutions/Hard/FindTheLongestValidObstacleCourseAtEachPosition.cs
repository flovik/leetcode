using System.Runtime.ConstrainedExecution;

namespace Sandbox.Solutions.Hard;

public class FindTheLongestValidObstacleCourseAtEachPosition
{
    public int[] LongestObstacleCourseAtEachPosition(int[] obstacles)
    {
        var n = obstacles.Length;
        var result = new int[n];
        var dp = new List<int>();

        for (var i = 0; i < n; i++)
        {
            var cur = obstacles[i];
            var pos = BinarySearch(dp, cur);

            if (pos == dp.Count)
                dp.Add(cur);
            else
                dp[pos] = cur;

            result[i] = pos + 1;
        }

        return result;
    }

    private int BinarySearch(List<int> list, int target)
    {
        int left = 0, right = list.Count - 1;

        while (left <= right)
        {
            var mid = left + (right - left) / 2;

            if (list[mid] <= target)
                left = mid + 1;
            else
                right = mid - 1;
        }

        return left;
    }
}