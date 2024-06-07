namespace Sandbox.Solutions.Hard;

public class LargestRectangleInHistogram
{
    public int LargestRectangleArea(int[] heights)
    {
        // monotonic stack
        // next smaller & previous smaller
        var monoStack = new Stack<int>(heights.Length);
        var nextSmaller = new int[heights.Length];
        var prevSmaller = new int[heights.Length];
        var area = 0; // height * width

        Array.Fill(nextSmaller, -1);
        Array.Fill(prevSmaller, -1);

        for (int i = 0; i < heights.Length; i++)
        {
            while (monoStack.Count > 0 && heights[monoStack.Peek()] > heights[i])
            {
                var st = monoStack.Pop();
                nextSmaller[st] = i;
            }

            if (monoStack.Count > 0)
            {
                prevSmaller[i] = monoStack.Peek();
            }

            monoStack.Push(i);
        }

        // with next smaller and prev smaller, we traverse left and right from current block
        // and see how many blocks of CURRENT_HEIGHT we can include in rectangle

        // prev smaller of current means take the i + 1 index, because the right one from prev smaller is actually bigger
        // and if we compare strictly increasing, then it is of the same size

        // same thing with right, take i - 1 of current next smaller index
        // self is the block itself
        const int self = 1;

        for (int i = 0; i < heights.Length; i++)
        {
            var height = heights[i];
            var rightMostBlock = nextSmaller[i] == -1 ? heights.Length - 1 : nextSmaller[i] - 1;
            var leftMostBlock = prevSmaller[i] == -1 ? 0 : prevSmaller[i] + 1;
            var width = rightMostBlock - leftMostBlock + self;

            area = Math.Max(height * width, area);
        }

        return area;
    }
}