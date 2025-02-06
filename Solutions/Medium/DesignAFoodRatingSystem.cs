namespace Sandbox.Solutions.Medium;

public class FoodRatings
{
    private readonly Dictionary<string, (string, int)> _foodsDictionary = []; // food -> (cuisine, version counter)
    private readonly Dictionary<string, PriorityQueue<string, (int, int, string)>> _cuisineDictionary = []; // cuisine -> max heap
    // max heap, food -> (rating, version)

    public FoodRatings(string[] foods, string[] cuisines, int[] ratings)
    {
        for (int i = 0; i < foods.Length; i++)
        {
            var food = foods[i];
            var cuisine = cuisines[i];
            var rating = ratings[i];

            _foodsDictionary.Add(food, (cuisine, 1));

            if (!_cuisineDictionary.TryGetValue(cuisine, out var heap))
            {
                heap = new PriorityQueue<string, (int, int, string)>(Comparer<(int, int, string)>.Create((a, b) =>
                {
                    if (b.Item1 == a.Item1)
                        return a.Item3.CompareTo(b.Item3);

                    return b.Item1.CompareTo(a.Item1);
                }));

                _cuisineDictionary.Add(cuisine, heap);
            }

            heap.Enqueue(food, (rating, 1, food));
        }
    }

    public void ChangeRating(string food, int newRating)
    {
        var (cuisine, version) = _foodsDictionary[food];
        var heap = _cuisineDictionary[cuisine];
        heap.Enqueue(food, (newRating, version + 1, food));

        _foodsDictionary[food] = (cuisine, version + 1);
    }

    public string HighestRated(string cuisine)
    {
        // if the version counter doesn't match the food from the heap, just remove it
        var maxHeap = _cuisineDictionary[cuisine];

        while (maxHeap.Count > 0)
        {
            maxHeap.TryPeek(out var food, out var foodData);

            var (_, version, _) = foodData;

            if (_foodsDictionary[food].Item2 == version)
                return food;

            maxHeap.Dequeue();
        }

        return null;
    }
}