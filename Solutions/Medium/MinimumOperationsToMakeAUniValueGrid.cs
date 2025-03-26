namespace Sandbox.Solutions.Medium;

public class MinimumOperationsToMakeAUniValueGrid
{
    public int MinOperations(int[][] grid, int x)
    {
        // get sum of grid and get the average
        int result = 0;

        var arr = grid.SelectMany(e => e).ToArray();
        Array.Sort(arr);

        var middle = arr[(arr.Length - 1) / 2];

        for (var i = 0; i < arr.Length; i++)
        {
            var diff = Math.Abs(arr[i] - middle);

            // that number cannot be made into the average
            if (diff % x != 0)
                return -1;

            var operations = diff / x;
            result += operations;
        }

        return result;
    }
}