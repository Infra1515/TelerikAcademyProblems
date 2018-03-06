using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestingExercises;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestingExercises.Tests
{
    [TestClass()]
    public class CalculatorTests
    {
        [TestMethod()]
        public void SumAllElementsTest()
        {
            // Arrange
            var list = new List<int> { 1, 2, 3, 4 };
            // Act
            var sum = Calculator.RecursionSum(list);
            //Assert
            Assert.AreEqual(5, 5);

        }

        [TestMethod()]
        public void Division_Should_Throw_When_Divisor_Is_ZeroTest()
        {
            Assert.ThrowsException<DivideByZeroException>(() => Calculator.Division(30, 0));
        }

        [TestMethod()]
        public void Division_Should_Return_CorrectTest()
        {
            var a = 10;
            var b = 5;
            var result = a / b;
            Assert.AreEqual(2, result);
        }

    }
}