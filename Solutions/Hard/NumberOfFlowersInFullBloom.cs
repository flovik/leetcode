namespace Sandbox.Solutions.Hard;

public class NumberOfFlowersInFullBloom
{
    public int[] FullBloomFlowers(int[][] flowers, int[] people)
    {
        var list = new int[people.Length];

        var startFlowers = new int[flowers.Length];
        var endFlowers = new int[flowers.Length];

        for (var i = 0; i < flowers.Length; i++)
        {
            startFlowers[i] = flowers[i][0];
            endFlowers[i] = flowers[i][1] + 1; // move end one forward, because that one is considered still included
        }

        Array.Sort(startFlowers, (a, b) => a.CompareTo(b)); // sort by start
        Array.Sort(endFlowers, (a, b) => a.CompareTo(b)); // sort by end

        for (int i = 0; i < people.Length; i++)
        {
            var startFlower = BinarySearch(startFlowers, people[i]) + 1;
            var endFlower = BinarySearch(endFlowers, people[i]) + 1;

            list[i] = startFlower - endFlower;
        }

        return list;
    }

    private int BinarySearch(int[] nums, int target)
    {
        int left = 0, right = nums.Length - 1;

        while (left <= right)
        {
            var mid = left + (right - left) / 2;

            if (nums[mid] <= target)
                left = mid + 1;
            else
                right = mid - 1;
        }

        return right;
    }
}