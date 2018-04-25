public class Launcher
{
    public static void Main()
    {
        var energyRepository = new EnergyRepository();

        var harvesterController = new HarvesterController(energyRepository);
        var providerController = new ProviderController(energyRepository);

        var commandInterpreter = new CommandInterpreter(harvesterController, providerController);

        var reader = new Reader();
        var writer = new Writer();

        Engine engine = new Engine(commandInterpreter, reader, writer);
        engine.Run();
    }
}