using System;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{
    public string StealFieldInfo(string nameOfClass, params string[] fields)
    {
        StringBuilder sb = new StringBuilder();

        Type typeOfClass = Type.GetType(nameOfClass);

        sb.AppendLine($"Class under investigation: {nameOfClass}");

        object hackerInstance = Activator.CreateInstance(typeOfClass, new object[] { });
        //var hackerInstance = Activator.CreateInstance<Hacker>();

        var fieldsArray = typeOfClass.GetFields(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

        foreach (FieldInfo fieldInfo in fieldsArray.Where(f => fields.Contains(f.Name)))
        {
            sb.AppendLine($"{fieldInfo.Name} = {fieldInfo.GetValue(hackerInstance)}");
        }

        return sb.ToString().Trim();
    }
}