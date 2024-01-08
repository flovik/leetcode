namespace Sandbox.Solutions.Medium;

public class MaximumProductSubarraySolution
{
    public int MaxProduct(int[] nums)
    {
        // if we might want to find the max subarray n, we at least need to solve the subproblem n - 1, to get the entire one
        // we need to get the max product of the subarray, and also get the minimum product subarray of the subarray n - 1

        // consider the case [-1, -2, -3]
        // for [-1, -2] you have max = 2, because you multiply both and you get the value, min = -2, because you can take only -2
        // as your min and 'drop' the -1
        // that helps further with the [-1, -2, -3], because when you multiply, the values you get are 6 and -6, and check by yourself
        // it will work
        var result = nums.Max();

        var maxSoFar = 1;
        var minSoFar = 1;

        // edge case - when zero, just reset to 1 min and max and compute the subarray once again

        foreach (var num in nums)
        {
            if (num == 0)
            {
                maxSoFar = 1;
                minSoFar = 1;
                continue;
            }

            var newMax = maxSoFar * num;
            var newMin = minSoFar * num;
            maxSoFar = Math.Max(newMax, Math.Max(newMin, num));
            minSoFar = Math.Min(newMax, Math.Min(newMin, num));

            if (maxSoFar > result)
                result = maxSoFar;
        }

        return result;
    }
}