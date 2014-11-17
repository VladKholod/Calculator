using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using NixCourses.Task1;
using NixCourses.Task1.Types;
namespace NixCourses.Task1.Tests
{
    [TestClass]
    public class CalculatorTests
    {
        [TestMethod]
        public void CountingRPN_WithValidRPNExpression_5()
        {
            // arrange
            string rpnExpression = "4 1 +";
            LimitedDouble expected = 5;

            // act
            LimitedDouble result = Calculator.Counting(rpnExpression);

            // assert
             Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void CountingRPN_WithValidRPNExpression_SameAsExpected()
        {
            // arrange
            string rpnExpression = "6.0 7 + 8.1 * 4 - 3.2 / 1 3 ^ +";
            LimitedDouble expected = 5.78125;

            // act
            LimitedDouble result = Calculator.Counting(rpnExpression);

            // assert
            Assert.AreEqual(expected, result,0.00001,string.Format("{0} - {1}",expected,result));
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void CountingRPN_WithInalidRPNExpression_ThrowExpectedException()
        {
            // arrange
            string rpnExpression = "6.0 7 + 8.1 * 4 - 3.2 / 1 3 ^ + + +";
            LimitedDouble expected = 5.78125;

            // act
            LimitedDouble result = Calculator.Counting(rpnExpression);

            // assert of throwing InvalidOperationException
        }
    }
}
