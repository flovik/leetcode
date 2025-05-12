using System;

namespace Sandbox.Solutions.Medium;

public class StockSpanner
{
    private int _index;
    private readonly Stack<(int, int)> _st;

    public StockSpanner()
    {
        _st = new Stack<(int, int)>(10000);
    }

    public int Next(int price)
    {
        int value;
        while (_st.Count > 0 && _st.TryPeek(out var tuple) && tuple.Item1 <= price)
            _st.Pop();

        if (_st.Count > 0)
            value = _index - _st.Peek().Item2;

        // bigger than the whole prev values
        else
            value = _index + 1;

        _st.Push((price, _index));
        _index++;

        return value;
    }
}