namespace Sandbox.Solutions.Medium;

public class TaskManager
{
    public class MaxHeapComparer : IComparer<(int, int)>
    {
        // (priority, taskId)
        public int Compare((int, int) x, (int, int) y)
        {
            if (x.Item1 == y.Item1)
                return y.Item2.CompareTo(x.Item2);

            return y.Item1.CompareTo(x.Item1);
        }
    }

    private Dictionary<int, HashSet<int>> _userTasks = [];
    private int[] _task = new int[100001]; // saves userId
    private int[] _priority = new int[100001];
    private PriorityQueue<int, (int, int)> _pq = new(new MaxHeapComparer());

    public TaskManager(IList<IList<int>> tasks)
    {
        Array.Fill(_task, -1);
        Array.Fill(_priority, -1);

        foreach (var item in tasks)
        {
            Add(item[0], item[1], item[2]);
        }
    }

    public void Add(int userId, int taskId, int priority)
    {
        _userTasks.TryAdd(userId, []);
        _userTasks[userId].Add(taskId);

        _task[taskId] = userId;
        _priority[taskId] = priority;

        _pq.Enqueue(taskId, (priority, taskId));
    }

    public void Edit(int taskId, int newPriority)
    {
        _priority[taskId] = newPriority;
        _pq.Enqueue(taskId, (newPriority, taskId));
    }

    public void Rmv(int taskId)
    {
        var userId = _task[taskId];
        if (userId == -1)
            return;

        _userTasks[userId].Remove(taskId);

        _task[taskId] = -1;
        _priority[taskId] = -1;
    }

    public int ExecTop()
    {
        var id = -1;
        while (_pq.Count > 0)
        {
            _pq.TryDequeue(out var taskId, out var priority);

            // priority contains the latest correct priority for current task
            if (_task[taskId] == -1 || _priority[taskId] != priority.Item1)
                continue;

            id = taskId;
            break;
        }

        if (id == -1)
            return -1;

        var userId = _task[id];
        Rmv(id);

        return userId;
    }
}

/**
 * Your TaskManager object will be instantiated and called as such:
 * TaskManager obj = new TaskManager(tasks);
 * obj.Add(userId,taskId,priority);
 * obj.Edit(taskId,newPriority);
 * obj.Rmv(taskId);
 * int param_4 = obj.ExecTop();
 */