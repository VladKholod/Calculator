using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NixCourses.Task1.Parsers;
using NixCourses.Task1.Types;

namespace NixCourses.Task1
{
    public sealed class Calculator
    {
        public static LimitedDouble Counting(string rpnExpression)
        {
            string[] expression = rpnExpression.Split(' ');
            var numbersStack = new Stack<LimitedDouble>();

            LimitedDouble result = 0;
            LimitedDouble firstNumber;
            LimitedDouble secondNumber;

            for (int i = 0; i < expression.Length; i++)
            {
                if (ExpressionParser.IsOperator(expression[i][0]))
                {
                    secondNumber = numbersStack.Pop();
                    firstNumber = numbersStack.Pop();

                    result = Counting(firstNumber, secondNumber, expression[i][0]);
                    numbersStack.Push(result);
                }
                else
                {
                    LimitedDouble tempNumber = Double.Parse(expression[i]);
                    numbersStack.Push(tempNumber);
                }
            }

            return numbersStack.Pop();
        }

        private static LimitedDouble Counting(LimitedDouble firstNumber, LimitedDouble secondNumber, char operation)
        {
            LimitedDouble result = 0;

            if (operation == '+')
            {
                result = firstNumber + secondNumber;
            }
            else if (operation == '-')
            {
                result = firstNumber - secondNumber;
            }
            else if (operation == '*')
            {
                result = firstNumber * secondNumber;
            }
            else if (operation == '/')
            {
                result = firstNumber / secondNumber;
            }
            else if (operation == '^')
            {
                result = firstNumber ^ secondNumber;
            }
            else
                throw new ArgumentException("Invalid operator!");

            return result;
        }
    }
}
