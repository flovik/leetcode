namespace Sandbox.Solutions.Medium;

public class PerfectSquares
{
    private static int[] numbers;
    public int NumSquares(int n)
    {
        numbers = new int[n + 1];
        Array.Fill(numbers, int.MaxValue);
        numbers[0] = 0;

        var perfectNumbers = new List<int>();
        // create array of perfect numbers which will be iterated
        for (var i = 1; i <= n; i++)
        {
            var perfect = i * i;
            if (perfect > n) break;
            perfectNumbers.Add(perfect);
        }

        for (int i = 1; i <= n; i++)
        {
            foreach (var perfectNumber in perfectNumbers)
            {
                // current perfect number is bigger than current computed number, no reason to continue
                if (perfectNumber > i) break;

                // current vs any perfect number combination
                numbers[i] = Math.Min(numbers[i - perfectNumber] + 1, numbers[i]);

            }
        }

        return numbers[n];
    }

    public int NumSquares2(int n)
    {
        // mathematical theorem - Lagrange's four-square theorem
        if (IsSquare(n)) return 1;

        // result 4 if and only if n can be written in the form of 4^k*(8*m + 7)
        while ((n & 3) == 0) // n%4 == 0
            n >>= 2;
        if ((n & 7) == 7) // n%8 == 7
            return 4;

        // check if 2
        for (int i = 1; i * i <= n; i++)
        {
            if (IsSquare(n - i * i))
                return 2;
        }

        return 3;
    }

    private bool IsSquare(int n)
    {
        var sqrt = Math.Sqrt(n);
        return sqrt == (int)sqrt;
    }
}