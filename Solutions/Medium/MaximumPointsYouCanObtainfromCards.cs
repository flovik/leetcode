namespace Sandbox.Solutions.Medium;

public class MaximumPointsYouCanObtainfromCards
{
    public int MaxScore(int[] cardPoints, int k)
    {
        var total = cardPoints.Sum();
        int left = 0, right = 0, curSum = 0, windowLen = cardPoints.Length - k;

        // prefix sum
        while (right < windowLen)
        {
            curSum += cardPoints[right];
            right++;
        }

        // sliding window
        var result = 0;
        while (right < cardPoints.Length)
        {
            result = Math.Max(result, total - curSum);
            curSum -= cardPoints[left];
            curSum += cardPoints[right];

            left++;
            right++;
        }

        result = Math.Max(result, total - curSum);
        return result;
    }

    public int MaxScoreFirstSolution(int[] cardPoints, int k)
    {
        // O(n) time, 0(n) space
        // compute prefix sum of left card points and right card points
        var leftCardPoints = new int[k + 1];
        var rightCardPoints = new int[k + 1];

        for (int i = 1; i <= k; i++)
        {
            leftCardPoints[i] += cardPoints[i - 1] + leftCardPoints[i - 1];
            rightCardPoints[^(i + 1)] += cardPoints[^i] + rightCardPoints[^i];
        }

        var result = 0;
        for (int i = 0; i <= k; i++)
        {
            result = Math.Max(result, leftCardPoints[i] + rightCardPoints[i]);
        }

        return result;
    }
}