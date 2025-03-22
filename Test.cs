namespace Sandbox;

public class Test
{
    public int TotalNumbers(int[] digits)
    {
        var set = new HashSet<int>();

        for (var i = 0; i < digits.Length; i++)
        {
            if (digits[i] == 0)
                continue;

            for (var j = 0; j < digits.Length; j++)
            {
                for (var k = 0; k < digits.Length; k++)
                {
                    if (i == j || j == k || i == k)
                        continue;

                    if (digits[k] % 2 == 0)
                    {
                        var num = digits[i] * 100 + digits[j] * 10 + digits[k];
                        set.Add(num);
                    }
                }
            }
        }

        return set.Count;
    }
}

public class Spreadsheet
{
    private Dictionary<string, int> _map;
    private const int A = 65;

    public Spreadsheet(int rows)
    {
        _map = new Dictionary<string, int>(rows);
    }

    public void SetCell(string cell, int value)
    {
        _map.TryAdd(cell, 0);
        _map[cell] = value;
    }

    public int FurthestBuilding(int[] heights, int bricks, int ladders)
    {
        // you can use one ladder to pass the building
        // or height[i] - height[i - 1] bricks to pass it

        var bricksMaxHeap = new PriorityQueue<int, int>(Comparer<int>.Create((a, b) => b.CompareTo(a)));

        var i = 0;
        while (i < heights.Length - 1)
        {
            if (heights[i + 1] < heights[i])
            {
                i++;
                continue;
            }

            var diff = heights[i + 1] - heights[i];

            // if current number of bricks is still available for using, use them
            if (diff < bricks)
            {
                bricksMaxHeap.Enqueue(diff, diff);
                bricks -= diff;
            }
            else if (ladders > 0) // need to use ladder, decide which to use for: for previous building or current building?
            {
                // previous building is bigger, we can use bricks for current building
                if (bricksMaxHeap.TryPeek(out var brick, out var _) && diff < brick)
                {
                    bricks += brick;
                    bricksMaxHeap.Dequeue();

                    bricksMaxHeap.Enqueue(diff, diff);
                    bricks -= diff;
                }

                ladders--;
            }
            else break; // no ladders and bricks avaialable

            i++;
        }

        return i;
    }
}