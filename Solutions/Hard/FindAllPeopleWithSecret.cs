namespace Sandbox.Solutions.Hard;

public class FindAllPeopleWithSecret
{
    public IList<int> FindAllPeople(int n, int[][] meetings, int firstPerson)
    {
        // Kruskal but with union find
        // add a new minimum edge and see if creates a cycle, if yes skip that edge
        // implement using union find

        var parent = new int[n];
        for (int i = 0; i < parent.Length; i++)
        {
            parent[i] = i;
        }

        var rank = new int[n];
        Union(0, firstPerson); // union first person to 0

        // make meetings in increasing order
        var pq = new PriorityQueue<(int, int), int>(n);
        foreach (var meeting in meetings)
        {
            pq.Enqueue((meeting[0], meeting[1]), meeting[2]);
        }

        while (pq.Count > 0)
        {
            // people are the potential ones that might know the secret
            var people = new List<int>();
            pq.TryPeek(out _, out var prevTime);

            // consider the same meeting time as a batch of meetings, so we don't miss
            // a->b [not share secret], c->a [share secret], so b should also know the secret
            while (pq.TryPeek(out _, out var curTime) && curTime == prevTime)
            {
                var (from, to) = pq.Dequeue();
                Union(from, to);
                people.Add(from);
                people.Add(to);
            }

            // if a person is not linked to the 0, then it doesn't still know the secret
            // so we should break the set that we don't include nodes that know the secret earlier
            // a->b [not share secret 5], c->a [share secret 8], b shouldn't know it, because the meeting is passed
            foreach (var i in people)
            {
                if (!IsConnected(0, i))
                    Reset(i);
            }
        }

        var list = new List<int>(n);
        for (var i = 0; i < n; i++)
        {
            if (!IsConnected(0, i))
                continue;

            list.Add(i);
        }

        return list;

        int Find(int x)
        {
            if (parent[x] == x)
                return x;

            return parent[x] = Find(parent[x]);
        }

        void Union(int x, int y)
        {
            var parentX = Find(x);
            var parentY = Find(y);

            if (parentX == parentY) return;

            if (rank[parentY] > rank[parentX])
                parent[parentX] = parentY;
            else if (rank[parentX] > rank[parentY])
                parent[parentY] = parentX;
            else
            {
                parent[parentY] = parentX;
                rank[parentX]++;
            }
        }

        void Reset(int i)
        {
            parent[i] = i;
            rank[i] = 0;
        }

        bool IsConnected(int x, int y)
        {
            var parentX = Find(x);
            var parentY = Find(y);

            return parentX == parentY;
        }
    }
}