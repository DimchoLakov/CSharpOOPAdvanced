using FestivalManager.Entities;
using FestivalManager.Entities.Factories;
using FestivalManager.Entities.Factories.Contracts;

namespace FestivalManager.Core.Controllers
{
    using System;
    using System.Globalization;
    using System.Linq;
    using Contracts;
    using Entities.Contracts;

    public class FestivalController : IFestivalController
    {
        private const string TimeFormat = "mm\\:ss";

        private ISetFactory setFactory;
        private IInstrumentFactory instrumentFactory;
        private readonly IStage stage;

        public FestivalController(IStage stage)
        {
            this.stage = stage;
            this.setFactory = new SetFactory();
            this.instrumentFactory = new InstrumentFactory();
        }

        public string ProduceReport()
        {
            var instance = (SetController)Activator.CreateInstance(typeof(SetController), new object[] { this.stage });

            var result = instance.PerformSets();

            return result;
        }

        public string RegisterSet(string[] args)
        {
            string name = args[0];
            string type = args[1];
            this.stage.AddSet(this.setFactory.CreateSet(name, type));

            return $"Registered {type} set";
        }

        public string SignUpPerformer(string[] args)
        {
            string name = args[0];
            int age = int.Parse(args[1]);
            var instruments = args.Skip(2).ToArray();
            

            IPerformer performer = new Performer(name, age);

            foreach (string instrument in instruments)
            {
                performer.AddInstrument(this.instrumentFactory.CreateInstrument(instrument));
            }

            this.stage.AddPerformer(performer);

            return $"Registered performer {performer.Name}";
        }

        public string RegisterSong(string[] args)
        {
            string name = args[0];
            TimeSpan duration = TimeSpan.ParseExact(args[1], TimeFormat, CultureInfo.InvariantCulture);

            ISong song = new Song(name, duration);

            this.stage.AddSong(song);

            return $"Registered song {song.Name} ({song.Duration.ToString(TimeFormat)})";
        }

        public string AddSongToSet(string[] args)
        {
            string songName = args[0];
            string setName = args[1];

            if (!this.stage.HasSet(setName))
            {
                throw new InvalidOperationException("Invalid set provided");
            }

            if (!this.stage.HasSong(songName))
            {
                throw new InvalidOperationException("Invalid song provided");
            }

            ISet set = this.stage.Sets.First(s => s.Name == setName);
            ISong song = this.stage.Songs.First(s => s.Name == songName);

            set.AddSong(song);

            return $"Added {song.Name} ({song.Duration.ToString(TimeFormat)}) to {set.Name}";
        }

        public string AddPerformerToSet(string[] args)
        {
            string performerName = args[0];
            string setName = args[1];

            if (!this.stage.HasPerformer(performerName))
            {
                throw new InvalidOperationException("Invalid performer provided");
            }

            if (!this.stage.HasSet(setName))
            {
                throw new InvalidOperationException("Invalid set provided");
            }

            IPerformer performer = this.stage.Performers.First(p => p.Name == performerName);
            ISet set = this.stage.Sets.First(s => s.Name == setName);

            set.AddPerformer(performer);

            return $"Added {performer.Name} to {set.Name}";
        }

        public string RepairInstruments(string[] args)
        {
            int repairedInstrumentsCount = 0;
            foreach (var stagePerformer in this.stage.Performers)
            {
                foreach (var instrument in stagePerformer.Instruments.Where(i => i.Wear < 100))
                {
                    instrument.Repair();
                    repairedInstrumentsCount++;
                }
            }
            return $"Repaired {repairedInstrumentsCount} instruments";
        }

        private TimeSpan GetTotalDuration()
        {
            TimeSpan total = new TimeSpan();
            foreach (ISet stageSet in this.stage.Sets)
            {
                total += stageSet.ActualDuration;
            }

            return total;
        }
    }
}