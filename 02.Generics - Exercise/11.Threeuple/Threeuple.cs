public class Threeuple<T1, T2, T3>
{
    public T1 FirstItem { get; set; }

    public T2 SecondItem { get; set; }

    public T3 ThirdItem { get; set; }
    
    public Threeuple()
    {

    }

    public Threeuple(T1 firstItem, T2 secondItem, T3 thirdItem)
    {
        this.FirstItem = firstItem;
        this.SecondItem = secondItem;
        this.ThirdItem = thirdItem;
    }
}