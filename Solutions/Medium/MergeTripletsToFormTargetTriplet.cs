namespace Sandbox.Solutions.Medium;

public class MergeTripletsToFormTargetTriplet
{
    public bool MergeTriplets(int[][] triplets, int[] target)
    {
        var result = new int[3];

        foreach (var triplet in triplets)
        {
            if (triplet[0] > target[0] || triplet[1] > target[1] || triplet[2] > target[2])
                continue;

            result[0] = Math.Max(result[0], triplet[0]);
            result[1] = Math.Max(result[1], triplet[1]);
            result[2] = Math.Max(result[2], triplet[2]);
        }

        return result[0] == target[0] && result[1] == target[1] && result[2] == target[2];
    }
}