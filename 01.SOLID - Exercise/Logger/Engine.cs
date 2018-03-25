using System;
using Logger.Factories;
using Logger.Interfaces;
using Logger.Models;

namespace Logger
{
    public class Engine
    {
        private ILogger logger;
        private ErrorFactory errorFactory;
        public Engine(ILogger logger, ErrorFactory errorFactory)
        {
            this.errorFactory = errorFactory;
            this.logger = logger;
        }

        public void Run()
        {
            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] tokens = input.Split('|');

                string errLevel = tokens[0];
                string dateTimeToString = tokens[1];
                string message = tokens[2];

                IError error = this.errorFactory.CreateError(dateTimeToString, errLevel, message);
                this.logger.Log(error);

                input = Console.ReadLine();
            }

            Console.WriteLine("Logger info:");

            foreach (IAppender appender in this.logger.Appenders)
            {
                Console.WriteLine(appender);
            }
        }
    }
}