using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyCalculator.Calculator
{
    public class Calculation
    {
        private readonly static char[] operatorSymbols = { '+', '-', '*', '/' };
        public static void GetOperatorsAndOperands(string operationText, out List<char> operators, out string[] operands)
        {
            operators = new List<char>();
            operands = operationText.Split(operatorSymbols);
            for (int i = 0; i < operationText.Length; i++)
            {
                if (operatorSymbols.Contains(operationText[i]))
                {
                    operators.Add(operationText[i]);
                }
            }
        }

        public static double GetResult(List<char> operators, string[] operands)
        {
            double result = Convert.ToDouble(operands[0]);
            for (int i = 1; i < operands.Length; i++)
            {
                double number = Convert.ToDouble(operands[i]);
                int j = i - 1;
                switch (operators[j])
                {
                    case '+':
                        result = result + number;
                        break;
                    case '-':
                        result = result - number;
                        break;
                    case '*':
                        result = result * number;
                        break;
                    case '/':
                        result = result / number;
                        break;
                    default:
                        result = 0.0;
                        break;
                }
            }

            return result;
        }
    }
}