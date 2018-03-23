using System;
using System.Globalization;
using Logger.Interfaces;

namespace Logger.Models
{
    public class XmlLayout : ILayout
    {
        private const string DateFormat = "M/d/yyyy h:mm:ss tt";

        private string Format = "<log>" + Environment.NewLine +
                                    "\t<date>{0}</date>" + Environment.NewLine +
                                    "\t<level>{1}</level>" + Environment.NewLine +
                                    "\t<message>{2}</message>" + Environment.NewLine +
                                "</log>";
        public string FormatError(IError error)
        {
            string dateToString = error.DateTime.ToString(DateFormat, CultureInfo.InvariantCulture);
            string formattedError = string.Format(Format, dateToString, error.ToString(), error.Message);
            return formattedError;
        }
    }
}
