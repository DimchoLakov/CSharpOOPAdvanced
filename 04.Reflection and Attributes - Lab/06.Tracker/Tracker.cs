using System;
using System.Linq;
using System.Reflection;

public class Tracker
{
    public void PrintMethodsByAuthor()
    {
        Type startupType = typeof(StartUp);

        MethodInfo[] methods = startupType
            .GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);

        foreach (MethodInfo methodInfo in methods)
        {
            if (methodInfo.CustomAttributes.Any(n => n.AttributeType == typeof(SoftUniAttribute)))
            {
                object[] attributes = methodInfo.GetCustomAttributes(false);

                foreach (SoftUniAttribute attribute in attributes)
                {
                    Console.WriteLine($"{methodInfo.Name} is written by {attribute.Name}");
                }
            }
        }
    }
}