namespace Sandbox.Solutions.Hard;

public class TrappingRainWater
{
    /*
     *           maxLeft   maxRight     curHeight
     * Math.Min(height[i], height[j]) - height[k];
     *
     * two pointers solution
     * maxLeft and maxRight that keep max so far
     * shift left index or right based which is smaller
     * compute trapped water
     * update maxLeft or maxRight if curHeight is bigger
     *
     * aici cumva merge logica ca daca maxRight e deja 1 si maxLeft e tot 1 si curHeight e 0, nu tare conteaza care
     * e alte maxHeights din oare care parte, deoarece oricum n-o sa fie mai mare de maxLeft sau maxRight
     * deoarece noi mergem din margini de la stanga sau dreapta, si pana la maxLeft nu e nimic mai mare de maxLeft
     */

    public int Trap(int[] height)
    {
        var trappedWater = 0;

        int left = 0, right = height.Length - 1;
        int maxLeft = height[left], maxRight = height[right];

        while (left < right)
        {
            // shift index (at the start too, because edges will fall nevertheless)
            int k;
            if (height[left] < height[right])
            {
                left++;
                k = left;
            }
            else
            {
                right--;
                k = right;
            }

            // compute trapped water by the formula (math.Min(height[maxLeft], height[maxRight]) - height[k]), and if the value is negative, ignore it
            var howMuchTrappedWater = Math.Min(maxLeft, maxRight) - height[k];
            if (howMuchTrappedWater > 0)
                trappedWater += howMuchTrappedWater;

            // update maxLeft or maxRight if bigger
            if (height[left] > maxLeft)
                maxLeft = height[left];
            else if (height[right] > maxRight)
                maxRight = height[right];
        }

        return trappedWater;
    }

    public int Trap2(int[] height)
    {
        var trappedWater = 0;

        int left = 0, right = height.Length - 1;
        int maxLeft = height[left], maxRight = height[right];

        while (left < right)
        {
            if (maxLeft < maxRight)
            {
                // move from edges and move from where the max is smaller
                left++;

                // update maxLeft if a new bigger value is found (max prevents negative values)
                maxLeft = Math.Max(maxLeft, height[left]);

                // if curHeight is smaller than maxLeft, then we will have trapped water
                trappedWater += maxLeft - height[left];

                // it works, because by the first if we know that the maxRight IS BIGGER and we only consider the 
                // maxLeft, because Math.Min(maxLeft, maxRight)
            }
            else
            {
                right--;
                maxRight = Math.Max(maxRight, height[right]);
                trappedWater += maxRight - height[right];
            }
        }

        return trappedWater;
    }
}