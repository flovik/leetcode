using System.Collections;

namespace Sandbox.Solutions.Easy;

public class NumberOf1Bits
{
    public int HammingWeight(int n)
    {
        var bitArray = new BitArray(new[] { n });
        return bitArray.Cast<bool>().Count(b => b);
    }
}