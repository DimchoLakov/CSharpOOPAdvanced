using System;
using System.Linq;
using System.Reflection;
using System.Text;

public class HarvestingFieldsTest
{
    public static void Main()
    {
        string input = Console.ReadLine();

        while (input != "HARVEST")
        {
            string result = GetFieldsInfo(input);

            Console.WriteLine(result);

            input = Console.ReadLine();
        }
    }

    private static string GetFieldsInfo(string input)
    {
        StringBuilder sb = new StringBuilder();

        Type typeOfHarvestingFields = Type.GetType(nameof(HarvestingFields));

        var instance = (HarvestingFields)Activator.CreateInstance(typeof(HarvestingFields));

        switch (input)
        {
            case "private":
                FieldInfo[] privateFieldsInfo = typeOfHarvestingFields
                    .GetFields(BindingFlags.NonPublic | BindingFlags.Instance);

                foreach (FieldInfo fieldInfo in privateFieldsInfo.Where(f => f.IsPrivate))
                {
                    sb.AppendLine($"private {fieldInfo.FieldType.Name} {fieldInfo.Name}");
                }

                break;
            case "protected":
                FieldInfo[] protectedFieldsInfo = typeOfHarvestingFields
                    .GetFields(BindingFlags.NonPublic | BindingFlags.Instance);

                foreach (FieldInfo fieldInfo in protectedFieldsInfo.Where(f => f.IsFamily))
                {
                    sb.AppendLine($"protected {fieldInfo.FieldType.Name} {fieldInfo.Name}");
                }

                break;
            case "public":
                FieldInfo[] publicFieldsInfo = typeOfHarvestingFields
                    .GetFields(BindingFlags.Public | BindingFlags.Instance);

                foreach (FieldInfo fieldInfo in publicFieldsInfo)
                {
                    sb.AppendLine($"public {fieldInfo.FieldType.Name} {fieldInfo.Name}");
                }

                break;
            case "all":
                FieldInfo[] allDeclaredFieldsInfo = typeOfHarvestingFields
                    .GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.DeclaredOnly);

                foreach (FieldInfo fieldInfo in allDeclaredFieldsInfo)
                {
                    string accessModfierToString = fieldInfo.IsPublic ? "public" : fieldInfo.IsPrivate ? "private" : fieldInfo.IsFamily ? "protected" : "internal";
                    sb.AppendLine($"{accessModfierToString} {fieldInfo.FieldType.Name} {fieldInfo.Name}");
                }

                break;
        }

        return sb.ToString().Trim();
    }
}