namespace Sandbox.Solutions.Medium;

public class HIndex
{
    public int HIndexSol(int[] citations)
    {
        // sort with counting sort
        var sortedArray = new int[citations.Length];
        var max = citations.Max(); // find largest of the array
        var count = new int[max + 1];

        // store the count of each element
        foreach (var citation in citations)
        {
            count[citation] += 1;
        }

        // store cumulative count of each array
        for (var i = 1; i <= max; i++)
        {
            count[i] += count[i - 1];
        }

        // find index of each element of the original array in count array
        // and place elements in output array
        for (var i = citations.Length - 1; i >= 0; i--)
        {
            var currentCitation = citations[i];
            var index = count[currentCitation] - 1;
            sortedArray[index] = currentCitation;
            count[currentCitation]--; // we can have multiple values of the same number
        }

        // compute h index
        var result = 0;

        for (var i = 0; i < sortedArray.Length; i++)
        {
            var cur = Math.Clamp(sortedArray.Length - i, 0, sortedArray[i]);
            result = Math.Max(result, cur);
        }

        return result;
    }
}