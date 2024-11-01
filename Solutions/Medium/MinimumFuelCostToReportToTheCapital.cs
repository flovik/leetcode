namespace Sandbox.Solutions.Medium;

public class MinimumFuelCostToReportToTheCapital
{
    private Dictionary<int, HashSet<int>> _dict;
    private int _seats;
    private bool[] _visited;

    public long MinimumFuelCost(int[][] roads, int seats)
    {
        // from each node get to capital
        // car in each city, with nr. of seats
        // cost between cities is 1, greedily place in car with seats
        var n = roads.Length + 1;
        _dict = new Dictionary<int, HashSet<int>>(n);
        _seats = seats;
        _visited = new bool[n];

        for (int i = 0; i < n; i++)
        {
            _dict.Add(i, []);
        }

        foreach (var road in roads)
        {
            _dict[road[0]].Add(road[1]);
            _dict[road[1]].Add(road[0]);
        }

        _visited[0] = true;
        var info = _dict[0]
            .Select(Dfs)
            .Aggregate(((long) 0, 0, 0),
                (a, b) => ((a.Item1 + b.Item1, a.Item2 + b.Item2, a.Item3 + b.Item3)));

        return info.Item1;
    }

    // currentSum, carsCurrently, available seats
    private (long, int, int) Dfs(int node)
    {
        _visited[node] = true;

        // end city
        if (_dict[node].All(e => _visited[e]))
            return (1, 1, _seats - 1);

        // here at intersection of nodes we shouldn't separate everyone
        // to different cars, imagine you have 3 outgoing nodes with car of 5 seats and 3 nodes in total
        // should it be 3 separate cars? no, we can fit them into one car
        // so merge them together
        // take every one, calculate the total number of people and derive how many cars you need to fit it in
        // people = (cars * (_seats - availableSeats))
        // cars = (people % _seats) + 1
        // (curSum, cars, availableSeats)
        var list = _dict[node]
            .Where(e => !_visited[e])
            .Select(Dfs)
            .ToList();

        var sum = list.Sum(tuple => tuple.Item1);
        var people = list.Sum(tuple => tuple.Item2 * _seats - tuple.Item3);
        var cars = people / _seats + 1;
        var availableSeats = cars * _seats - people;

        if (availableSeats == 0)
        {
            cars++;
            availableSeats = _seats - 1;
        }
        else
            availableSeats--;

        return (sum + cars, cars, availableSeats);
    }
}