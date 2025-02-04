namespace Module3EmployeeClassStructure
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create an instance of each type of employee
            FullTimeEmployee fullTimeEmployee = new FullTimeEmployee
            {
                ID = 1,
                Name = "John Doe",
                Department = "Engineering",
                BaseSalary = 80000,
                AnnualBonus = 5000
            };

            PartTimeEmployee partTimeEmployee = new PartTimeEmployee
            {
                ID = 2,
                Name = "Jane Smith",
                Department = "Marketing",
                HourlyRate = 20,
                HoursWorked = 120
            };

            Contractor contractor = new Contractor
            {
                ID = 3,
                Name = "Sam Wilson",
                Department = "Consulting",
                BaseSalary = 60000,
                ContractExpiryDate = new DateTime(2025, 12, 31)
            };

            // Display information and calculate pay for each employee
            Console.WriteLine(fullTimeEmployee.ToString());
            Console.WriteLine($"Calculated Pay: {fullTimeEmployee.CalculatePay():C}");
            Console.WriteLine();

            Console.WriteLine(partTimeEmployee.ToString());
            Console.WriteLine($"Calculated Pay: {partTimeEmployee.CalculatePay():C}");
            Console.WriteLine();

            Console.WriteLine(contractor.ToString());
            Console.WriteLine($"Calculated Pay: {contractor.CalculatePay():C}");
            Console.WriteLine();
        }
    }
}
