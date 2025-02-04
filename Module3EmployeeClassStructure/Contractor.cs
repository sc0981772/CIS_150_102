using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module3EmployeeClassStructure
{
    //Derived Contractor class
    public class Contractor : Employee
    {
        public DateTime ContractExpiryDate { get; set; }

        public override decimal CalculatePay()
        {
            // Assuming contractors have a fixed pay structure
            return BaseSalary;
        }

        public override string ToString()
        {
            return base.ToString() + $", Contract Expiry Date: {ContractExpiryDate:d}";
        }
    }
}
