using System;
using System.Collections.Generic;

public class King : IKing
{
    private ICollection<ISubordinate> subordinates;

    public King(string name, ICollection<ISubordinate> subordinates)
    {
        this.Name = name;
        this.subordinates = subordinates;
    }

    public event GetAttackedEventHandler GetAttackedEvent;

    public string Name { get; }

    public IReadOnlyCollection<ISubordinate> Subordinates 
        => (IReadOnlyCollection<ISubordinate>) this.subordinates;

    public void AddSubordinate(ISubordinate subordinate)
    {
        this.subordinates.Add(subordinate);
        this.GetAttackedEvent += subordinate.ReactToAttack;
    }

    public void GetAttacked()
    {
        Console.WriteLine($"{this.GetType().Name} {this.Name} is under attack!");

        GetAttackedEvent?.Invoke();
    }
}