public interface IHarvesterController : IController
{
    double TotalOreProduced { get; }

    string ChangeMode(string mode);
}