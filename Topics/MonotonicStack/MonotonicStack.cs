namespace Sandbox.Topics.MonotonicStack;

public class MonotonicStack
{
    // Monotonic stacks are generally used for solving questions of the type - next greater element,
    // next smaller element, previous greater element and previous smaller element.

    public void GenericTemplate(int[] arr)
    {
        var stack = new Stack<int>();
        var nextGreater = new int[arr.Length];
        var prevGreater = new int[arr.Length];

        for (int i = 0; i < arr.Length; i++)
        {
            // operator is the inverse of what we need
            // if > (greater), then will find nextSmaller
            // if < (smaller), then will find nextGreater
            while (stack.Count > 0 && arr[stack.Peek()] < arr[i])
            {
                var pop = stack.Pop();

                nextGreater[pop] = i;
            }

            if (stack.Count > 0)
            {
                // stack has some elements left here
                prevGreater[i] = stack.Peek();
            }

            stack.Push(i);
        }

        /*
         *      Problem	Stack |      Type	                | Operator in while loop |	  Assignment Position
         *
         *      next greater  |	decreasing (equal allowed)  |	 stackTop < current	 |    inside while loop
         *      previous greater |	decreasing (strict)	    |    stackTop <= current |	  outside while loop
         *      next smaller	 | increasing (equal allowed)|	stackTop > current	 |    inside while loop
         *      previous smaller |	increasing (strict)	     |  stackTop >= current	 |    outside while loop
         */
    }
}