using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module3EmployeeClassStructure
{
    //Derived PartTimeEmployee class
    public class PartTimeEmployee : Employee
    {
        public decimal HourlyRate { get; set; }
        public int HoursWorked { get; set; }

        public override decimal CalculatePay()
        {
            return HourlyRate * HoursWorked;
        }

        public override string ToString()
        {
            return base.ToString() + $", Hourly Rate: {HourlyRate:C}, Hours Worked: {HoursWorked}";
        }
    }
}
