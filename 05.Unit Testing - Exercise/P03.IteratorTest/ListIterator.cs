using System;
using System.Collections.Generic;
using System.Linq;

public class ListIterator
{
    private List<string> iteratorList;

    public ListIterator(params string[] items)
    {
        this.Index = 0;
        this.iteratorList = InitializeList(items);
    }

    private List<string> InitializeList(params string[] collection)
    {
        if (collection.Contains(null))
        {
            throw new ArgumentNullException();
        }

        return new List<string>(collection);
    }

    private int Index { get; set; }

    public bool Move()
    {
        if (this.Index + 1 < this.iteratorList.Count)
        {
            this.Index++;
            return true;
        }

        return false;
    }

    public bool HasNext()
    {
        if (this.Index == this.iteratorList.Count - 1)
        {
            return false;
        }

        return true;
    }

    public void Print()
    {
        if (!this.iteratorList.Any() || this.Index < 0 || this.Index > this.iteratorList.Count - 1)
        {
            throw new InvalidOperationException("Invalid Operation");
        }

        Console.WriteLine(this.iteratorList[this.Index]);
    }
}