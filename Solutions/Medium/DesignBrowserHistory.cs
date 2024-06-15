namespace Sandbox.Solutions.Medium;

public class BrowserHistory
{
    private readonly LinkedList<string> _history;
    private LinkedListNode<string> _currentPage;

    public BrowserHistory(string homepage)
    {
        _history = new LinkedList<string>(new[] { homepage });
        _currentPage = _history.First;
    }

    public void Visit(string url)
    {
        // remove forward history
        while (_currentPage.Next is not null)
            _history.Remove(_currentPage.Next);

        var nextPage = new LinkedListNode<string>(url);
        _history.AddAfter(_currentPage, nextPage);
        _currentPage = nextPage;
    }

    public string Back(int steps)
    {
        while (_currentPage.Previous is not null && steps > 0)
        {
            _currentPage = _currentPage.Previous;
            steps--;
        }

        return _currentPage.Value;
    }

    public string Forward(int steps)
    {
        while (_currentPage.Next is not null && steps > 0)
        {
            _currentPage = _currentPage.Next;
            steps--;
        }

        return _currentPage.Value;
    }
}