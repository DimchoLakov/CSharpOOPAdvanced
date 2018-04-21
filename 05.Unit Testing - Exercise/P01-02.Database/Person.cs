using System;

public class Person : IComparable<Person>
{
    public Person(string name, long id)
    {
        this.Name = name;
        this.Id = id;
    }

    public string Name { get; private set; }

    public long Id { get; private set; }

    public int CompareTo(Person other)
    {
        int result = this.Name.CompareTo(other.Name);

        if (result == 0)
        {
            result = this.Id.CompareTo(other.Id);
        }

        return result;
    }

    public override string ToString()
    {
        return $"Name: {this.Name}, ID: {this.Id}";
    }
}