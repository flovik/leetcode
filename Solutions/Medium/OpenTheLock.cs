namespace Sandbox.Solutions.Medium;

public class OpenTheLock
{
    private readonly char[] _characters = new[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

    public int OpenLock(string[] deadends, string target)
    {
        var deadEnds = new HashSet<string>(deadends);
        var moves = int.MaxValue;
        var source = "0000";

        if (deadEnds.Contains(source))
            return -1;

        if (target == source)
            return 0;

        // combination-moves
        var queue = new Queue<(string, int)>(10000);
        var visited = new HashSet<string>(10000);

        queue.Enqueue((source, 0));

        while (queue.Count > 0)
        {
            var dq = queue.Dequeue();

            if (!visited.Add(dq.Item1))
                continue;

            // 8 different combinations from one
            var combinations = GenerateNewCombinations(dq.Item1);
            CheckCombinations(combinations, dq.Item1, dq.Item2 + 1);

            for (int i = 0; i < 8; i++)
            {
                var item = combinations[i];

                if (!visited.Contains(item) && !deadEnds.Contains(dq.Item1))
                    queue.Enqueue((item, dq.Item2 + 1));
            }
        }

        return moves != int.MaxValue ? moves : -1;

        void CheckCombinations(List<string> items, string prevComb, int curMoves)
        {
            for (int i = 0; i < 8; i++)
            {
                var item = items[i];

                if (item.Equals(target) && !deadEnds.Contains(prevComb))
                    moves = Math.Min(moves, curMoves);
            }
        }
    }

    private List<string> GenerateNewCombinations(string str)
    {
        var list = new List<string>(8);
        for (int i = 0; i < 4; i++)
        {
            var str1 = str.ToArray();
            var str2 = str.ToArray();

            var index = str[i] - '0';
            str1[i] = _characters[(index + 1 + _characters.Length) % _characters.Length];
            str2[i] = _characters[(index - 1 + _characters.Length) % _characters.Length];

            list.AddRange([new string(str1), new string(str2)]);
        }

        return list;
    }
}