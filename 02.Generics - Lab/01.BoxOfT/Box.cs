using System.Collections;
using System.Collections.Generic;
public class Box<T> : IEnumerable<T>
{
    private readonly List<T> items;

    public Box()
    {
        this.items = new List<T>();
    }

    public IReadOnlyCollection<T> Items => this.items.AsReadOnly();

    public void Add(T element)
    {
        this.items.Add(element);
    }

    public T Remove()
    {
        T element = this.items[this.items.Count - 1];
        this.items.RemoveAt(this.items.Count - 1);
        return element;
    }

    public int Count => this.items.Count;
    public IEnumerator<T> GetEnumerator()
    {
        return this.items.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.items.GetEnumerator();
    }
}