namespace FestivalManager.Entities.Sets
{
	using System;

    public class Medium : Set
    {
        public Medium(string name) : base(name)
        {
            this.MaxDuration = new TimeSpan(0, 40, 0);
        }

        public override TimeSpan MaxDuration { get; protected set; }
    }
}