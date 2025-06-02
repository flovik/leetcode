namespace Sandbox.Solutions.Medium;

public class CountNumberOfTeams
{
    public int NumTeams(int[] rating)
    {
        var n = rating.Length;
        var count = 0;

        for (var j = 0; j < n; j++)
        {
            int leftSmaller = 0, leftLarger = 0;
            int rightSmaller = 0, rightLarger = 0;

            for (var i = 0; i < j; i++)
            {
                if (rating[i] < rating[j]) leftSmaller++;
                else if (rating[i] > rating[j]) leftLarger++;
            }

            for (var k = j + 1; k < n; k++)
            {
                if (rating[k] > rating[j]) rightLarger++;
                else if (rating[k] < rating[j]) rightSmaller++;
            }

            count += leftSmaller * rightLarger;
            count += leftLarger * rightSmaller;
        }

        return count;
    }
}