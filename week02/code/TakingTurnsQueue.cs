using System;

public class TakingTurnsQueue
{
    private readonly PersonQueue _people = new PersonQueue();

    public int Length => _people.Length;

    public void AddPerson(string name, int turns)
    {
        var person = new Person(name, turns);
        _people.Enqueue(person);
    }

    public Person GetNextPerson()
    {
        if (_people.IsEmpty())
        {
            throw new InvalidOperationException("No one in the queue.");
        }

        Person person = _people.Dequeue();
        
        // FIXED: Handle infinite turns (turns <= 0) and multiple turns correctly
        if (person.Turns <= 0 || person.Turns > 1)
        {
            Person newPerson = person.Turns <= 0 
                ? new Person(person.Name, person.Turns) // Keep same turns for infinite
                : new Person(person.Name, person.Turns - 1); // Decrement turns
            _people.Enqueue(newPerson);
        }

        return person;
    }

    public override string ToString()
    {
        return _people.ToString();
    }
}