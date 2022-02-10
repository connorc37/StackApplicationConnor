using System;
using System.Collections.Generic;

/**************************************************************
* Name        : StackApplicationConnor
* Author      : Corey Connor
* Created     : 02/09/2022
* Course      : CIS152 21508 - Data Structures
* Version     : 1.0
* OS          : Windows 11
* Copyright   : This is my own original work based on
*               specifications issued by our instructor
* Description : Converts infix expressions to postfix.
*               Input: infix expression
*               Output: postfix results
* Academic Honesty: I attest that this is my original work.
* I have not used unauthorized source code, either modified or 
* unmodified. I have not given other fellow student(s) access to
* my program.         
***************************************************************/

namespace StackApplicationConnor
{
    internal class Program
    {
        static int GetPrecedence(char c)
        {
            // This method sets operator precedence.
            if (c == '^')
            {
                return 3;
            }
            else if (c == '*' || c == '/')
            {
                return 2;
            }
            else if (c == '+' || c == '-')
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        static string GetPostfix(string infix)
        {
            // This method converts infix expressions to postfix.

            // Declare result string & initialize a stack. 
            string result = "";
            Stack<char> postfixStack = new Stack<char>();

            // For each character in infix...
            for (int i = 0; i < infix.Length; i++)
            {
                char c = infix[i];

                // ... if the character is an operand, append it to result.      
                if (char.IsLetterOrDigit(c))
                {
                    result += c;
                }

                // ... if the character is an opening parenthesis, push it to the stack.
                else if (c == '(')
                {
                    postfixStack.Push(c);
                }

                // ... if the character is a closing parenthesis, pop operators from the stack and 
                // append them to result until an opening parenthesis is encountered or the stack is empty.
                else if (c == ')')
                {
                    while (postfixStack.Count > 0 && postfixStack.Peek() != '(') 
                    {
                        result += postfixStack.Pop();
                    }
                    postfixStack.Pop();
                }

                // ... if the character is an operator with equal or lesser presidence than the operator on the top of the
                // stack, pop operators from the stack and append them to result. Then push the current character to the stack.
                else 
                {
                    while (postfixStack.Count > 0 && GetPrecedence(c) <= GetPrecedence(postfixStack.Peek()))
                    {
                        result += postfixStack.Pop();
                    }
                    postfixStack.Push(c);
                }
            }

            // Pop all remaining operators from the stack and append them to result.
            while (postfixStack.Count > 0)
            {
                result += postfixStack.Pop();
            }

            // Return the completed postfix string.
            return result;
        }
        static void Main(string[] args)
        {
            string infix1 = "2+3*4";
            string infix2 = "a*b+5";
            string infix3 = "(1+2)*7";
            string infix4 = "a*b/c";
            string infix5 = "(a/(b-c+d))*(e-a)*c";
            string infix6 = "a/b-c+d*e-a*c";

            Console.WriteLine(GetPostfix(infix1));
            Console.WriteLine(GetPostfix(infix2));
            Console.WriteLine(GetPostfix(infix3));
            Console.WriteLine(GetPostfix(infix4));
            Console.WriteLine(GetPostfix(infix5));
            Console.WriteLine(GetPostfix(infix6));

            Console.WriteLine("Enter infix expression: ");
            string infix7 = Console.ReadLine();     // Example case: 6*4+2^5-3 should produce 64*25^+3-
            Console.WriteLine(GetPostfix(infix7));
        }
    }
}
