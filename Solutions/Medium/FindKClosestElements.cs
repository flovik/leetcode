namespace Sandbox.Solutions.Medium;

public class FindKClosestElements
{
    public IList<int> FindClosestElements(int[] arr, int k, int x)
    {
        var index = Array.BinarySearch(arr, x);

        if (index < 0)
            index = ~index;

        int left = index - 1, right = index;
        while (k > 0)
        {
            if (left < 0)
                right++;
            else if (right >= arr.Length)
                left--;
            else if (Math.Abs(arr[left] - x) <= Math.Abs(arr[right] - x))
                left--;
            else
                right++;

            k--;
        }

        var result = new int[right - left - 1];
        Array.Copy(arr, left + 1, result, 0, right - left - 1);
        return result;
    }
}