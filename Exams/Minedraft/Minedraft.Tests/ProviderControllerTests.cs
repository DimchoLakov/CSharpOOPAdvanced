using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

[TestFixture]
public class ProviderControllerTests
{
    private EnergyRepository energyRepository;
    private ProviderController providerController;

    [SetUp]
    public void Initialize()
    {
        this.energyRepository = new EnergyRepository();
        this.providerController = new ProviderController(energyRepository);
    }

    [Test]
    public void TestTotalEnergyProduced()
    {
        var thirdList = new List<string>() { "Pressure", "100", "100" };

        this.providerController.Register(thirdList);

        this.providerController.Produce();

        Assert.That(this.providerController.TotalEnergyProduced, Is.EqualTo(200));
    }

    [Test]
    public void TestBrokeMethod()
    {
        var fisrt = new List<string>() { "Pressure", "10", "100" };

        this.providerController.Register(fisrt);

        for (int i = 0; i < 8; i++)
        {
            this.providerController.Produce();
        }

        Assert.That(this.providerController.Entities.Count, Is.EqualTo(0));
    }

    [Test]
    public void TestProvidersAreRepaired()
    {
        var standartProvider = new List<string>() { "Standart", "10", "100" };

        this.providerController.Register(standartProvider);

        this.providerController.Repair(200);

        Assert.That(this.providerController.Entities.ToList()[0].Durability, Is.EqualTo(1200));
    }
}