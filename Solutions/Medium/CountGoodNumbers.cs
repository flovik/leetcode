using System.Numerics;

namespace Sandbox.Solutions.Medium;

public class CountGoodNumbers
{
    private const int mod = 1_000_000_007;

    public int CountGoodNumbersSol(long n)
    {
        // good -  digits at even indices are even, digits at odd indices are prime (2, 3, 5, 7)
        long odd = n / 2;
        long even = n / 2;

        if (n % 2 == 1)
            even++;

        var oddCount = BigInteger.ModPow(4, odd, mod);
        var evenCount = BigInteger.ModPow(5, even, mod);

        var answer = (long)(oddCount * evenCount % mod);
        return (int)(answer % mod);
    }
}