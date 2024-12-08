namespace Sandbox.Solutions.Medium;

public class MinimumTimetToBreakLocksI
{
    public int FindMinimumTime(IList<int> strength, int K)
    {
        // try n! permutations to break the locks
        // [1, 2, 3], [1, 3, 2], [2, 1, 3], [2, 3, 1] ... and so on

        var result = int.MaxValue;
        Backtrack([], new bool[strength.Count]);
        return result;

        void Backtrack(List<int> locks, bool[] visited)
        {
            if (visited.All(e => e))
            {
                int time = 0, power = 1;

                foreach (var _lock in locks)
                {
                    time += (_lock + power - 1) / power;
                    power += K;
                }

                result = Math.Min(result, time);
                return;
            }

            // permute every lock
            for (var i = 0; i < strength.Count; i++)
            {
                if (visited[i]) continue;

                visited[i] = true;
                locks.Add(strength[i]);

                Backtrack(locks, [.. visited]);

                visited[i] = false;
                locks.RemoveAt(locks.Count - 1);
            }
        }
    }
}