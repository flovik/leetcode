namespace Sandbox.Solutions.Medium;

internal class TargetSum
{
    public int FindTargetSumWays(int[] nums, int target)
    {
        // recursive solution
        int result = 0;
        Recursive(0, nums);
        return result;

        void Recursive(int current, int[] currentNums)
        {
            if (currentNums.Length == 0)
            {
                if (current == target)
                    result++;

                return;
            }

            Recursive(current + currentNums[0], currentNums[1..]);
            Recursive(current - currentNums[0], currentNums[1..]);
        }
    }

    public int FindTargetSumWaysDpOptimization(int[] nums, int target)
    {
        // dp solution
        // use dictionary to count num of possible ways for each num

        var sum = nums.Sum();
        var dp = new Dictionary<int, int>(sum) { { 0, 1 } };

        foreach (var num in nums)
        {
            var tempDictionary = new Dictionary<int, int>(dp.Count * 2);

            foreach (var (key, value) in dp.ToArray())
            {
                if (!tempDictionary.ContainsKey(key + num))
                    tempDictionary.Add(key + num, 0);

                if (!tempDictionary.ContainsKey(key - num))
                    tempDictionary.Add(key - num, 0);

                tempDictionary[key + num] += value;
                tempDictionary[key - num] += value;
            }

            dp = tempDictionary;
        }

        return dp.ContainsKey(target) ? dp[target] : 0;
    }
}