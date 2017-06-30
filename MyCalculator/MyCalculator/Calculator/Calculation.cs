using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyCalculator.Calculator
{
    public class Calculation
    {
        private readonly static char[] addSubOperators = { '+', '-' };
        private readonly static char[] mulDivOperators = { '*', '/' };
        private readonly static char[] operators = { '+', '-', '*', '/' };
        public static void GetOperatorsAndOperands(string operationText, out List<char> operators, out string[] operands)
        {
            operationText = FormatOperationText(operationText);
            operators = new List<char>();
            operands = operationText.Split(addSubOperators);
            for (int i = 0; i < operationText.Length; i++)
            {
                if (addSubOperators.Contains(operationText[i]))
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
                    default:
                        result = 0.0;
                        break;
                }
            }

            return result;
        }

        public static string FormatOperationText(string operationText)
        {
            while (operationText.Contains(mulDivOperators[0]) || operationText.Contains(mulDivOperators[1]))
            {
                operationText = DoMulDivOperation(operationText);
            }
            return operationText;
        }

        private static string DoMulDivOperation(string operationText)
        {
            for (int i = 0; i < operationText.Length; i++)
            {
                var result = 0.0;
                var str = operationText[i];
                if (mulDivOperators.Contains(str))
                {
                    var value1Chars = new List<char>();
                    for (int j = i - 1; j >= 0; j--)
                    {
                        if (operators.Contains(operationText[j]))
                        {
                            break;
                        }
                        value1Chars.Add(operationText[j]);
                    }
                    value1Chars.Reverse();

                    var value2Chars = new List<char>();
                    for (int m = i + 1; m < operationText.Length; m++)
                    {
                        if (operators.Contains(operationText[m]))
                        {
                            break;
                        }
                        value2Chars.Add(operationText[m]);
                    }

                    var value1Double = Convert.ToDouble(string.Concat(value1Chars));
                    var value2Double = Convert.ToDouble(string.Concat(value2Chars));

                    if (str == '*')
                    {
                        result = value1Double * value2Double;
                    }
                    else
                    {
                        result = value1Double / value2Double;
                    }

                    var value1Length = value1Double.ToString().Length;
                    var value2Length = value2Double.ToString().Length;
                    operationText = operationText.Remove(i - value1Length, value1Length + value2Length + 1).Insert(i - value1Length, Convert.ToString(result));
                    return operationText;
                }
            }
            return operationText;
        }
    }
}