using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ValidateAnExpression
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the expression validating program.");

            //getting expression string form user input
            string userInput;

            do
            {
                Console.WriteLine("Enter your expression:");
                userInput = Console.ReadLine();
            } while (string.IsNullOrEmpty(userInput));
            
            //converting string expression to array of characters for further iterations
            char[] expression = userInput.ToCharArray();

            //getting start and end symbols from user input
            string openingCharInput;
            string closingCharInput;
            

            //setting a string of allowed characters for this task
            string allowed = "{}[]<>\\/()\"'$%&*@!~`:;|#";

            do
            {
                do
                {
                    Console.WriteLine("Enter the opening character to validate: ");
                    openingCharInput = (Console.ReadLine());
                    //openingChar = Console.ReadKey().KeyChar;
                   // val = Char.TryParse(Console.ReadLine(), out chr);
                } while (string.IsNullOrEmpty(openingCharInput));
                //second do..while here because expression below throw error on empty entry other ways
                if(allowed.Contains(openingCharInput[0]) == false)
                {
                    Console.WriteLine("Character entered is not in aloowed range. Please enter different one.");
                    openingCharInput = null;
                }
                
            } while (string.IsNullOrEmpty(openingCharInput));

            do
            {
                do
                {
                    Console.WriteLine("Enter the closing character to validate: ");
                    closingCharInput = (Console.ReadLine());
                } while (string.IsNullOrEmpty(closingCharInput));
                if (allowed.Contains(closingCharInput[0]) == false)
                {
                    Console.WriteLine("Character entered is not in aloowed range. Please enter different one.");
                    closingCharInput = null;
                }
            } while (string.IsNullOrEmpty(closingCharInput));


            char openingChar = openingCharInput[0];
            char closingChar = closingCharInput[0];
            bool expressionStatus = true;
            bool openingCharIsPresent = false;
            bool closingCharIsPresent = false;

            /*validating expression for opening and closing characters
              also lets check if both opening and closing characters are present */

            Stack<char> bracketsContainer = new Stack<char>();

            

            foreach (char character in expression)
            {
                if (character == openingChar)
                {
                    openingCharIsPresent = true;
                   bracketsContainer.Push(openingChar);
                }
                else if (character == closingChar)
                {
                    closingCharIsPresent = true;
                    try
                    {
                        bracketsContainer.Pop();
                    }
                    catch
                    {
                        expressionStatus = false;
                        break;
                    }
                }
            }

            
            //cheking and printing iteration results
            if (expressionStatus == false)
            {
                Console.WriteLine("The expression is not correct");
            }
            else if (openingCharIsPresent == false || closingCharIsPresent == false)
            {
                Console.WriteLine("The expression is not correct. Opening and/or closing character(s) are missing.");
            }
            else if (bracketsContainer.Count == 0)
            {
                Console.WriteLine("The expression is correct");
            }
            else
            {
                Console.WriteLine("The expression is not correct");
            }
        }
    }
}
