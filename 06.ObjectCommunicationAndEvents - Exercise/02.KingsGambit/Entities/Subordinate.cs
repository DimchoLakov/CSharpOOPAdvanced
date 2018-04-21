using System;

public abstract class Subordinate : ISubordinate
{
    public Subordinate(string name, string action)
    {
        this.Name = name;
        this.Action = action;
        this.isAlive = true;
    }

    public string Name { get; }
    public bool isAlive { get; private set; }
    public void Die()
    {
        this.isAlive = false;
    }

    public string Action { get; }

    public virtual void ReactToAttack()
    {
        if (isAlive)
        {
            Console.WriteLine($"{this.GetType().Name} {this.Name} is {this.Action}!");
        }
    }
}