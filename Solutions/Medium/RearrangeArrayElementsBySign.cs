using System.Runtime.InteropServices;

namespace Sandbox.Solutions.Medium;

public class RearrangeArrayElementsBySign
{
    public int[] RearrangeArray(int[] nums)
    {
        var len = nums.Length;
        int left = 0, right = len / 2;
        var arr = new int[len];

        foreach (var num in nums)
        {
            if (num >= 0)
                arr[left++] = num;
            else
                arr[right++] = num;
        }

        var result = new int[len];

        left = 0;
        right = len / 2;
        for (int i = 0; i < len; i += 2)
        {
            result[i] = arr[left++];
            result[i + 1] = arr[right++];
        }

        return result;
    }
}