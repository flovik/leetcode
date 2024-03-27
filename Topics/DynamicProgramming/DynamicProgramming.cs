namespace Sandbox.Topics.DynamicProgramming;

public class DynamicProgramming
{
    // make the algorithm more efficient by storing some of the intermediate results
    // works well when we have repetitive competitions

    // the steps of coming up with a dp solution is:
    // 1. recursion
    // 2. figure out a state that you can store, so you don't repeat (memoize)
    // 3. bottom-up approach

    // all possible ways, different possibilities types of problems
    // and problems where you can memoize re occurrences

    // we need to reuse smaller problems which overlap

    // very inefficient because of time complexity of O(2^n)
    private int Fib(int n)
    {
        if (n <= 2)
            return 1;

        return Fib(n - 1) + Fib(n - 2);
    }
}