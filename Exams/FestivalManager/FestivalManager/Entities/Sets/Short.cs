namespace FestivalManager.Entities.Sets
{
	using System;

    public class Short : Set
    {
        public Short(string name) : base(name)
        {
            this.MaxDuration = new TimeSpan(0, 15, 0);
        }

        public override TimeSpan MaxDuration { get; protected set; }
    }
}