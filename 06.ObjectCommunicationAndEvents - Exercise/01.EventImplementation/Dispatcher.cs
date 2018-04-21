public delegate void NameChangedEventHandler(object sender, NameChangeEventArgs args);

public class Dispatcher
{
    private string name;
    public event NameChangedEventHandler NameChange;

    public string Name
    {
        get { return this.name; }
        set
        {
            this.name = value;
            OnNameChange(new NameChangeEventArgs(value));
        }
    }

    public void OnNameChange(NameChangeEventArgs args)
    {
        this.NameChange?.Invoke(this, args);
    }
}