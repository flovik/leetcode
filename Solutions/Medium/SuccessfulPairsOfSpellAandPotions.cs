namespace Sandbox.Solutions.Medium;

public class SuccessfulPairsOfSpellAandPotions
{
    public int[] SuccessfulPairs(int[] spells, int[] potions, long success)
    {
        var res = new int[spells.Length];
        Array.Sort(potions);

        for (var i = 0; i < spells.Length; i++)
        {
            var spell = spells[i];
            int left = 0, right = potions.Length - 1;

            while (left <= right)
            {
                var mid = left + (right - left) / 2;
                var target = (long) potions[mid] * spell;

                if (target >= success)
                    right = mid - 1;
                else
                    left = mid + 1;
            }

            res[i] = potions.Length - left;
        }

        return res;
    }
}