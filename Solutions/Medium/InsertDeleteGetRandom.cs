namespace Sandbox.Solutions.Medium;

public class RandomizedSet
{
    private readonly HashSet<int> _hashSet;

    public RandomizedSet()
    {
        _hashSet = new HashSet<int>();
    }

    public bool Insert(int val)
    {
        return _hashSet.Add(val);
    }

    public bool Remove(int val)
    {
        return _hashSet.Remove(val);
    }

    public int GetRandom()
    {
        var rnd = new Random().Next(0, _hashSet.Count);
        return _hashSet.ToArray()[rnd];
    }
}