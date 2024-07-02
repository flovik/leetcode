using System.Reflection;

namespace Sandbox.Solutions.Medium;

public class KnightDialer
{
    public int KnightDialerSol(int n)
    {
        if (n == 1)
            return 1;

        const int modulo = 1_000_000_007;

        // num of ways the knight can jump from each digit
        // 0 -> to 4 and 6, 1 -> to 6 and 8...
        // sum each digit at each iteration
        var ways = new long[] { 2, 2, 2, 2, 3, 0, 3, 2, 2, 2 };

        for (var step = 2; step < n; step++)
        {
            var newWays = new long[10];
            newWays[0] = (ways[4] + ways[6]) % modulo;
            newWays[1] = (ways[6] + ways[8]) % modulo;
            newWays[2] = (ways[7] + ways[9]) % modulo;
            newWays[3] = (ways[4] + ways[8]) % modulo;
            newWays[4] = (ways[0] + ways[3] + ways[9]) % modulo;
            newWays[6] = (ways[0] + ways[1] + ways[7]) % modulo;
            newWays[7] = (ways[2] + ways[6]) % modulo;
            newWays[8] = (ways[1] + ways[3]) % modulo;
            newWays[9] = (ways[2] + ways[4]) % modulo;

            ways = newWays;
        }

        long result = 0;
        for (int i = 0; i < 10; i++)
        {
            result = (result + ways[i]) % modulo;
        }

        return (int) result;
    }
}