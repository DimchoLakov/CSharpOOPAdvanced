using System.Collections.Generic;

public interface IBaseStats
{
    int MinDamage { get; }

    int MaxDamage { get; }

    int NumberOfSockets { get; }
}