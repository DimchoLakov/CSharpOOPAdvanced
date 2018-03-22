using System;
using System.Collections.Generic;

namespace P04.Recharge
{
    public class StartUp
    {
        public static void Main()
        {
            var employee = new Employee("1", 100);
            var robot = new Robot("2", 10);

            IList<Worker> workers = new List<Worker>()
            {
                employee,
                robot
            };

            foreach (Worker worker in workers)
            {
                Console.WriteLine(worker);
            }
        }
    }
}
