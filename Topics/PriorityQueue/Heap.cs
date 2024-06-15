using System.Security.Cryptography;

namespace Sandbox.Topics.PriorityQueue;

/// <summary>
/// Minheap implementation
/// Insert: O (log n)
/// Delete: O (log n)
///
/// Used: Dijkstra's, Huffman Encoding (lossless data compression), A&, Minimum Spanning Tree
/// </summary>
public class Heap
{
    // min heap keeps the ordering in increasing order
    // max heap keep the ordering in decreasing order
    //
    // heaps are implemented using arrays
    // 2i + 1 - left child, 2i + 2 - right child
    // (i - 1) / 2 - parent

    private List<int> _data;

    public Heap(int capacity)
    {
        _data = new List<int>(capacity);
    }

    public void Enqueue(int value)
    {
        _data[^1] = value;
        HeapifyUp(_data.Count);
    }

    public int Dequeue()
    {
        if (_data.Count == 0)
            throw new ArgumentOutOfRangeException("Heap is empty");

        var dq = _data[0];

        if (_data.Count == 1)
        {
            _data.Clear();
            return dq;
        }

        // swap last element with first one
        _data[0] = _data[^1];
        HeapifyDown(0);
        return dq;
    }

    private void HeapifyUp(int index)
    {
        if (index == 0)
            return;

        // look at parent, get it's value, check if it larger, swap
        var parent = Parent(index);
        var parentValue = _data[parent];
        var curValue = _data[index];

        if (parentValue > curValue)
        {
            _data[parent] = curValue;
            _data[index] = parentValue;

            HeapifyUp(parent);
        }
    }

    private void HeapifyDown(int index)
    {
        // remove head element
        // take last element from list

        var left = LeftChild(index);
        var right = RightChild(index);

        if (index >= _data.Count || left >= _data.Count)
            return;

        var leftValue = _data[left];
        var rightValue = _data[right];
        var curValue = _data[index];

        if (leftValue > rightValue && curValue > rightValue)
        {
            _data[index] = rightValue;
            _data[right] = curValue;

            HeapifyDown(right);
        }
        else if (rightValue > leftValue && curValue > leftValue)
        {
            _data[index] = leftValue;
            _data[left] = curValue;
            HeapifyDown(left);
        }
    }

    private int Parent(int index) => (index - 1) / 2;

    private int LeftChild(int index) => 2 * index + 1;

    private int RightChild(int index) => 2 * index + 2;
}