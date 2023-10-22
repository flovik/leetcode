namespace Sandbox.Solutions.Medium;

public class MajorityElement2
{
    public IList<int> MajorityElement(int[] nums)
    {
        //one solution is to store a particular number in hashmap and see if its occurrences are more or equal than floor value 
        //O(n) time O(n) space

        //I suppose here should be used Majority vote algorithm Boyer-Moore to have O(n) time and O(1) space

        if (nums.Length == 1) return new List<int> { nums[0] };

        var result = new List<int>();
        var floor = (int) Math.Floor(nums.Length / 3.0) + 1;

        int count1 = 0, count2 = 0;
        var candidate1 = int.MinValue;
        var candidate2 = int.MinValue;

        //find candidates
        foreach (var num in nums)
        {
            if (candidate1 == num) count1++;
            else if (candidate2 == num) count2++;
            else if (count1 == 0)
            {
                candidate1 = num;
                count1 = 1;
            }
            else if (count2 == 0)
            {
                candidate2 = num;
                count2 = 1;
            }
            else
            {
                //consider it to be a triplet, if got to the third which are not candidates,
                //reduce the whole triplet, because that third might become the new candidate
                count1--;
                count2--;
            }
        }

        //verify
        count1 = 0; count2 = 0;
        foreach (var num in nums)
        {
            if(num == candidate1) count1++;
            else if(num == candidate2) count2++;
        }

        if (count1 >= floor) result.Add(candidate1);
        if (count2 >= floor) result.Add(candidate2);


        return result;
    }
}