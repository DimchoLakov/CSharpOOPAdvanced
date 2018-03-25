using System;
public class Box<T> : IComparable<Box<T>> where T : IComparable<T>
{
    public T Item { get; set; }

    public Box(T item)
    {
        this.Item = item;
    }
    public override string ToString()
    {
        return $"{this.Item.GetType().FullName}: {this.Item}";
    }

    public int CompareTo(Box<T> otherBox)
    {
        return this.Item.CompareTo(otherBox.Item);
    }
}