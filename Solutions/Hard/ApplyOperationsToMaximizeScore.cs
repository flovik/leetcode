using System.Numerics;

namespace Sandbox.Solutions.Hard;

public class ApplyOperationsToMaximizeScore
{
    private const int mod = 1_000_000_007;

    public int MaximumScore(IList<int> nums, int k)
    {
        // prime score - number of distinct prime factors of an X. e.g. 300 = 3 (2 * 2 * 2 * 3 * 5 * 5)
        // choose element X of subarray [l..r] with highest prime score, if multiple exist, pick the lowest index
        // need to pick highest possible numbers from nums, as subarrays, and consider their prime number score

        long answer = 1;

        // prime number - number that is divisible by 1 and itself only
        var dict = new Dictionary<int, int>(nums.Count);

        // sieve of eratosthenes
        for (int i = 0; i < nums.Count; i++)
        {
            var num = nums[i];
            if (dict.ContainsKey(num))
                continue;

            dict.Add(num, 0);

            var score = 0;

            var temp = num;
            var sqrt = (int) (Math.Sqrt(temp) + 1);
            for (var f = 2; f < sqrt; f++)
            {
                if (temp % f == 0)
                {
                    score++;
                    while (temp % f == 0)
                    {
                        temp /= f;
                    }
                }
            }

            if (temp >= 2)
                score++;

            dict[num] = score;
        }

        // monotonic stack
        var prevGreater = new int[nums.Count];
        var nextGreater = new int[nums.Count];

        Array.Fill(prevGreater, -1);
        Array.Fill(nextGreater, nums.Count);

        var st = new Stack<int>(nums.Count);
        for (int i = 0; i < nums.Count; i++)
        {
            var score = dict[nums[i]];

            // next
            while (st.Count > 0 && dict[nums[st.Peek()]] < score)
            {
                var index = st.Pop();
                nextGreater[index] = i;
            }

            // prev
            if (st.Count > 0 && dict[nums[st.Peek()]] >= score)
            {
                prevGreater[i] = st.Peek();
            }

            st.Push(i);
        }

        // how many sub-arrays those Num has that it has the biggest prime score?
        // take for example [8, 3, 9, 3, 8]
        // 9 is cleary the biggest number here with biggest prime score (1)
        // so we can calculate how many sub-arrays we have going to the left and then going to the right
        // left = 8, 3 and 9
        // right = 9, 3 and 8
        // that is 3 numbers for left and 3 numbers for right, which together equals 9 different sub-arrays
        // left[i] + 1 <= l <= i <= r <= right[i] - 1, then s[i] is the maximum value in the range [l, r]

        // get max by using max heap and use available remaining K for current number and its sub-arrays
        // index, (number, prime score)
        var pq = new PriorityQueue<int, (int, int)>(Comparer<(int, int)>.Create((a, b) =>
        {
            if (a.Item1 == b.Item1)
                return b.Item2.CompareTo(a.Item2);

            return b.Item1.CompareTo(a.Item1);
        }));

        for (int i = 0; i < nums.Count; i++)
        {
            pq.Enqueue(i, (nums[i], dict[nums[i]]));
        }

        while (k > 0)
        {
            var index = pq.Dequeue();

            var num = nums[index];

            var l = prevGreater[index];
            var r = nextGreater[index];

            long ll = (index - l);
            long rr = (r - index);

            long subarraysCount = ll * rr;
            var operations = (int) Math.Min(k, subarraysCount);

            k -= operations;

            var newScore = BigInteger.ModPow(num, operations, mod);
            answer = (long) (answer * newScore) % mod;
        }

        return (int) (answer % mod);
    }
}