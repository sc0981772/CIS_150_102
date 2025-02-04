using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module3EmployeeClassStructure
{
   //Derived FullTimeEmployee class
    public class FullTimeEmployee : Employee
    {
        public decimal AnnualBonus { get; set; }

        public override decimal CalculatePay()
        {
            return BaseSalary + AnnualBonus;
        }

        public override string ToString()
        {
            return base.ToString() + $", Annual Bonus: {AnnualBonus:C}";
        }
    }
}
