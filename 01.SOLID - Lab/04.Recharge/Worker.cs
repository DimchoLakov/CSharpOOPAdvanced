namespace P04.Recharge
{
    public abstract class Worker
    {
        private string id;
        private int workingHours;

        protected Worker(string id)
        {
            this.id = id;
        }

        public virtual void Work(int hours)
        {
            this.workingHours += hours;
        }

        public override string ToString()
        {
            return $"Type: {this.GetType().Name}, ID: {this.id}, Working Hours: {this.workingHours}h";
        }
    }
}