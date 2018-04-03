using System;

public class ReviewersCommand : Command
{
    public ReviewersCommand(string[] data) : base(data)
    {
    }

    public override void Execute()
    {
        string reviewersAsString = this.Data[0];

        Type typeOfWeapon = Type.GetType(nameof(Weapon));

        MyCustomAttribute myAttribute =
            (MyCustomAttribute) Attribute.GetCustomAttribute(typeOfWeapon, typeof(MyCustomAttribute));

        Console.WriteLine($"{reviewersAsString}: {string.Join(", ", myAttribute.Reviewers)}");
    }
}