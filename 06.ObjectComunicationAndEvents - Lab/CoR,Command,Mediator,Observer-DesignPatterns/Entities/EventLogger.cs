using System;

public class EventLogger : Logger
{
    public override void Handle(LogType logType, string message)
    {
        switch (logType)
        {
            case LogType.ERROR:
                Console.WriteLine($"{logType}: {message}");
                break;
            case LogType.EVENT:
                Console.WriteLine($"{logType}: {message}");
                break;
            case LogType.TARGET:
                Console.WriteLine($"{logType}: {message}");
                break;
        }

        this.PassToSuccessor(logType, message);
    }
}