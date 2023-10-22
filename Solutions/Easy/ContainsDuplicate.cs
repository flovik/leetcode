namespace Sandbox.Solutions.Easy;

public class ContainsDuplicate
{
    private readonly ISet<int> duplicateDictionary = new HashSet<int>();
    public bool ContainsDuplicates(int[] nums)
    {
        foreach (var num in nums)
        {
            if (duplicateDictionary.Contains(num)) return true;
            duplicateDictionary.Add(num);
        }

        return false;
    }
}