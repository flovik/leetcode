namespace Sandbox.Solutions.Medium;

public class ShoppingOffers
{
    private class ListComparer<T> : IEqualityComparer<IList<T>>
    {
        public bool Equals(IList<T>? x, IList<T>? y)
        {
            return x.SequenceEqual(y);
        }

        public int GetHashCode(IList<T> obj)
        {
            return obj.Aggregate(0, (current, t) => current ^ t.GetHashCode());
        }
    }

    public int ShoppingOffersSol(IList<int> price, IList<IList<int>> special, IList<int> needs)
    {
        var comparer = new ListComparer<int>();
        var cache = new Dictionary<IList<int>, int>(needs.Count, comparer);
        return Backtracking(needs);

        int Backtracking(IList<int> curNeeds)
        {
            if (cache.TryGetValue(curNeeds, out var cur))
                return cur;

            // just buy
            var bestPrice = curNeeds.Select((t, i) => t * price[i]).Sum();

            // 2 scenarios
            // use special offer
            foreach (var sp in special)
            {
                // see if special can be bought
                if (!CanBuyOffer(sp, curNeeds))
                    continue;

                for (int i = 0; i < curNeeds.Count; i++)
                {
                    curNeeds[i] -= sp[i];
                }

                var priceWithOffer = sp[^1] + Backtracking(curNeeds);
                bestPrice = Math.Min(bestPrice, priceWithOffer);

                for (int i = 0; i < curNeeds.Count; i++)
                {
                    curNeeds[i] += sp[i];
                }
            }

            if (cache.ContainsKey(curNeeds))
                cache[curNeeds] = Math.Min(cache[curNeeds], bestPrice);
            else
            {
                var arr = new List<int>();
                arr.AddRange(curNeeds);
                cache.Add(arr, bestPrice);
            }

            return bestPrice;
        }

        bool CanBuyOffer(IList<int> offer, IEnumerable<int> needs)
        {
            return !needs.Where((t, i) => offer[i] > t).Any();
        }
    }
}