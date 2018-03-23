using System.Globalization;
using Logger.Interfaces;

namespace Logger.Models
{
    public class JsonLayout : ILayout
    {
        private const string DateFormat = "M/d/yyyy h:mm:ss tt";

        private string Format = "{{ DateTime: {0}, Error Level: {1}, Error Message: {2} }}";
        public string FormatError(IError error)
        {
            string dateTimeToString = error.DateTime.ToString(DateFormat, CultureInfo.InvariantCulture);
            string formattedError = string.Format(Format, dateTimeToString, error.ToString(), error.Message);
            return formattedError;
        }
    }
}
