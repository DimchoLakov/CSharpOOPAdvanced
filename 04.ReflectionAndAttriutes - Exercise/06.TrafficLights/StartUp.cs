using System;
using System.Collections.Generic;

public class StartUp
{
    public static void Main()
    {
        var lightTokens = Console.ReadLine().Split();

        var trafficLights = new List<TrafficLight>();

        foreach (string lightToken in lightTokens)
        {
            var isLight = Enum.TryParse(lightToken, out Light light);

            if (isLight)
            {
                trafficLights.Add(new TrafficLight(light));
            }
        }

        var result = string.Empty;

        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            foreach (TrafficLight trafficLight in trafficLights)
            {
                trafficLight.ChangeLights();
            }

            result = string.Join(" ", trafficLights);
            Console.WriteLine(result);
        }
    }
}