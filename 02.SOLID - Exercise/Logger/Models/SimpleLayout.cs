using System.Globalization;
using Logger.Interfaces;

namespace Logger.Models
{
    public class SimpleLayout : ILayout
    {
        private const string DateFormat = "M/d/yyyy h:mm:ss tt";

        //// error.DateTime - error.ErrorLevel - error.Message
        //private const string DateFormat = "M/d/yyyy h:mm:ss tt";
        //private const string Format = "{0} - {1} - {2}";

        public string FormatError(IError error)
        {
            string dateTimeToString = error.DateTime.ToString(DateFormat, CultureInfo.InvariantCulture);
            return $"{dateTimeToString} - {error.ErrorLevel} - {error.Message}";
        }
    }
}