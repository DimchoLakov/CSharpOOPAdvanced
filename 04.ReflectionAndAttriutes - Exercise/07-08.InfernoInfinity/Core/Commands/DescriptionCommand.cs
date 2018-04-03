using System;

public class DescriptionCommand : Command
{
    public DescriptionCommand(string[] data) : base(data)
    {
    }

    public override void Execute()
    {
        Type typeOfWeapon = Type.GetType(nameof(Weapon));

        MyCustomAttribute myAttribute = (MyCustomAttribute)Attribute.GetCustomAttribute(typeOfWeapon, typeof(MyCustomAttribute));

        Console.WriteLine($"Class description: {myAttribute.Description}");
    }
}