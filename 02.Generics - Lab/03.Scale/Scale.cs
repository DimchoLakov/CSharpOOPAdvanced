using System;
public class Scale<T>
    where T : IComparable<T>
{
    public T Left { get; private set; }

    public T Right { get; private set; }

    public Scale(T left, T right)
    {
        this.Left = left;
        this.Right = right;
    }

    public T GetHeavier()
    {
        var compareToResult = this.Left.CompareTo(this.Right);

        if (compareToResult < 0)
        {
            return this.Right;
        }

        if (compareToResult > 0)
        {
            return this.Left;
        }

        return default(T);
    }
}