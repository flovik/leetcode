namespace Sandbox.Solutions.Easy;

public class SumOfAllSubsetXORTotals
{
    public int SubsetXORSum(int[] nums)
    {
        // sum of all XOR totals for every subset
        // ^ = xor

        // pass the index and then decide to take it or skip it
        // if you take it, apply xor on it (start with 1)
        return Backtrack(0, 0);

        int Backtrack(int index, int num)
        {
            // base case, out-of-bounds
            if (index == nums.Length)
                return 0;

            var take = nums[index] ^ num;

            var next = Backtrack(index + 1, take);
            var skip = Backtrack(index + 1, num);

            return take + next + skip;
        }
    }
}