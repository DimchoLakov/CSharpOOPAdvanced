using System;
using System.Linq;

public class Database
{
    private Person[] people;
    private const int defaultArraySize = 16;
    private int currentIndex;

    public Database()
    {
        this.currentIndex = 0;
        this.people = new Person[defaultArraySize];
    }

    public Database(params Person[] values) : this()
    {
        this.InitializeArray(values);
    }

    public Person FindById(long id)
    {
        var person = this.people.Where(p => p != null).FirstOrDefault(p => p.Id == id);
        if (person == null)
        {
            throw new InvalidOperationException();
        }

        if (person.Id < 0)
        {
            throw new ArgumentOutOfRangeException();
        }

        return person;
    }

    public Person FindByName(string name)
    {
        if (name == null)
        {
            throw new ArgumentNullException();
        }

        var person = this.people.Where(p => p != null).FirstOrDefault(p => p.Name == name);

        if (person == null)
        {
            throw new InvalidOperationException($"No person with name {name} is found!");
        }

        return person;
    }

    public void Add(Person person)
    {
        if (currentIndex >= defaultArraySize)
        {
            throw new InvalidOperationException();
        }

        if (this.people.Where(p => p != null).Any(p => p.Name == person.Name))
        {
            throw new InvalidOperationException($"Person with name {person.Name} already exists!");
        }

        if (this.people.Where(p => p != null).Any(p => p.Id == person.Id))
        {
            throw new InvalidOperationException($"Person with name {person.Id} already exists!");
        }

        this.people[currentIndex] = person;
        this.currentIndex++;
    }

    public void Remove()
    {
        if (this.currentIndex == 0)
        {
            throw new InvalidOperationException();
        }
        this.currentIndex--;
        this.people[currentIndex] = null;
    }

    public Person[] Fetch()
    {
        Person[] arr = new Person[this.currentIndex];
        for (int i = 0; i < currentIndex; i++)
        {
            arr[i] = this.people[i];
        }
        return arr;
    }

    private void InitializeArray(Person[] values)
    {
        try
        {
            Array.Copy(values, this.people, values.Length);
            this.currentIndex = values.Length;
        }
        catch (Exception)
        {
            throw new InvalidOperationException();
        }

        //foreach (var num in values)
        //{
        //    this.Add(num);
        //}
    }
}