using System;
using System.Collections.Generic;

namespace P03.DetailPrinter
{
    public class StartUp
    {
        public static void Main()
        {
            var firstEmployee = new Employee("Pesho");
            var secondEmployee = new Employee("Gosho");
            var firstManager = new Manager("Ivan", new List<string>()
            {
                "First Document",
                "Second Document",
                "Third Document"
            });

            var secondManager = new Manager("Georgi", new List<string>()
            {
                "Fourth Document",
                "Fifth Document",
                "Sixth Document"
            });

            IList<Employee> employees = new List<Employee>
            {
                firstEmployee,
                secondEmployee,
                firstManager,
                secondManager
            };

            foreach (Employee employee in employees)
            {
                Console.WriteLine(employee);
            }
        }
    }
}
