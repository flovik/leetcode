namespace Sandbox.Solutions.Medium;

public class SeatManager
{
    private readonly PriorityQueue<int, int> _availableSeats;

    public SeatManager(int n)
    {
        _availableSeats = new PriorityQueue<int, int>(n);

        for (var i = 1; i <= n; i++)
        {
            _availableSeats.Enqueue(i, i);
        }
    }

    public int Reserve()
    {
        var smallest = _availableSeats.Dequeue();
        return smallest;
    }

    public void Unreserve(int seatNumber)
    {
        _availableSeats.Enqueue(seatNumber, seatNumber);
    }
}