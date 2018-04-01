using System;
using System.Linq;
using System.Reflection;

public class BlackBoxIntegerTests
{
    public static void Main()
    {
        var blackBoxInstance = Activator.CreateInstance(typeof(BlackBoxInteger), true);

        var typeOfBlackBox = Type.GetType(nameof(BlackBoxInteger));

        MethodInfo[] methods = typeOfBlackBox.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

        string input = Console.ReadLine();

        while (input != "END")
        {
            string[] tokens = input.Split('_');
            string methodName = tokens[0];
            int val = int.Parse(tokens[1]);

            var method = methods.Where(m => m.Name == methodName).First();
            method.Invoke(blackBoxInstance, new object[] { val });

            FieldInfo field = typeOfBlackBox.GetField("innerValue", BindingFlags.Instance | BindingFlags.NonPublic);

            var value = field?.GetValue(blackBoxInstance);

            Console.WriteLine(value);

            input = Console.ReadLine();
        }
    }
}