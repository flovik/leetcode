namespace Sandbox.Solutions.Medium;

public class BoatstoSavePeople
{
    public int NumRescueBoats(int[] people, int limit)
    {
        Array.Sort(people);
        int count = 0, left = 0, right = people.Length - 1;

        while (left <= right)
        {
            if (people[left] + people[right] <= limit)
                left++;

            count++;
            right--;
        }

        return count;
    }
}