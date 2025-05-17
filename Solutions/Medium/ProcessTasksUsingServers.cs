namespace Sandbox.Solutions.Medium;

public class ProcessTasksUsingServers
{
    public int[] AssignTasks(int[] servers, int[] tasks)
    {
        var availableServers = new PriorityQueue<int, (int, int)>(servers.Length);
        var busyServers = new PriorityQueue<int, int>(servers.Length); // stores the busy servers and their unlocking time at seconds

        var res = new List<int>(servers.Length);

        // when the time T comes, pop servers from busy servers with time <= T and add to available servers
        for (var i = 0; i < servers.Length; i++)
        {
            availableServers.Enqueue(i, (servers[i], i));
        }

        var taskIndex = 0;
        var curTime = 0;

        while (taskIndex < tasks.Length)
        {
            // no servers available, move to first busy server that will be freed
            if (availableServers.Count == 0)
            {
                busyServers.TryPeek(out _, out var nextUnlockTime);
                curTime = nextUnlockTime;
            }

            // when T time comes, busy servers are freed first
            while (busyServers.TryPeek(out _, out var nextUnlockTime) && curTime >= nextUnlockTime)
            {
                var i = busyServers.Dequeue();
                availableServers.Enqueue(i, (servers[i], i));
            }

            // consider backlogging, so when there are no available servers, all tasks that got to nextUnlockTime must be popped to all available
            // servers simultaneously
            while (taskIndex < tasks.Length
                   && taskIndex <= curTime
                   && availableServers.Count > 0)
            {
                // pop first available server with the smallest weight and index
                // and make it busy

                var taskTime = tasks[taskIndex];

                var server = availableServers.Dequeue();
                res.Add(server);

                busyServers.Enqueue(server, curTime + taskTime);

                taskIndex++;
            }

            // if there are still tasks, but we did not just jump time, move time forward by 1
            if (availableServers.Count > 0 && taskIndex < tasks.Length)
                curTime++;
        }

        return res.ToArray();
    }
}