using System;
using System.Diagnostics.Contracts;
using Module3EmployeeClassStructure;
using NUnit.Framework;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
namespace Module3TestForEmployeeManagement
{
    [TestClass]
    public sealed class EmployeeTests
    {
        // FullTimeEmployee Tests
        [Test]
        public void CalculatePay_ShouldReturnBaseSalaryPlusAnnualBonus()
        {
            var employee = new FullTimeEmployee
            {
                BaseSalary = 80000,
                AnnualBonus = 5000
            };

            decimal expectedPay = 85000;
            decimal actualPay = employee.CalculatePay();

            Assert.AreEqual(expectedPay, actualPay);
        }

        [Test]
        public void CalculatePay_ShouldReturnOnlyBaseSalary_WhenAnnualBonusIsZero()
        {
            var employee = new FullTimeEmployee
            {
                BaseSalary = 80000,
                AnnualBonus = 0
            };

            decimal expectedPay = 80000;
            decimal actualPay = employee.CalculatePay();

            Assert.AreEqual(expectedPay, actualPay);
        }

        // PartTimeEmployee Tests
        [Test]
        public void CalculatePay_ShouldReturnCorrectAmount_WhenGivenHourlyRateAndHours()
        {
            var employee = new PartTimeEmployee
            {
                HourlyRate = 20,
                HoursWorked = 120
            };

            decimal expectedPay = 2400;
            decimal actualPay = employee.CalculatePay();

            Assert.AreEqual(expectedPay, actualPay);
        }

        [Test]
        public void CalculatePay_ShouldReturnZero_WhenHoursWorkedIsZero()
        {
            var employee = new PartTimeEmployee
            {
                HourlyRate = 20,
                HoursWorked = 0
            };

            decimal expectedPay = 0;
            decimal actualPay = employee.CalculatePay();

            Assert.AreEqual(expectedPay, actualPay);
        }

        // Contractor Tests
        [Test]
        public void CalculatePay_ShouldReturnCorrectAmountForContractor()
        {
            var employee = new Contractor
            {
                BaseSalary = 60000
            };

            decimal expectedPay = 60000;
            decimal actualPay = employee.CalculatePay();

            Assert.AreEqual(expectedPay, actualPay);
        }

        [Test]
        public void CalculatePay_ShouldHandleNegativeValuesGracefully()
        {
            var employee = new Contractor
            {
                BaseSalary = -1000
            };

            decimal expectedPay = -1000;
            decimal actualPay = employee.CalculatePay();

            Assert.AreEqual(expectedPay, actualPay);
        }

        // ToString Method Tests
        [Test]
        public void ToString_ShouldReturnCorrectFormat()
        {
            var employee = new Employee
            {
                ID = 1,
                Name = "John Doe",
                Department = "Engineering",
                BaseSalary = 80000
            };

            string expectedString = "ID: 1, Name: John Doe, Department: Engineering, Base Salary: $80,000.00";
            string actualString = employee.ToString();

            Assert.AreEqual(expectedString, actualString);
        }

        [Test]
        public void ToString_ShouldIncludeAnnualBonus()
        {
            var employee = new FullTimeEmployee
            {
                ID = 1,
                Name = "John Doe",
                Department = "Engineering",
                BaseSalary = 80000,
                AnnualBonus = 5000
            };

            string expectedString = "ID: 1, Name: John Doe, Department: Engineering, Base Salary: $80,000.00, Annual Bonus: $5,000.00";
            string actualString = employee.ToString();

            Assert.AreEqual(expectedString, actualString);
        }

        [Test]
        public void ToString_ShouldIncludeHourlyRateAndHoursWorked()
        {
            var employee = new PartTimeEmployee
            {
                ID = 2,
                Name = "Jane Smith",
                Department = "Marketing",
                HourlyRate = 20,
                HoursWorked = 120
            };

            string expectedString = "ID: 2, Name: Jane Smith, Department: Marketing, Base Salary: $0.00, Hourly Rate: $20.00, Hours Worked: 120";
            string actualString = employee.ToString();

            Assert.AreEqual(expectedString, actualString);
        }

        [Test]
        public void ToString_ShouldIncludeContractExpiryDate()
        {
            var employee = new Contractor
            {
                ID = 3,
                Name = "Sam Wilson",
                Department = "Consulting",
                BaseSalary = 60000,
                ContractExpiryDate = new DateTime(2025, 12, 31)
            };

            string expectedString = "ID: 3, Name: Sam Wilson, Department: Consulting, Base Salary: $60,000.00, Contract Expiry Date: 12/31/2025";
            string actualString = employee.ToString();

            Assert.AreEqual(expectedString, actualString);
        }
    }
}
