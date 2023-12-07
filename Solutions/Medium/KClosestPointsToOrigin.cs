namespace Sandbox.Solutions.Medium;

public class KClosestPointsToOrigin
{
    private readonly PriorityQueue<(int, int), double> _minHeap = new();

    public int[][] KClosest(int[][] points, int k)
    {
        // The distance between two points on the X-Y plane is the Euclidean distance (i.e., √(x1 - x2)2 + (y1 - y2)2).
        // K points closest to the origin (0, 0)
        foreach (var point in points)
        {
            var x = point[0];
            var y = point[1];

            _minHeap.Enqueue((x, y), Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2)));
        }

        // extract every closest point and insert in original array
        for (int i = 0; i < k; i++)
        {
            var point = _minHeap.Dequeue();
            points[i][0] = point.Item1;
            points[i][1] = point.Item2;
        }

        return points[..k];
    }
}