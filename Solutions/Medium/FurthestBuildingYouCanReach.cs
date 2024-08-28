namespace Sandbox.Solutions.Medium;

public class FurthestBuildingYouCanReach
{
    public int FurthestBuilding(int[] heights, int bricks, int ladders)
    {
        // min heap will store ladders, and bricks will be as a placeholder when ladders are exceeded
        var pq = new PriorityQueue<int, int>(ladders);

        var i = 0;
        for (; i < heights.Length - 1; i++)
        {
            if (heights[i + 1] < heights[i])
                continue;

            var cur = heights[i + 1] - heights[i];

            if (cur > 0)
                pq.Enqueue(cur, cur);

            if (pq.Count > ladders) // if no more ladders, we need to use bricks
                bricks -= pq.Dequeue();

            if (bricks < 0)
                break;
        }

        return i;
    }
}