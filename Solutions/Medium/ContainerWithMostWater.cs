namespace Sandbox.Solutions.Medium;

public class ContainerWithMostWater
{
    public int MaxArea(int[] height)
    {
        var maxArea = 0;

        for (int i = 0, j = height.Length - 1; i < j;)
        {
            var curArea = Math.Min(height[i], height[j]) * (j - i);
            if (curArea > maxArea)
                maxArea = curArea;

            if (height[j] > height[i])
                i++;
            else
                j--;
        }

        return maxArea;
    }
}