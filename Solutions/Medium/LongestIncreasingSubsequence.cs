namespace Sandbox.Solutions.Medium;

public class LongestIncreasingSubsequence
{
    public int LengthOfLIS(int[] nums)
    {
        nums = new[] { 10, 9, 2, 5, 3, 7, 101, 18, 2, 5, 3, 7, 101, 102 };
        var sequencesLengths = new short[nums.Length];
        var result = 1;

        for (int i = nums.Length - 1; i >= 0; i--)
        {
            // set current longest subsequence to 1
            sequencesLengths[i] = 1;

            short temp = 1;

            for (var j = i + 1; j < nums.Length; j++)
            {
                if (nums[i] < nums[j] && sequencesLengths[j] + 1 > temp) temp = (short) (sequencesLengths[j] + 1);
            }

            sequencesLengths[i] = temp;
            if (temp > result) result = temp;
        }


        return result;
    }

    public int LengthOfLIS2(int[] nums)
    {
        nums = new[] { 4, 10, 4, 3, 8, 9 };

        var endOfSequenceIndex = 0;
        for (int i = 1; i < nums.Length; i++)
        {
            // extending
            if (nums[i] > nums[endOfSequenceIndex]) nums[++endOfSequenceIndex] = nums[i];
            // replacing
            else
            {
                int index = BinarySearch(nums, nums[i], 0, endOfSequenceIndex);
                nums[index] = nums[i];
            }
        }

        return endOfSequenceIndex + 1;
    }

    private int BinarySearch(int[] nums, int searchedValue, int start, int finish)
    {
        int low = start, high = finish;
        var index = 0;
        while (low <= high)
        {
            var mid = low + (high - low) / 2;
            if (nums[mid] == searchedValue) return mid;
            if (nums[mid] < searchedValue) low = mid + 1;
            else
            {
                index = mid;
                high = mid - 1;
            }
        }

        return index;
    }
}


/*

    10,9,2,5,3,7,101,18
    logic is to calculate the longest subsequence, you can delete as many numbers as you like
    to get the subsequence
    here we have 2, 5, 3, 7, 101
    we can delete 5 and get 2, 3, 7, 101, so we gucci

    first naive solution that comes to my mind is to iterate the array backwards, by calculating
    the local longest subsequence of each number by saving them in other array
    and then comparing each of them to find the longest subsequence
    O(n^2) time and O(n) space

 */

/*
    https://leetcode.com/problems/longest-increasing-subsequence/solutions/1326552/optimization-from-brute-force-to-dynamic-programming-explained/
    second solution to that problem, I couldn't come up with that in time
    very elegant solution
    so basically we keep the memoized array inside our main array
    it doesn't matter if we change it to different values, because the result remains the same no matter
    what
    it is either extending values or replacing them
    extending is easy, when a new bigger element appears, increase endOfSequenceIndex
    replacing can be done using binary search, because the subsequence is increasing and we are sure where to
    replace it

*/