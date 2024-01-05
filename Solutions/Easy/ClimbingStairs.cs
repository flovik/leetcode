namespace Sandbox.Solutions.Easy;

public class ClimbingStairs
{
    public int ClimbStairs(int n)
    {
        if (n == 1)
            return 1;
        if (n == 2)
            return 2;

        int previousStep = 1;
        int currentStep = 2;

        int nextStep = 0;

        for (int i = 2; i < n; i++)
        {
            nextStep = currentStep + previousStep;
            previousStep = currentStep;
            currentStep = nextStep;
        }

        return nextStep;
    }
}