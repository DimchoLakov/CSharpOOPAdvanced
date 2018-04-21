using System;

public class Calculate : IMath
{
    public decimal Abs(decimal value)
    {
        return Math.Abs(value);
    }

    public decimal Floor(decimal value)
    {
        return Math.Floor(value);
    }
}