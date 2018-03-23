using System;
using Logger.Enums;

namespace Logger.Interfaces
{
    public interface IError
    {
        DateTime DateTime { get; }

        string Message { get; }

        ErrorLevel ErrorLevel { get; }
    }
}
