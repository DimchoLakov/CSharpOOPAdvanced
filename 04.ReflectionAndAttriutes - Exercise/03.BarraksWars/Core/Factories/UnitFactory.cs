using System;
using System.Reflection;

public class UnitFactory : IUnitFactory
{
    public IUnit CreateUnit(string unitType)
    {
        var assembly = Assembly.GetExecutingAssembly();
        Type model = assembly.GetType(unitType);

        if (model == null)
        {
            throw new ArgumentException("Invalid Unit Type!");
        }

        bool isAssignable = typeof(IUnit).IsAssignableFrom(model);

        if (!isAssignable)
        {
            throw new ArgumentException($"{unitType} is NOT a Unit Type");
        }

        //return (IUnit)Activator.CreateInstance(Type.GetType(unitType));
        return (IUnit)Activator.CreateInstance(model);
    }
}