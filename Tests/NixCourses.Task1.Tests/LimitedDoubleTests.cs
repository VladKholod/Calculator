using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using NixCourses.Task1.Types;

namespace NixCourses.Task1.Tests
{
    [TestClass]
    public class LimitedDoubleTests
    {
        [TestMethod]
        public void OperatorPlus_CorrectValues_5()
        {
            //arrange
            LimitedDouble limitedDouble1 = 2.99;
            LimitedDouble limitedDouble2 = 2.01;
            LimitedDouble expected = 5;
            LimitedDouble result;

            //acr
            result = limitedDouble1 + limitedDouble2;

            //assert
            Assert.AreEqual(expected, result, 0.001, "Type 'LimitedDouble' summed incorrectly");
        }

        [TestMethod]
        public void OperatorPlus_IncorrectValues_9()
        {
            //arrange
            LimitedDouble limitedDouble1 = 2.99;
            LimitedDouble limitedDouble2 = 2.01;
            LimitedDouble expected = 9;
            LimitedDouble result;

            //acr
            result = limitedDouble1 + limitedDouble2;

            //assert
            Assert.AreNotEqual(expected, result, 0.001, "Type 'LimitedDouble' summed incorrectly");
        }

        //Fail test
        [TestMethod]
        public void OperatorMultiply_CorrectValues_5()
        {
            //arrange
            LimitedDouble limitedDouble1 = 2;
            LimitedDouble limitedDouble2 = 2.5;
            LimitedDouble expected = 5;
            LimitedDouble result;

            //acr
            result = limitedDouble1 * limitedDouble2;

            //assert
            Assert.AreEqual(expected, result, string.Format("Type 'LimitedDouble' multiplied incorrectly",expected,result));
        }

        [TestMethod]
        public void OperatorMultiply_IncorrectValues_5()
        {
            //arrange
            LimitedDouble limitedDouble1 = 2;
            LimitedDouble limitedDouble2 = 4;
            LimitedDouble expected = 5;
            LimitedDouble result;

            //acr
            result = limitedDouble1 * limitedDouble2;

            //assert
            Assert.AreNotEqual(expected, result, 0.001, "Type 'LimitedDouble' multiply incorrectly");
        }

        [TestMethod]
        public void OperatorDevide_CorrectValues_3()
        {
            //arrange
            LimitedDouble limitedDouble1 = 6;
            LimitedDouble limitedDouble2 = 2;
            LimitedDouble expected = 3;
            LimitedDouble result;

            //acr
            result = limitedDouble1 / limitedDouble2;

            //assert
            Assert.AreEqual(expected, result, 0.001, "Type 'LimitedDouble' devided incorrectly");
        }

        [TestMethod]
        public void OperatorPow_CorrectValues_8()
        {
            //arrange
            LimitedDouble limitedDouble1 = 2;
            LimitedDouble limitedDouble2 = 3;
            LimitedDouble expected = 8;
            LimitedDouble result;

            //acr
            result = limitedDouble1 ^ limitedDouble2;

            //assert
            Assert.AreEqual(expected, result, 0.001, "Type 'LimitedDouble' devided incorrectly");
        }

        public void OperatorPow_IncorrectValues_28()
        {
            //arrange
            LimitedDouble limitedDouble1 = 3;
            LimitedDouble limitedDouble2 = 3;
            LimitedDouble expected = 28;
            LimitedDouble result;

            //acr
            result = limitedDouble1 ^ limitedDouble2;

            //assert
            Assert.AreNotEqual(expected, result, 0.001, "Type 'LimitedDouble' devided incorrectly");
        }

        [TestMethod]
        public void OperatorDevide_IncorrectValues_7()
        {
            //arrange
            LimitedDouble limitedDouble1 = -1;
            LimitedDouble limitedDouble2 = 0.5;
            LimitedDouble expected = 7;
            LimitedDouble result;

            //acr
            result = limitedDouble1 / limitedDouble2;

            //assert
            Assert.AreNotEqual(expected, result, 0.001, "Type 'LimitedDouble' devided incorrectly");
        }

        [TestMethod]
        public void OverflowMaxValue_CorrectValues_0() 
        {
            //arrange
            LimitedDouble limitedDouble1 = 36.0;
            LimitedDouble limitedDouble2 = 7;
            LimitedDouble expected = 0;
            LimitedDouble result;

            //acr
            result = limitedDouble1 + limitedDouble2;

            //assert
            Assert.AreEqual(expected, result, 0.001, "Type 'LimitedDouble' overflow Max_Value incorrectly");
        }

        [TestMethod]
        public void OverflowMaxValue_IncorrectValues_3()
        {
            //arrange
            LimitedDouble limitedDouble1 = 36.0;
            LimitedDouble limitedDouble2 = 8;
            LimitedDouble expected = 3;
            LimitedDouble result;

            //acr
            result = limitedDouble1 + limitedDouble2;

            //assert
            Assert.AreNotEqual(result, expected, "Type 'LimitedDouble' overflow Max_Value incorrectly");
        }

        [TestMethod]
        public void OverflowMinValue_CorrectValues_36() 
        {
            //arrange
            LimitedDouble limitedDouble1 = -6.99;
            LimitedDouble limitedDouble2 = -0.03;
            LimitedDouble expected = 35.99;
            LimitedDouble result;

            //acr
            result = limitedDouble1 + limitedDouble2;

            //assert
            Assert.AreEqual(expected, result, 0.02, "Type 'LimitedDouble' overflow Min_Value incorrectly");
        }

        [TestMethod]
        public void OverflowMinValue_IncorrectValues_10()
        {
            //arrange
            LimitedDouble limitedDouble1 = -6.99;
            LimitedDouble limitedDouble2 = -0.02;
            LimitedDouble expected = 10;
            LimitedDouble result;

            //acr
            result = limitedDouble1 + limitedDouble2;

            //assert
            Assert.AreNotEqual(expected, result, 0.001, "Type 'LimitedDouble' overflow Min_Value incorrectly");
        }
    }
}
