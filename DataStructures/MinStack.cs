namespace Sandbox.DataStructures;

public class MinStack
{
    private Stack<StackNode> _stack;
    private const int MaxSize = 30000;
    public MinStack()
    {
        _stack = new Stack<StackNode>(MaxSize);
    }

    public void Push(int val)
    {
        _stack.Push(!_stack.Any() ? new StackNode(val, val) : new StackNode(val, Math.Min(val, _stack.Peek()._min)));
    }

    public void Pop()
    {
        _stack.Pop();
    }

    public int Top()
    {
        return _stack.Peek()._val;
    }

    public int GetMin()
    {
        return _stack.Peek()._min;
    }
}

internal class StackNode
{
    public int _val { get; private set; }
    public int _min { get; private set; }
    public StackNode(int val, int min)
    {
        _val = val;
        _min = min;
    }
}