using System;
using System.Reflection;

public class GemFactory : IGemFactory
{
    public IGem CreateGem(string name, Clarity clarity)
    {
        var assembly = Assembly.GetExecutingAssembly();
        var model = assembly.GetType(name + "Gem");

        if (model == null)
        {
            throw new ArgumentException($"Invalid Gem");
        }

        var isAssignable = typeof(IGem).IsAssignableFrom(model);

        if (!isAssignable)
        {
            throw new ArgumentException($"{name} is not a Gem!");
        }

        return (IGem)Activator.CreateInstance(model, new object[] { name, clarity });
    }
}