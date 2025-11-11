using System;
using System.Collections.Generic;

public class PersonQueue
{
    private readonly List<Person> _queue = new List<Person>();

    public int Length => _queue.Count;

    public void Enqueue(Person person)
    {
        _queue.Add(person); // FIXED: Changed from Insert(0, person) to Add(person)
    }

    public Person Dequeue()
    {
        if (_queue.Count == 0)
            throw new InvalidOperationException("Queue is empty");
            
        var person = _queue[0];
        _queue.RemoveAt(0);
        return person;
    }

    public bool IsEmpty()
    {
        return Length == 0;
    }

    public override string ToString()
    {
        return $"[{string.Join(", ", _queue)}]";
    }
}