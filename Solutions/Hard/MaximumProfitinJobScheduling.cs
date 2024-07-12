namespace Sandbox.Solutions.Hard;

public class MaximumProfitinJobScheduling
{
    public int JobScheduling(int[] startTime, int[] endTime, int[] profit)
    {
        var len = startTime.Length;
        var jobs = new int[len][];

        for (int i = 0; i < len; i++)
        {
            jobs[i] = new[] { startTime[i], endTime[i], profit[i] };
        }

        // sort by end time
        Array.Sort(jobs, (a, b) => a[1].CompareTo(b[1]));

        // dictionary of jobs with the same end (2,5 -> 2, 3,5 -> 8), we will take the 8 as the biggest one
        var dictEndBiggestProfit = new Dictionary<int, int>(endTime.Length) { { jobs[0][1], jobs[0][2] } };
        var max = jobs[0][2];

        for (var i = 1; i < jobs.Length; i++)
        {
            var job = jobs[i];

            // find prev job by end time
            var index = BinarySearch(jobs, job[0]);

            if (index < 0)
                index = ~index;

            var prevJob = jobs[index];

            // we have multiple jobs with same ending, take the biggest one
            var prevJobProfit = dictEndBiggestProfit.GetValueOrDefault(prevJob[1], prevJob[2]);

            // if current job has the start further than previous job end, we can add the
            // profit of previous job to our new profit, if not just take the current profit
            var newProfit = job[0] >= prevJob[1] ? prevJobProfit + job[2] : job[2];

            // current profit -> new profit or global max profit?
            job[2] = Math.Max(newProfit, max);
            max = Math.Max(max, job[2]);

            // update dict with same ends with biggest profit
            if (!dictEndBiggestProfit.TryAdd(job[1], job[2]))
                dictEndBiggestProfit[job[1]] = Math.Max(dictEndBiggestProfit[job[1]], job[2]);
        }

        return max;
    }

    private int BinarySearch(int[][] arr, int target)
    {
        int left = 0, right = arr.Length - 1;

        while (left <= right)
        {
            var mid = (left + right) / 2;
            if (arr[mid][1] == target)
                return mid;
            if (arr[mid][1] > target)
                right = mid - 1;
            else
                left = mid + 1;
        }

        return ~right;
    }
}