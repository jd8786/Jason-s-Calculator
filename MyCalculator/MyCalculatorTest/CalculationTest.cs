using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyCalculator.Calculator;
using System.Collections.Generic;

namespace MyCalculatorTest
{
    [TestClass]
    public class CalculationTest
    {
        List<char> operators;
        string[] operands;

        [TestMethod]
        public void CanDoAddition()
        {
            string operationText = "3+4";
            var result = DoOperation(operationText);
            Assert.AreEqual(7, result);
        }

        [TestMethod]
        public void CanDoSubstraction()
        {
            string operationText = "7-9";
            var result = DoOperation(operationText);
            Assert.AreEqual(-2, result);
        }

        [TestMethod]
        public void CanDoMultiplication()
        {
            string operationText = "12*9";
            var result = DoOperation(operationText);
            Assert.AreEqual(108, result);
        }

        [TestMethod]
        public void CanDoDivision()
        {
            string operationText = "99/3";
            var result = DoOperation(operationText);
            Assert.AreEqual(33, result);
        }

        [TestMethod]
        public void CanDoChainOperation()
        {
            string operationText = "8+6-11*2/3";
            double result = DoOperation(operationText);
            Assert.AreEqual(6.66666666666667, result);
        }

        [TestMethod]
        public void CanDoDecimalWholeNumberOperation()
        {
            string operationText = "11.2+3";
            double result = DoOperation(operationText);
            Assert.AreEqual(14.2, result);
        }

        [TestMethod]
        public void CanDoDecimalDecimalNumberOperation()
        {
            string operationText = "0.5/0.2";
            double result = DoOperation(operationText);
            Assert.AreEqual(2.5, result);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void ExceptionShouldThrowWhenUserEnteredNothing()
        {
            var result = DoOperation("");
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void ExceptionShouldThrowWhenOnlyOperatorApplied()
        {
            var result = DoOperation("/");
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void ExceptionShouldThrowWhenOperatorInTheEnd()
        {
            var result = DoOperation("3*");
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void ExceptionShouldThrowWhenNoFirstOperand()
        {
            var result = DoOperation("+78");
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void ExceptionShouldThrowWhenMultipleDecimalInAnOperand()
        {
            var result = DoOperation("12.3.1+2");
        }

        private double DoOperation(string operationText)
        {
            Calculation.GetOperatorsAndOperands(operationText, out operators, out operands);
            var result = Calculation.GetResult(operators, operands);
            return result;
        }
    }
}
