using System;
using System.Collections.Generic;

public class PriorityQueue
{
    private List<PriorityItem> _queue = new List<PriorityItem>();

    public int Length => _queue.Count;

    public void Enqueue(string value, int priority)
    {
        var newNode = new PriorityItem(value, priority);
        _queue.Add(newNode);
    }

    public string Dequeue()
    {
        if (_queue.Count == 0)
        {
            throw new InvalidOperationException("The queue is empty.");
        }

        // FIXED: Loop through all elements and use > instead of >=
        var highPriorityIndex = 0;
        for (int index = 1; index < _queue.Count; index++) // FIXED: Changed to _queue.Count
        {
            if (_queue[index].Priority > _queue[highPriorityIndex].Priority) // FIXED: Changed to >
                highPriorityIndex = index;
        }

        // FIXED: Actually remove the item from the queue
        var value = _queue[highPriorityIndex].Value;
        _queue.RemoveAt(highPriorityIndex); // FIXED: Added this line
        return value;
    }

    public override string ToString()
    {
        return $"[{string.Join(", ", _queue)}]";
    }
}

public class PriorityItem
{
    public string Value { get; set; }
    public int Priority { get; set; }

    public PriorityItem(string value, int priority)
    {
        Value = value;
        Priority = priority;
    }

    public override string ToString()
    {
        return $"{Value} (Pri:{Priority})";
    }
}