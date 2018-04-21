using System;

public class CombatLogger : Logger
{
    public override void Handle(LogType logType, string message)
    {
        switch (logType)
        {
            case LogType.ATTACK:
                Console.WriteLine($"{logType}: {message}");
                break;
            case LogType.MAGIC:
                Console.WriteLine($"{logType}: {message}");
                break;
        }

        this.PassToSuccessor(logType, message);
    }
}