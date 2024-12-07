namespace Sandbox.Solutions.Medium;

public class UncrossedLines
{
    public int MaxUncrossedLines(int[] nums1, int[] nums2)
    {
        // naive way is to brute-force out way to the correct answer, we can use recursion to search from each number
        // their copy on the other array, draw the line and match next ones, the found number will be crossed, and we can search
        // only from the right of it

        // we can make a decision tree, so we can memoize the best answer for a particular index of an array
        // in 'to' dp array we save the best combination until that number

        var dict = new Dictionary<int, List<int>>(nums2.Length);

        for (int i = nums2.Length - 1; i >= 0; i--)
        {
            dict.TryAdd(nums2[i], []);
            dict[nums2[i]].Add(i);
        }

        var to = new int[nums2.Length + 1];

        for (var i = 0; i < nums1.Length; i++)
        {
            // lines are saved in descending order, so we don't have incorrect values (2 and 5, increase 2, then increase 5, because was already increased)
            var lines = dict.GetValueOrDefault(nums1[i], []);

            foreach (var line in lines)
            {
                if (line == 0)
                    to[line] = 1;

                // look at values UNTIL line and take the max one
                for (var j = 0; j < line; j++)
                {
                    to[line] = Math.Max(to[line], to[j] + 1);
                }
            }
        }

        return to.Max();
    }
}