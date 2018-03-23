using System.Collections.Generic;
using Logger.Interfaces;

namespace Logger.Models
{
    public class Logger : ILogger
    {
        private readonly IReadOnlyCollection<IAppender> appenders;

        public Logger(ICollection<IAppender> appenders)
        {
            this.appenders = (IReadOnlyCollection<IAppender>)appenders;
        }

        public IReadOnlyCollection<IAppender> Appenders => this.appenders;

        public void Log(IError error)
        {
            foreach (IAppender appender in this.appenders)
            {
                if (appender.ErrorLevel <= error.ErrorLevel)
                {
                    appender.Append(error);
                }
            }
        }
    }
}