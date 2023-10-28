namespace Sandbox.Solutions.Medium;

public class DailyTemperatures
{
    public int[] DailyTemperatures2(int[] temperatures)
    {
        var answer = new int[temperatures.Length];
        var stack = new Stack<int>();

        // next greater element, use stack, start from end, push indexes of next greater item
        for (int i = temperatures.Length - 1; i >= 0; i--)
        {
            // if not empty and temperature of the top 'greater' element in stack is lower then pop it
            while (stack.Count > 0 && temperatures[stack.Peek()] <= temperatures[i])
            {
                stack.Pop();
            }

            // if stack is not empty, we have a greater next element
            // take distance between next greater and current temp
            if (stack.Count != 0)
                answer[i] = stack.Peek() - i;

            stack.Push(i);
        }

        return answer;
    }

}