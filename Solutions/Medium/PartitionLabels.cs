using System.Text;

namespace Sandbox.Solutions.Medium;

public class PartitionLabelss
{
    public IList<int> PartitionLabels(string s)
    {
        var result = new List<int>(s.Length);
        var lastIndex = new Dictionary<char, int>();

        // save indexes to find the last occurrence of the character
        for (var j = 0; j < s.Length; j++)
        {
            if (lastIndex.ContainsKey(s[j]))
                lastIndex[s[j]] = j;
            else
                lastIndex.Add(s[j], j);
        }

        // iterate the string once again and find the length of each partition
        // if it contains other letters, compare if their length is bigger than the length of current partition
        // if yes, expand the partition until you get to the end of partition
        // add the partition and continue iterating the remaining string
        var i = 0;
        while (i < s.Length)
        {
            var currentLength = lastIndex[s[i]];

            for (var j = i + 1; j < currentLength; j++)
                currentLength = Math.Max(currentLength, lastIndex[s[j]]);

            result.Add(currentLength - i + 1);
            i = currentLength + 1;
        }

        return result;
    }
}