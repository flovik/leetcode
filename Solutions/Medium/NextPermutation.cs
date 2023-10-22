namespace Sandbox.Solutions.Medium;

public class NextPermutation
{
    public void NextPermutate(int[] nums)
    {
        if (nums.Length == 1) return;

        //for any case that is longer and equal than 3, we permute only last 3
        //and adjust according to them

        //is last number bigger than prelast number? 
        if (nums[^1] > nums[^2]) (nums[^1], nums[^2]) = (nums[^2], nums[^1]);
        else
        {
            var precedentIndex = nums.Length - 3;
            //search smallest from left to swap
            while (precedentIndex >= 0 && nums[precedentIndex] >= nums[precedentIndex + 1])
            {
                precedentIndex--;
            }

            if (precedentIndex != -1)
            {
                //found a smaller number in sequence, find FIRST number from right which will be replaced
                //then reverse to increasing
                var biggerIndex = nums.Length - 1;
                while (nums[biggerIndex] <= nums[precedentIndex])
                {
                    biggerIndex--;
                }

                (nums[precedentIndex], nums[biggerIndex]) = (nums[biggerIndex], nums[precedentIndex]);
                for (int i = precedentIndex + 1, j = nums.Length - 1; i < j; i++, j--)
                {
                    (nums[i], nums[j]) = (nums[j], nums[i]);
                }
            }
            else
            {
                //everything is increasing and should be reversed
                for (int i = 0, j = nums.Length - 1; i < j; i++, j--)
                {
                    (nums[i], nums[j]) = (nums[j], nums[i]);
                }
            }
        }
    }
}