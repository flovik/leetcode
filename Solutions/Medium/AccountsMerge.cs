namespace Sandbox.Solutions.Medium;

public class AccountsMerge
{
    private class UnionFind
    {
        private readonly int[] _accountParent;
        private readonly Dictionary<string, int> _emails = new();

        public UnionFind(int n)
        {
            _accountParent = new int[n];

            for (int i = 0; i < n; i++)
            {
                _accountParent[i] = i;
            }
        }

        public int Find(int x)
        {
            if (_accountParent[x] == x)
                return x;

            return _accountParent[x] = Find(_accountParent[x]);
        }

        public void Union(string email, int accountIndex)
        {
            // if dictionary contains the email with an index, update the parent to the owner of the email, emails still will map to the index of the parent!
            if (_emails.TryGetValue(email, out var ownerIndex))
            {
                var owner = Find(ownerIndex);
                var owner2 = Find(accountIndex);

                _accountParent[owner2] = owner;
            }
            else
            {
                _emails.Add(email, accountIndex);
            }
        }
    }

    public IList<IList<string>> AccountsMergeSol(IList<IList<string>> accounts)
    {
        // Union find
        // all common accounts have the same name, but it could be that different accounts have different names
        // try to merge lists for the same name
        var n = accounts.Count;
        var un = new UnionFind(n);
        for (var i = 0; i < n; i++)
        {
            var account = accounts[i];
            var emails = account.Skip(1).ToList();

            foreach (var email in emails)
            {
                un.Union(email, i);
            }
        }

        var dict = new Dictionary<int, HashSet<string>>(n);

        for (var i = 0; i < accounts.Count; i++)
        {
            var account = accounts[i];

            var ownerAccount = un.Find(i);
            var emails = account.Skip(1).ToList();
            dict.TryAdd(ownerAccount, []);
            foreach (var email in emails)
            {
                dict[ownerAccount].Add(email);
            }
        }

        var result = new List<IList<string>>(n);

        foreach (var (ownerIndex, set) in dict)
        {
            var name = accounts[ownerIndex].First();
            var acc = new List<string> { name };

            var emails = set.ToList();
            emails.Sort(Comparer<string>.Create(string.CompareOrdinal));
            acc.AddRange(emails);
            result.Add(acc);
        }

        return result;
    }

    /*
         find accounts with the same owners
         take each email and map to account index

     * [
           ["John", "johnsmith@mail.com", "john_newyork@mail.com"], ["John", "johnsmith@mail.com", "john00@mail.com"],
           ["Mary", "mary@mail.com"], ["John", "johnnybravo@mail.com"]
       ]

        "johnsmith@mail.com" -> 0
        "john_newyork@mail.com" -> 0
        "johnsmith@mail.com" -> 1
        "john00@mail.com" -> 1

        if the hash map already contains an email pointing to an index, then the owner is the same, take each index and map to the first owner
        so now we can point that the parent[1] = 0
     *
     */
}