using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FestivalManager.Entities.Contracts;

namespace FestivalManager.Entities.Sets
{
    public abstract class Set : ISet
    {
        private List<IPerformer> performers;
        private List<ISong> songs;

        protected Set(string name)
        {
            this.Name = name;
            this.performers = new List<IPerformer>();
            this.songs = new List<ISong>();
        }

        public string Name { get; protected set; }
        public virtual TimeSpan MaxDuration { get; protected set; }
        public TimeSpan ActualDuration => GetActualDuration();

        private TimeSpan GetActualDuration()
        {
            TimeSpan timeSpan = new TimeSpan();
            foreach (ISong song in this.Songs)
            {
                timeSpan += song.Duration;
            }

            return timeSpan;
        }

        public IReadOnlyCollection<IPerformer> Performers => this.performers.AsReadOnly();
        public IReadOnlyCollection<ISong> Songs => this.songs.AsReadOnly();
        public void AddPerformer(IPerformer performer)
        {
            this.performers.Add(performer);
        }

        public void AddSong(ISong song)
        {
            if (song.Duration + this.ActualDuration > this.MaxDuration)
            {
                throw new InvalidOperationException("Song is over the set limit!");
            }

            this.songs.Add(song);
        }

        public bool CanPerform()
        {
            if (this.performers.Count > 0 && this.songs.Count > 0)
            {
                if (this.performers.All(p => p.Instruments.Count > 0 && p.Instruments.Any(i => !i.IsBroken)))
                {
                    return true;
                    //if (this.performers.All(p => !p.Instruments.Any(i => i.IsBroken)))
                    //{
                    //    return true;
                    //}
                }
            }

            return false;
        }
        
        public override string ToString()
        {
            var sb = new StringBuilder();

            var temp = this.ActualDuration.TotalSeconds;
            int minutes = (int)temp / 60;
            int seconds = (int)temp % 60;

            sb.AppendLine($"--{this.Name} ({minutes:00}:{seconds:00}):");

            var sortedPerformers = this.Performers.OrderByDescending(p => p.Age);

            foreach (var performer in sortedPerformers)
            {
                var sortedInstruments = performer.Instruments.OrderByDescending(i => i.Wear);

                sb.AppendLine($"---{performer.Name} ({string.Join(", ", sortedInstruments)})");
            }
            
            return sb.ToString().Trim();
        }
    }
}
