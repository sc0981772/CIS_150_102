using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module3EmployeeClassStructure
{
    // Base Employee class
    public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public decimal BaseSalary { get; set; }

        public virtual decimal CalculatePay()
        {
            return BaseSalary;
        }

        public override string ToString()
        {
            return $"ID: {ID}, Name: {Name}, Department: {Department}, Base Salary: {BaseSalary:C}";
        }
    }
}
