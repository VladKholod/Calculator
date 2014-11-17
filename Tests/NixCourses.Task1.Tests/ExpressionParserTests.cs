using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using NixCourses.Task1.Parsers;

namespace NixCourses.Task1.Tests
{
    [TestClass]
    public class ExpressionParserTests
    {
        [TestMethod]
        public void SymbolIsOperatorPlus_WhenOperatorIsPlus_ShouldReturnTrue()
        {
            //arrange
            char operation = '+';
            bool expected = true;
            
            //act

            bool result = ExpressionParser.IsOperator(operation);

            //assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void SymbolIsOperator_WhenOperatorIsClosingBracket_ShouldReturnTrue()
        {
            //arrange
            char operation = ')';
            bool expected = true;

            //act

            bool result = ExpressionParser.IsOperator(operation);

            //assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void SymbolIsOperator_WhenOperatorIsDollarSign_ShouldReturnFalse()
        {
            //arrange
            char operation = '$';
            bool expected = false;

            //act

            bool result = ExpressionParser.IsOperator(operation);

            //assert
            Assert.AreEqual(expected, result);
        }


        [TestMethod]
        public void GetReversePolishNotation_WhenUsingCorrectExpression_ShouldReturnRPN()
        {
            //arrange
            string expression = "((6.0+7)*8.1-4)/3.2+1^3";
            string expected = "6.0 7 + 8.1 * 4 - 3.2 / 1 3 ^ +";

            //act

            string result = ExpressionParser.GetReversePolishNotation(expression);

            //assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void GetReversePolishNotation_WhenUsingIncorrectExpression_ShouldReturnInvalidRPN()
        {
            //arrange
            string expression = "6+7";
            string expected = "8 5 +";

            //act

            string result = ExpressionParser.GetReversePolishNotation(expression);

            //assert
            Assert.AreNotEqual(expected, result);
        }

        [TestMethod]
        public void GetCorrectExpression_ExpressionConstrainsLetters_ShouldReturnCorrectExpression()
        {
            //arrange
            string expression = "(ax8a+9)z*Q3xz";
            string expected = "(8+9)*3";

            //act

            string result = ExpressionParser.GetCorrectExpression(expression);

            //assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void GetCorrectExpression_ExpressionConstrainsNotAllClosingBrackets_ShouldReturnCorrectExpression()
        {
            //arrange
            string expression = "(((8+9)*3";
            string expected = "(((8+9)*3))";

            //act

            string result = ExpressionParser.GetCorrectExpression(expression);

            //assert
            Assert.AreEqual(expected, result);
        }
    }
}
