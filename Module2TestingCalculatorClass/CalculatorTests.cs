using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Module2TestingCalculatorClass
{
    [TestClass]
    public class CalculatorTests
    {
        private Calculator _calculator;

        [TestInitialize]
        public void Setup()
        {
            _calculator = new Calculator();
        }

        //add Method tests
        [TestMethod]
        public void Add_ShouldReturnSum_WhenGivenTwoPositiveNumbers()
        {
            var result = _calculator.Add(5, 7);
            Assert.AreEqual(12, result);
        }

        [TestMethod]
        public void Add_ShouldReturnSum_WhenGivenNegativeAndPositiveNumber()
        {
            var result = _calculator.Add(-3, 7);
            Assert.AreEqual(4, result);
        }

        // Subtract method tests
        [TestMethod]
        public void Subtract_ShouldReturnDifference_WhenGivenTwoPositiveNumbers()
        {
            var result = _calculator.Subtract(7, 5);
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void Subtract_ShouldReturnDifference_WhenResultIsNegative()
        {
            var result = _calculator.Subtract(5, 7);
            Assert.AreEqual(-2, result);
        }

        //Multiply method tests
        [TestMethod]
        public void Multiply_ShouldReturnProduct_WhenGivenTwoPositiveNumbers()
        {
            var result = _calculator.Multiply(3, 4);
            Assert.AreEqual(12, result);
        }

        [TestMethod]
        public void Multiply_ShouldReturnProduct_WhenGivenNegativeAndPositiveNumber()
        {
            var result = _calculator.Multiply(-3, 4);
            Assert.AreEqual(-12, result);
        }

        //Divide method tests
        [TestMethod]
        public void Divide_ShouldReturnQuotient_WhenGivenTwoPositiveNumbers()
        {
            var result = _calculator.Divide(8, 4);
            Assert.AreEqual(2.0, result);
        }

        [TestMethod]
        public void Divide_ShouldThrowArgumentException_WhenDividingByZero()
        {
            Assert.ThrowsException<ArgumentException>(() => _calculator.Divide(8, 0));
        }

        [TestMethod]
        public void Divide_ShouldReturnQuotient_WhenResultIsNegative()
        {
            var result = _calculator.Divide(-8, 4);
            Assert.AreEqual(-2.0, result);
        }

        [TestMethod]
        public void Divide_ShouldReturnQuotient_WhenGivenNegativeDividendAndDivisor()
        {
            var result = _calculator.Divide(-8, -4);
            Assert.AreEqual(2.0, result);
        }
    }
}
