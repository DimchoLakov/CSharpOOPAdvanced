namespace P04.Recharge
{
    public class Employee : Worker, ISleeper
    {
        public Employee(string id, int energy) : base(id)
        {
            this.Energy = energy;
        }

        public int Energy { get; set; }

        public override void Work(int hours)
        {
            if (this.Energy < 50)
            {
                this.Sleep();
            }
            base.Work(hours);

        }

        public void Sleep()
        {
            this.Energy += 51 - this.Energy;
        }

        public override string ToString()
        {
            return base.ToString() + $" Energy: {this.Energy}";
        }
    }
}
