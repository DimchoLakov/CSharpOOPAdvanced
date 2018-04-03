using System.Collections.Generic;

public abstract class Command : ICommand
{
    private string[] data;

    protected Command(string[] data)
    {
        this.Data = data;
    }

    public string[] Data
    {
        get => this.data;
        private set => this.data = value;
    }

    public abstract void Execute();
}