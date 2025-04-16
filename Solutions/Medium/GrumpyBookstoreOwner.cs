namespace Sandbox.Solutions.Medium;

public class GrumpyBookstoreOwner
{
    public int MaxSatisfied(int[] customers, int[] grumpy, int minutes)
    {
        // slide window every n minutes
        var max = 0;
        int left = 0, right = 0;

        // count all satisfied customers
        while (right < customers.Length)
        {
            if (right < minutes || right >= minutes && grumpy[right] == 0)
                max += customers[right];

            right++;
        }

        int count = max;
        right = minutes;

        while (right < customers.Length)
        {
            // previous num was grumpy => remove it
            if (grumpy[left] == 1)
                count -= customers[left];

            if (grumpy[right] == 1)
                count += customers[right];

            max = Math.Max(max, count);

            left++;
            right++;
        }

        return max;
    }
}