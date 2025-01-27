namespace Sandbox.Solutions.Medium;

public class UndergroundSystem
{
    private readonly IDictionary<int, (string, int)> _userTrips;
    private readonly IDictionary<(string, string), (long, int)> _stationTravelTime;

    public UndergroundSystem()
    {
        _userTrips = new Dictionary<int, (string, int)>();
        _stationTravelTime = new Dictionary<(string, string), (long, int)>();
    }

    public void CheckIn(int id, string stationName, int t)
    {
        _userTrips.Add(id, (stationName, t));
    }

    public void CheckOut(int id, string stationName, int t)
    {
        if (!_userTrips.TryGetValue(id, out var start))
            return;

        var (startStation, startT) = start;

        _stationTravelTime.TryAdd((startStation, stationName), (0, 0));
        var (curTime, curTripsNr) = _stationTravelTime[(startStation, stationName)];
        curTime += t - startT;
        curTripsNr++;

        _stationTravelTime[(startStation, stationName)] = (curTime, curTripsNr);
        _userTrips.Remove(id);
    }

    public double GetAverageTime(string startStation, string endStation)
    {
        var (curTime, curTripsNr) = _stationTravelTime[(startStation, endStation)];
        return (double)curTime / curTripsNr;
    }
}