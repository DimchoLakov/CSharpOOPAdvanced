using System;
using Logger.Enums;
using Logger.Interfaces;
using Logger.Models;

namespace Logger.Factories
{
    public class AppenderFactory
    {
        private const string DefaultFileName = "logFile{0}.txt";
        private readonly LayoutFactory layoutFactory;
        private int fileNumber;
        public AppenderFactory(LayoutFactory layoutFactory)
        {
            this.layoutFactory = layoutFactory;
            this.fileNumber = 0;
        }
        public IAppender CreateAppender(string appenderType, string erLevel, string layoutType)
        {
            ILayout iLayout = this.layoutFactory.CreateLayout(layoutType);
            ErrorLevel errorLevel = this.ParseErrorLevel(erLevel);

            IAppender iAppender = null;

            switch (appenderType)
            {
                case "ConsoleAppender":
                    iAppender = new ConsoleAppender(iLayout, errorLevel);
                    break;
                case "FileAppender":
                    ILogFile logFile = new LogFile(string.Format(DefaultFileName, this.fileNumber));
                    iAppender = new FileAppender(iLayout, errorLevel, logFile);
                    this.fileNumber++;
                    break;
                default:
                    throw new ArgumentException("Invalid Appender Type!");
            }

            return iAppender;
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
