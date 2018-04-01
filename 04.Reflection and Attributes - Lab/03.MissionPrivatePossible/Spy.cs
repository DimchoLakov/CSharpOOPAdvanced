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

    public string AnalyzeAcessModifiers(string className)
    {
        Type typeOfClass = Type.GetType(className);
        
        FieldInfo[] publicFields = typeOfClass.
            GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static);

        MethodInfo[] publicMethods = typeOfClass
            .GetMethods(BindingFlags.Public | BindingFlags.Instance);

        MethodInfo[] privateMethods = typeOfClass
            .GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);


        StringBuilder sb = new StringBuilder();

        foreach (FieldInfo fieldInfo in publicFields)
        {
            sb.AppendLine($"{fieldInfo.Name} must be private!");
        }

        foreach (MethodInfo methodInfo in privateMethods.Where(m => m.Name.StartsWith("get")))
        {
            sb.AppendLine($"{methodInfo.Name} have to be public!");
        }

        foreach (MethodInfo methodInfo in publicMethods.Where(m => m.Name.StartsWith("set")))
        {
            sb.AppendLine($"{methodInfo.Name} have to be private!");
        }

        return sb.ToString().Trim();
    }

    public string RevealPrivateMethods(string className)
    {
        Type typeOfClass = Type.GetType(className);

        MethodInfo[] methodsInfo = typeOfClass.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

        StringBuilder sb = new StringBuilder();

        sb.AppendLine($"All Private Methods of Class: {className}");
        sb.AppendLine($"Base Class: {typeOfClass.BaseType.Name}");

        foreach (MethodInfo methodInfo in methodsInfo)
        {
            sb.AppendLine($"{methodInfo.Name}");
        }

        return sb.ToString().Trim();
    }
}