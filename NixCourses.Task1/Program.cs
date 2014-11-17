using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NixCourses.Task1.Types;
using NixCourses.Task1.Parsers;

namespace NixCourses.Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1:");
            string incorrectExpression = "(((QWRaarx(6.AS0+7)*8.1-4)XXX/3ASD.2+1^3asdasd";
            //Console.WriteLine(ExpressionParser.GetCorrectExpression(incorrectExpression));
            string fixedExpressionRPN = ExpressionParser.GetReversePolishNotation(incorrectExpression);
            LimitedDouble res = Calculator.Counting(fixedExpressionRPN);
            Console.WriteLine(incorrectExpression);
            Console.WriteLine(fixedExpressionRPN);
            Console.WriteLine(res);

            Console.WriteLine("2:");
            string expression = "((6.0+7)*8.1-4)/3.2+1^3";
            string rpn = ExpressionParser.GetReversePolishNotation(expression);
            LimitedDouble result = Calculator.Counting(rpn);
            
            Console.WriteLine(expression);
            Console.WriteLine(rpn);
            Console.WriteLine(result);
        }
    }
}
