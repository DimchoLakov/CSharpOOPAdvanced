using System;
using Logger.Enums;
using Logger.Interfaces;

namespace Logger.Models
{
    public class Error : IError
    {
        public Error(DateTime dateTime, ErrorLevel errorLevel, string message)
        {
            this.DateTime = dateTime;
            this.ErrorLevel = errorLevel;
            this.Message = message;
        }

        public DateTime DateTime { get; }
        public string Message { get; }
        public ErrorLevel ErrorLevel { get; }
    }
}