namespace Sandbox.DataStructures;

public class LinkedList
{
    private LinkedList<int> _linkedList = new();

    public void WorkWithLinkedList()
    {
        var list = new List<int> { 1, 2, 3, 4, 5 };
        _linkedList = new LinkedList<int>(list);

        _linkedList.AddLast(6);
        _linkedList.AddFirst(-1);

        _linkedList.RemoveFirst();
        _linkedList.RemoveLast();

        var first = _linkedList.First;
    }
}