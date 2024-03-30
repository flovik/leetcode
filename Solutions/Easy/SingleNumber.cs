namespace Sandbox.Solutions.Easy;

public class SingleNumberr
{
    public int SingleNumber(int[] nums)
    {
        // A XOR A = 0
        // 2 1 2 4 1

        // (2^2)^(1^1)^(4) => 0^0^4 => 4
        return nums.Aggregate(0, (current, t) => current ^ t);
    }
}