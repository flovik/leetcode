namespace Sandbox.Solutions.Hard;

public class TallestBillboard
{
    public int TallestBillboardSol(int[] rods)
    {
        // TLE
        // O(3^n) - take to taller, take to shorter, no take
        var result = 0;

        var s = new HashSet<int>(rods.Length);
        var t = new HashSet<int>(rods.Length);

        Backtracking(t, s, 0);

        return result;

        void Backtracking(HashSet<int> taller, HashSet<int> shorter, int curIndex)
        {
            var sum = taller.Sum();
            if (sum != 0 && sum == shorter.Sum())
            {
                result = Math.Max(result, sum);
                return;
            }

            for (int i = curIndex; i < rods.Length; i++)
            {
                // 1. take to taller
                taller.Add(rods[i]);
                Backtracking(taller, shorter, i + 1);
                taller.Remove(rods[i]);

                // 2. take to shorter
                shorter.Add(rods[i]);
                Backtracking(taller, shorter, i + 1);
                shorter.Remove(rods[i]);

                // 3. no take
                Backtracking(taller, shorter, i + 1);
            }
        }
    }
}