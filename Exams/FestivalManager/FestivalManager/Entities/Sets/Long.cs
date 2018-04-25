
using System;

namespace FestivalManager.Entities.Sets
{
    public class Long : Set
    {
        public Long(string name) : base(name)
        {
            this.MaxDuration = new TimeSpan(0, 60, 0);
        }

        public override TimeSpan MaxDuration { get; protected set; }
    }
}
