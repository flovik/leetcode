namespace Sandbox.Solutions.Medium;

public class ProductOfArrayExceptSelf
{
    public int[] ProductExceptSelf(int[] nums)
    {
        var answer = new int[nums.Length];

        // O(n) time, without using division operation
        // O(1) space

        answer[0] = 1;

        // fill left array prefix product
        for (int i = 1; i < nums.Length; i++)
        {
            answer[i] = nums[i - 1] * answer[i - 1];
        }

        int product = nums[^1];
        // fill right array prefix product
        for (int i = nums.Length - 2; i >= 0; i--)
        {
            answer[i] *= product;
            product *= nums[i];
        }

        return answer;
    }

    public int[] ProductExceptSelf2(int[] nums)
    {
        var answer = new int[nums.Length];

        // go from left to right to calculate first product of array

        // initialize ans arr with 1s
        for (int i = 0; i < answer.Length - 1; i++)
        {
            answer[i] = 1;
        }

        for (int i = 1; i < nums.Length - 1; i++)
        {
            answer[i] = nums[i - 1] * answer[i - 1];
        }

        // save last array element to be the product of the right part
        var lastElement = nums[^1];

        for (int i = nums.Length - 2; i >= 0; i--)
        {
            answer[i] *= lastElement;
            lastElement *= nums[i];
        }

        return answer;
    }
}