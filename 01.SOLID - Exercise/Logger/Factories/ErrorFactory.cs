using System;
using System.Globalization;
using Logger.Enums;
using Logger.Interfaces;
using Logger.Models;

namespace Logger.Factories
{
    public class ErrorFactory
    {
        private const string DateFormat = "M/d/yyyy h:mm:ss tt";
        public IError CreateError(string dateTimeToString, string errorLevelToString, string message)
        {
            DateTime dateTime = DateTime.ParseExact(dateTimeToString, DateFormat, CultureInfo.InvariantCulture);
            ErrorLevel errorLevel = ParseErrorLevel(errorLevelToString);

            IError error = new Error(dateTime, errorLevel, message);
            return error;
        }

        private ErrorLevel ParseErrorLevel(string erLevel)
        {
            try
            {
                object levelObj = Enum.Parse(typeof(ErrorLevel), erLevel);
                return (ErrorLevel)levelObj;
            }
            catch (Exception exception)
            {
                throw new ArgumentException("Invalid ErrorLevel Type!", exception);
            }
        }
    }
}
