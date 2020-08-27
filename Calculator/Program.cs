using System;
using CalculatorLibrary;

namespace CalculatorProgram
{
    class Program
    {
        static void Main()
        {
            bool endApp = false;
            Calculator calculator = new Calculator();
            // Display the title as the C# Console Calculator App.
            Console.WriteLine("Console Calculator App in C#\r");
            Console.WriteLine("----------------------------\n");
            while (!endApp)
            {
                // Declare variables and set to empty.
                string numInput1;
                string numInput2;
                double result;

                // Ask the user to type the first number.
                Console.WriteLine("Type a number then press Enter: ");
                numInput1 = Console.ReadLine();

                // Always Clean your Inputs!
                double cleanNum1;
                while (!double.TryParse(numInput1, out cleanNum1))
                {
                    Console.Write("This is not a valid input. Please enter an integer value: ");
                    numInput1 = Console.ReadLine();
                }

                // Ask the user to type the second number.
                Console.WriteLine("Type another number and press Enter: ");
                numInput2 = Console.ReadLine();

                // Always Clean your Inputs!
                double cleanNum2;
                while (!double.TryParse(numInput2, out cleanNum2))
                {
                    Console.Write("This is not a valid input. Please enter an integer value: ");
                    numInput2 = Console.ReadLine();
                }

                // Ask the User to choose an operator.
                Console.WriteLine("Choose an operator from the following list: ");
                Console.WriteLine("\ta - Add");
                Console.WriteLine("\ts - Subtract");
                Console.WriteLine("\tm - Multiply");
                Console.WriteLine("\td - Divide");
                Console.WriteLine("Your Option?");

                string op = Console.ReadLine();

                try
                {
                    result = calculator.DoOperation(cleanNum1, cleanNum2, op);
                    if (double.IsNaN(result))
                    {
                        Console.WriteLine("This operation will result in a mathmatical error. \n");
                    } 
                    else
                    {
                        Console.WriteLine("Your Result: {0:0.##} \n", result);
                    }
                } 
                catch (Exception e)
                {
                    Console.WriteLine("Oh no! An exception has occured while trying to do the math. \n - Details: " + e.Message);
                }

                Console.WriteLine("---------------------------\n");

                // Wait for the user to respond before closing
                Console.Write("Press 'n' and Enter to close the app, or press any other key and Enter to continue: ");
                if (Console.ReadLine() == "n") endApp = true;

                Console.WriteLine("\n"); // Friendly Linespacing.
            }

            // And call to close the JSON writer before return
            calculator.Finish();
            return;
        }
    }
}