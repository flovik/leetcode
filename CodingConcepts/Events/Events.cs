namespace Sandbox.CodingConcepts.Events;

public class Events
{
    // An event is a message sent by an object to signal the occurrence of an action.

    private int threshold;
    private int total;

    public event EventHandler<ThresholdReachedEventArgs> ThresholdReached;

    public Events(int passedThreshold)
    {
        threshold = passedThreshold;
    }

    public void Add(int x)
    {
        total += x;
        if (total < threshold) return;

        var args = new ThresholdReachedEventArgs
        {
            Threshold = threshold,
            TimeReached = DateTime.Now
        };

        OnThresholdReached(args);
    }

    protected virtual void OnThresholdReached(ThresholdReachedEventArgs e)
    {
        var handler = ThresholdReached;
        handler?.Invoke(this, e);
    }
}

public class ThresholdReachedEventArgs : EventArgs
{
    public int Threshold { get; set; }
    public DateTime TimeReached { get; set; }
}