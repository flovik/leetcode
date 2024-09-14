using System;
using System.Reflection;

namespace Sandbox.Solutions.Medium;

public class SingleThreadedCPU
{
    public int[] GetOrder(int[][] tasks)
    {
        var result = new List<int>(tasks.Length);
        var processingMinHeap = new PriorityQueue<int, (int, int)>(tasks.Length);
        var enqueueTimeMinHeap = new PriorityQueue<int, (int, int)>(tasks.Length);

        // enqueue by enqueue time and then by index
        for (int i = 0; i < tasks.Length; i++)
        {
            var task = tasks[i];
            enqueueTimeMinHeap.Enqueue(task[1], (task[0], i));
        }

        enqueueTimeMinHeap.TryPeek(out _, out var startProcessingTime);
        var currentProcessingTime = startProcessingTime.Item1;

        while (enqueueTimeMinHeap.Count > 0)
        {
            if (processingMinHeap.Count == 0)
            {
                enqueueTimeMinHeap.TryPeek(out _, out var newStartProcessingTime);
                currentProcessingTime = newStartProcessingTime.Item1;
            }
            else
            {
                processingMinHeap.TryDequeue(out var index, out var processing);
                result.Add(index);
                currentProcessingTime += processing.Item1;
            }

            while (enqueueTimeMinHeap.TryPeek(out var processingTime, out var newStartProcessingTime) &&
                   currentProcessingTime >= newStartProcessingTime.Item1) // add new tasks that became available to processing
            {
                // save index and processing time
                processingMinHeap.Enqueue(newStartProcessingTime.Item2, (processingTime, newStartProcessingTime.Item2));
                enqueueTimeMinHeap.Dequeue();
            }
        }

        while (processingMinHeap.Count > 0)
        {
            result.Add(processingMinHeap.Dequeue());
        }

        return result.ToArray();
    }
}