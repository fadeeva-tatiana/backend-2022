using System;
using MathematicalCalculations;

namespace CalculatorProgram
{

    class Program
    {
        static void Main(string[] args)
        {
            bool endApp = false;

            Console.WriteLine("Console Calculator in C#\r");
            Console.WriteLine("------------------------\n");

            Calculator calculator = new Calculator();
            while (!endApp)
            {

                string number1 = string.Empty;
                string number2 = string.Empty;
                double result = 0;

                Console.Write("Type a number, and then press Enter: ");
                number1 = Console.ReadLine();

                double clearingNumber1 = 0;
                while (!double.TryParse(number1, out clearingNumber1))
                {
                    Console.Write("This is not valid input. Please enter an integer value: ");
                    number1 = Console.ReadLine();
                }

                Console.WriteLine("Choose an operator from the following list:");
                Console.WriteLine("\tadd - Add");
                Console.WriteLine("\tsubstract - Subtract");
                Console.WriteLine("\tmultiply - Multiply");
                Console.WriteLine("\tdivide - Divide");
                Console.WriteLine("\tmod - %");
                Console.Write("Your option? ");

                string operation = Console.ReadLine();

                Console.Write("Type another number, and then press Enter: ");
                number2 = Console.ReadLine();
                double clearingNumber2 = 0;

                while (!double.TryParse(number2, out clearingNumber2))
                {
                    Console.Write("This is not valid input. Please enter an integer value: ");
                    number2 = Console.ReadLine();
                }

                try
                {
                    result = calculator.DoOperation(clearingNumber1, clearingNumber2, operation);
                    if (double.IsNaN(result))
                    {
                        Console.WriteLine("This operation will result in a mathematical error.\n");
                    }
                    else Console.WriteLine("Your result: {0:0.##}\n", result);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Oh no! An exception occurred trying to do the math.\n - Details: " + e.Message);
                }

                Console.WriteLine("------------------------\n");

                Console.Write("Press 'n' and Enter to close the app, or press any other key and Enter to continue: ");
                if (Console.ReadLine() == "n") endApp = true;

                Console.WriteLine("\n");
            }
            calculator.Finish();
            return;
        }
    }
}
