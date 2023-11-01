namespace Sandbox.Solutions.Medium;

public class _3Sum
{
    public IList<IList<int>> ThreeSum(int[] nums)
    {
        // based on the two sum problem, which could be solved using two pointers in O(n) time
        // here two pointers also could be applied

        // sort O (n log n)

        Array.Sort(nums);
        var result = new List<IList<int>>();

        if (nums.Length < 3 || nums[0] > 0)
            return result;

        // traverse array of a fix number until it is a positive
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] > 0)
                break; // can't make it zero because it is already a positive
            if (i > 0 && nums[i] == nums[i - 1])
                continue; // repeating number

            var low = i + 1;
            var high = nums.Length - 1;

            while (low < high)
            {
                var sum = nums[i] + nums[low] + nums[high];
                if (sum > 0)
                    high--;
                else if (sum < 0)
                    low++;
                else
                {
                    // found answer
                    result.Add(new List<int>(new int[] { nums[i], nums[low], nums[high] }));

                    // duplicate
                    var lastSavedLowValue = nums[low];
                    var lastSavedHighValue = nums[high];

                    // like imagine you found in sequence -1 -1 -1 0 1 2 2 2
                    // and we skip both, because if we skip only one, there is no way we will have the same answer
                    // because nums[i] is already a bigger number
                    // so we will skip all -1s
                    while (low < high && nums[low] == lastSavedLowValue)
                        low++;

                    // and all 2s
                    while (low < high && nums[high] == lastSavedHighValue)
                        high--;
                }
            }
        }

        return result;
    }
}