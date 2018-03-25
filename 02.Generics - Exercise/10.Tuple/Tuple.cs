public class Tuple<T1, T2>
{
    public T1 FirstItem { get; set; }
    public T2 SecondItem { get; set; }
    
    public Tuple()
    {

    }

    public Tuple(T1 firstItem, T2 secondItem)
    {
        this.FirstItem = firstItem;
        this.SecondItem = secondItem;
    }
}