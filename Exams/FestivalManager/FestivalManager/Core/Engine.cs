
using System;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using FestivalManager.Core.Controllers;
using FestivalManager.Entities;
using FestivalManager.Entities.Contracts;

namespace FestivalManager.Core
{
    using Contracts;
    using Controllers.Contracts;
    using IO.Contracts;

    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;

        private IFestivalController festivalCоntroller;
        private ISetController setCоntroller;

        public Engine(IFestivalController festivalController, ISetController setController, IReader reader, IWriter writer)
        {
            this.festivalCоntroller = festivalController;
            this.setCоntroller = setController;
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            string input = this.reader.ReadLine();

            while (input != "END")
            {
                try
                {
                    string result = this.ProcessCommand(input);
                    this.writer.WriteLine(result);
                }
                catch (Exception ex)
                {
                    this.writer.WriteLine("ERROR: " + ex.Message);
                }

                input = this.reader.ReadLine();
            }

            string end = this.ProduceReport();

            this.writer.WriteLine("Results:");
            this.writer.WriteLine(end);
        }

        private string ProduceReport()
        {
            StringBuilder sb = new StringBuilder();
            var festController = (FestivalController)this.festivalCоntroller;

            FieldInfo stageInfo = typeof(FestivalController).GetFields(BindingFlags.Instance | BindingFlags.NonPublic).First(t => t.Name == "stage");

            var currentStage = (Stage)stageInfo.GetValue(festController);

            TimeSpan totalTimeSpan = default(TimeSpan);

            foreach (ISet currentStageSet in currentStage.Sets)
            {
                totalTimeSpan += currentStageSet.ActualDuration;
            }

            int minutes = (int)totalTimeSpan.TotalSeconds / 60;
            int seconds = (int) totalTimeSpan.TotalSeconds % 60;

            sb.AppendLine($"Festival length: {minutes:00}:{seconds:00}");

            var allSets = currentStage.Sets;

            foreach (ISet currentSet in allSets)
            {
                sb.AppendLine(currentSet.ToString());

                if (currentSet.Songs.Count == 0)
                {
                    sb.AppendLine($"--No songs played");
                }
                else
                {
                    sb.AppendLine($"--Songs played:");
                    foreach (var song in currentSet.Songs)
                    {
                        sb.AppendLine("----" + song);
                    }
                }
            }

            return sb.ToString().Trim();
        }

        public string ProcessCommand(string input)
        {
            var tokens = input.Split();

            var command = tokens[0];
            var parameters = tokens.Skip(1).ToArray();

            string result = string.Empty;

            switch (command)
            {
                case "RegisterSet":
                    result = this.festivalCоntroller.RegisterSet(parameters);
                    break;
                case "SignUpPerformer":
                    result = this.festivalCоntroller.SignUpPerformer(parameters);
                    break;
                case "RegisterSong":
                    result = this.festivalCоntroller.RegisterSong(parameters);
                    break;
                case "AddSongToSet":
                    result = this.festivalCоntroller.AddSongToSet(parameters);
                    break;
                case "AddPerformerToSet":
                    result = this.festivalCоntroller.AddPerformerToSet(parameters);
                    break;
                case "RepairInstruments":
                    result = this.festivalCоntroller.RepairInstruments(parameters);
                    break;
                case "LetsRock":
                    result = this.setCоntroller.PerformSets();
                    break;
            }

            return result;
        }
    }
}