namespace Sandbox.Solutions.Easy;

public class NextGreaterElement1
{
    public int[] NextGreaterElement(int[] nums1, int[] nums2)
    {
        // monotonic stack
        var monotonicStack = new Stack<int>(nums1.Length + nums2.Length);

        // nums1 is subset nums2
        // get the first greater element of nums2[i]
        var nextGreaterArray = new int[nums2.Length];
        Array.Fill(nextGreaterArray, -1);

        for (int i = 0; i < nums2.Length; i++)
        {
            // while stack non empty
            // and top of stack is STRICTLY SMALLER than current element
            // monotonicStack.Peek() has the largest value found until now
            while (monotonicStack.Count > 0 && nums2[monotonicStack.Peek()] < nums2[i])
            {
                var st = monotonicStack.Pop();

                // current element is bigger, so save in array based on index of the popped element it's greater element
                nextGreaterArray[st] = i;
            }

            monotonicStack.Push(i);
        }

        // store nums2 numbers in a dictionary
        var dictionary = new Dictionary<int, int>(nums2.Length);
        for (int i = 0; i < nums2.Length; i++)
        {
            dictionary.Add(nums2[i], i);
        }

        for (int i = 0; i < nums1.Length; i++)
        {
            var index = dictionary[nums1[i]];
            var nextGreaterIndex = nextGreaterArray[index];
            nums1[i] = nextGreaterIndex != -1 ? nums2[nextGreaterIndex] : -1;
        }

        return nums1;
    }
}