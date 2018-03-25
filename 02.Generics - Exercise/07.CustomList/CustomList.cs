using System;
using System.Collections.Generic;
using System.Linq;

public class CustomList<T> where T : IComparable<T>
{
    private readonly List<T> items;

    public IReadOnlyCollection<T> Items => this.items.AsReadOnly();

    public CustomList()
    {
        this.items = new List<T>();
    }

    public void Add(T element)
    {
        this.items.Add(element);
    }

    public T Remove(int index)
    {
        T item = this.items[index];
        this.items.RemoveAt(index);
        return item;
    }

    public bool Contains(T element)
    {
        return this.items.Contains(element);
    }

    public void Swap(int firstIndex, int secondIndex)
    {
        var temp = this.items[firstIndex];
        this.items[firstIndex] = this.items[secondIndex];
        this.items[secondIndex] = temp;
    }

    public int CountGreaterThan(T element)
    {
        int count = 0;

        foreach (T item in this.items)
        {
            if (item.CompareTo(element) > 0)
            {
                count++;
            }
        }

        return count;
    }

    public T Max()
    {
        return this.items.Max();
    }

    public T Min()
    {
        return this.items.Min();
    }
}