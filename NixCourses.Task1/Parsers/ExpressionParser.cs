using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace NixCourses.Task1.Parsers
{
    public class ExpressionParser
    {
        private static readonly string operators = "()+-*/^";

        public static bool IsOperator(char character) 
        {
            if (operators.IndexOf(character) != -1) 
            {
                return true;
            }
            return false;
        }

        private static int GetPriority(char character) 
        {
            return operators.IndexOf(character);
        }

        public static string GetReversePolishNotation(string input) 
        {
            input = GetCorrectExpression(input);
            FixAmountOfBrackets(ref input);
            Stack<char> operatorsStack = new Stack<char>();
            string expression = string.Empty;
            for (int i = 0; i < input.Length;i++ )
            {
                if (IsOperator(input[i]))
                {
                    if (input[i] == '(') 
                        operatorsStack.Push(input[i]);
                    else if (input[i] == ')')
                    {
                        char tempOperator = operatorsStack.Pop();
                        while (tempOperator != '(')
                        {
                            expression += tempOperator.ToString() + " ";
                            tempOperator = operatorsStack.Pop();
                        }
                    }
                    else 
                    {
                        if (operatorsStack.Count > 0) 
                            if (GetPriority(input[i]) <= GetPriority(operatorsStack.Peek())) 
                                expression += operatorsStack.Pop().ToString() + " ";
                        operatorsStack.Push(input[i]);
                    }
                }
                else
                    WorkWithNumber(input, ref expression, ref i);
            }
            while (operatorsStack.Count > 0) 
                expression += operatorsStack.Pop().ToString() + " ";
            return expression.Trim();
        }

        private static void WorkWithNumber(string input, ref string expression, ref int index) 
        {
            while (!IsOperator(input[index]))
            {
                expression += input[index];
                index++;

                if (index == input.Length)
                {
                    break;
                }
            }

            expression += " ";
            index--;
        }

        public static string GetCorrectExpression(string input) 
        {
            FixAmountOfBrackets(ref input);
            return Regex.Replace(input, @"[a-zA-Z]", "").ToString();
        }

        private static void FixAmountOfBrackets(ref string input) 
        {
            int quantityMismatchingBrackets = 0;

            foreach (char ch in input) 
            {
                if (ch == '(')
                    quantityMismatchingBrackets++;
                else if (ch == ')')
                    quantityMismatchingBrackets--;
            }

            if (quantityMismatchingBrackets > 0) 
            {
                AddClosingBrackets(ref input,quantityMismatchingBrackets);
            }
        }

        private static void AddClosingBrackets(ref string input, int quantity)
        {
            for (int i = 0; i < quantity; i++)
                input += ')';
        }
    }
}
