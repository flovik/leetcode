namespace Sandbox.Solutions.Medium;

public class HandOfStraights
{
    public bool IsNStraightHand(int[] hand, int groupSize)
    {
        if (hand.Length % groupSize != 0)
            return false;

        var sortedDictionary = new SortedDictionary<int, int>();

        foreach (var i in hand)
        {
            if (sortedDictionary.ContainsKey(i))
                sortedDictionary[i]++;
            else
                sortedDictionary.Add(i, 1);
        }

        // iterate each group one by one by removing data from sorted dictionary
        while (sortedDictionary.Count != 0)
        {
            var previous = -1;
            var currentGroup = sortedDictionary.Take(groupSize).ToList();

            // exhausted cards
            if (currentGroup.Count < groupSize)
                return false;

            foreach (var (card, number) in currentGroup)
            {
                // not increasing
                if (previous != -1 && previous != card - 1)
                    return false;

                previous = card;

                if (number == 1)
                    sortedDictionary.Remove(card);
                else
                    sortedDictionary[card]--;
            }
        }

        return true;
    }
}