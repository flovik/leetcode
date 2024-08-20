namespace Sandbox.Solutions.Medium;

public class LongestTurbulentSubarray
{
    public int MaxTurbulenceSize(int[] arr)
    {
        int maxValue = 1, curValue = 1, i = 1;
        var isDecreasing = false;

        // handle cases when 1,1,1 in a row, to find the increasing/decreasing starting point
        if (arr.Length > 1)
        {
            while (i < arr.Length - 1 && arr[i] == arr[i - 1])
                i++;

            isDecreasing = arr[i - 1] < arr[i];
        }

        while (i < arr.Length)
        {
            if (arr[i] < arr[i - 1] && !isDecreasing ||
                arr[i] > arr[i - 1] && isDecreasing)
            {
                curValue++;
                isDecreasing = !isDecreasing;
            }
            else if (arr[i] == arr[i - 1])
            {
                isDecreasing = arr[i] < arr[i - 1];
                curValue = 1;
            }
            else
            {
                curValue = 2;
            }

            maxValue = Math.Max(maxValue, curValue);
            i++;
        }

        return maxValue;
    }
}