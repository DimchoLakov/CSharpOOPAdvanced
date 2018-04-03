using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class AuthorCommand : Command
{
    public AuthorCommand(string[] data) : base(data)
    {
    }

    public override void Execute()
    {
        string author = this.Data[0];

        Type typeOfWeapon = Type.GetType(nameof(Weapon));

        MyCustomAttribute myAttribute =
            (MyCustomAttribute)Attribute.GetCustomAttribute(typeOfWeapon, typeof(MyCustomAttribute));

        Console.WriteLine($"{author}: {myAttribute.Author}");
    }
}