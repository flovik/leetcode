namespace Sandbox.Solutions.Medium;

public class SumOfDigitDifferencesOfAllPairs
{
    public long SumDigitDifferences(int[] nums)
    {
        // brute force inefficient
        // sum of digit differences
        long sum = 0;
        var first = nums[0].ToString();

        // stores positions to digit occurrences
        // get length of number, easier approach nums[0].ToString().Length
        var hashmap = new Dictionary<int, int[]>(first.Length);

        // init hashmap
        for (var i = 0; i < first.Length; i++)
        {
            hashmap.Add(i, new int[10]);
        }

        foreach (var n in nums)
        {
            var num = n;
            var position = 0;
            while (num != 0)
            {
                // 13 % 10 = 3
                var cur = num % 10;
                hashmap[position][cur]++;
                num /= 10;
                position++;
            }
        }

        // freq * (numsLen - freq)
        foreach (var (_, values) in hashmap)
        {
            foreach (var value in values)
            {
                sum += value * (nums.Length - value);
            }
        }

        // Comb(n,2) = n * (n - 1) / 2;
        return sum / 2;
    }
}