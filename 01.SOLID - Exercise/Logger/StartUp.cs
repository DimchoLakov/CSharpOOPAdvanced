using System;
using System.Collections.Generic;
using Logger.Factories;
using Logger.Interfaces;

namespace Logger
{
    using Models;
    public class StartUp
    {
        public static void Main()
        {
            ILogger logger = InitializeLogger();
            ErrorFactory errorFactory = new ErrorFactory();
            Engine engine = new Engine(logger, errorFactory);
            engine.Run();

        }

        static ILogger InitializeLogger()
        {
            ICollection<IAppender> appenders = new List<IAppender>();
            LayoutFactory layoutFactory = new LayoutFactory();
            AppenderFactory appenderFactory = new AppenderFactory(layoutFactory);
            
            int appendersCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < appendersCount; i++)
            {
                string[] tokens = Console.ReadLine().Split();
                string appenderType = tokens[0];
                string layoutType = tokens[1];
                string errorLevel = "INFO";

                if (tokens.Length > 2)
                {
                    errorLevel = tokens[2];
                }

                IAppender appender = appenderFactory.CreateAppender(appenderType, errorLevel, layoutType);
                appenders.Add(appender);
            }

            ILogger iLogger = new Logger(appenders);
            return iLogger;
        }
    }
}
