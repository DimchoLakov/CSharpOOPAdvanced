using System;
using Microsoft.Extensions.DependencyInjection;

public class Startup
{
    public static void Main()
    {
        IServiceProvider serviceProvider = ConfigureServices();

        ICommandInterpreter commandInterpreter = new CommandInterpreter(serviceProvider);
        IRunnable engine = new Engine(commandInterpreter);
        engine.Run();
    }

    private static IServiceProvider ConfigureServices()
    {
        IServiceCollection services = new ServiceCollection();

        services.AddSingleton<IReposirtory, WeaponRepository>();
        services.AddTransient<IWeaponFactory, WeaponFactory>();
        services.AddTransient<IGemFactory, GemFactory>();

        IServiceProvider serviceProvider = services.BuildServiceProvider();

        return serviceProvider;
    }
}