namespace Sandbox.Solutions.Medium;

internal class NumberOfSubArraysOfSizeKAndAverageGreaterThanOrEqualToThreshold
{
    public int NumOfSubarrays(int[] arr, int k, int threshold)
    {
        int left = 0, right = 0, curSum = 0, result = 0;

        while (right < k)
        {
            curSum += arr[right];
            right++;
        }

        while (right < arr.Length)
        {
            // calculate threshold
            if (curSum / k >= threshold)
                result++;

            curSum -= arr[left];
            curSum += arr[right];

            left++;
            right++;
        }

        if (curSum / k > threshold)
            result++;

        return result;
    }
}