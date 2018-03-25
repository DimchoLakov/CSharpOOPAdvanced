using System;
using System.Collections.Generic;
using System.IO;
using Logger.Interfaces;

namespace Logger.Models
{
    public class LogFile : ILogFile
    {
        private const string DefaultPath = "./data/";
        public LogFile(string fileName)
        {
            this.Path = DefaultPath + fileName;
            IntializeFile();
            this.Size = 0;
        }

        private void IntializeFile()
        {
            Directory.CreateDirectory(DefaultPath);
            File.AppendAllText(this.Path, "");
        }

        public string Path { get; }
        public int Size { get; private set; }
        public void WriteToFile(string errorLog)
        {
            File.AppendAllText(this.Path, errorLog + Environment.NewLine);

            int addedSize = 0;

            foreach (char c in errorLog)
            {
                addedSize += c;
            }

            this.Size += addedSize;
        }
    }
}
