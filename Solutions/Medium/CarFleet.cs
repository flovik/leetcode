namespace Sandbox.Solutions.Medium;

public class CarFleet
{

    // Sort the arrays by position, then work backwards through
    // them calculating the duration each has left.If a car catches the car in front,
    // it can be considered in the fleet, and therefore it is part of the car in front, and we essentially ignore it.
    // Otherwise add it to the stack, and repeat the calculation on cars behind it, and so on.
    public int CarFleet2(int target, int[] position, int[] speed)
    {
        if (position.Length == 1) return 1;

        // duration
        var stack = new Stack<double>(position.Length);

        // sort cars by start position pso O(nlogn) time
        Array.Sort(position, speed);

        // loop each car from end to beginning
        // the first one is already the leader, so it goes first in the stack and no one can go FASTER than him
        // it's like one line road, if he goes with speed 1 and other cars catch up to him, they will slow down to him
        // for each position/speed pair get a nr. of steps left to the target

        for (int i = position.Length - 1; i >= 0; i--)
        {
            // calculate its time needed to arrive to the target
            double time = target - position[i];
            double duration = time / speed[i];

            // if a car BEFORE our duration in stack has lower duration, it doesn't matter, because
            // it will slow down to the duration of the current stack speed

            // if the duration is actually bigger, than the cars before it will slow down and push that
            // car as a new car fleet leader

            // if distance to arrive to the target plus speed surpasses position of the lead fleet
            if (stack.Count == 0 || duration > stack.Peek())
            {
                stack.Push(duration);
            }
        }

        return stack.Count;
    }
}
