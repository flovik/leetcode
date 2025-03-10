using System.Linq;

namespace Sandbox.Solutions.Hard;

internal class StudentAttendanceRecordII
{
    private const int mod = 1_000_000_007;
    private int[][][] _cache;

    public int CheckRecord(int n)
    {
        // absent strictly fewer than 2 days total
        // never late for 3 consecutive days

        // return number of possible attendance records of len n to make eligible
        _cache = new int[n + 1][][];

        for (var i = 0; i < n + 1; i++)
        {
            _cache[i] = new int[2][];

            for (var j = 0; j < 2; j++)
            {
                _cache[i][j] = new int[3];
                Array.Fill(_cache[i][j], -1);
            }
        }

        return Backtrack(n, 0, 0);
    }

    private int Backtrack(int n, int totalAbsence, int consecutiveLates)
    {
        if (totalAbsence > 1)
            return 0;

        if (consecutiveLates > 2)
            return 0;

        if (n == 0)
            return 1;

        if (_cache[n][totalAbsence][consecutiveLates] != -1)
            return _cache[n][totalAbsence][consecutiveLates];

        int count = 0;

        count += Backtrack(n - 1, totalAbsence + 1, 0) % mod; // A
        count = (count + Backtrack(n - 1, totalAbsence, consecutiveLates + 1)) % mod; // L
        count = (count + Backtrack(n - 1, totalAbsence, 0)) % mod; // P

        return _cache[n][totalAbsence][consecutiveLates] = count;
    }
}