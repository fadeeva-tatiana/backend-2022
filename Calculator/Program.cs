using System;
using MathematicalCalculations;

namespace CalculatorProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            bool endApp = false;
            // Отображаем заголовок как консольное калькуляторное приложение C#.
            Console.WriteLine("Console Calculator in C#\r");
            Console.WriteLine("------------------------\n");

            Calculator calculator = new Calculator();
            while (!endApp)
            {
                // Объявляем переменные и устанавливаем их пустыми.
                string number1 = string.Empty;
                string number2 = string.Empty;

                // Просим пользователя выбрать оператора.
                Console.WriteLine("Choose an operator from the following list:");
                Console.WriteLine("\tadd - Add");
                Console.WriteLine("\tsubstract - Subtract");
                Console.WriteLine("\tmultiply - Multiply");
                Console.WriteLine("\tdivide - Divide");
                Console.WriteLine("\tmod - Mod");
                Console.WriteLine("\tsinus - Sinus");
                Console.WriteLine("\tcosinus - Cosinus");
                Console.WriteLine("\ttangent - Tangent");
                Console.WriteLine("\tcotangent - Cotangent");
                Console.WriteLine("\tsqrt - Sqrt");
                Console.Write("Your option? ");

                string operation = Console.ReadLine();

                if (operation != "add")
                {
                    if (operation != "substract")
                    {
                        if (operation != "multiply")
                        {
                            if (operation != "divide")
                            {
                                if (operation != "mod")
                                {
                                    if (operation != "sinus")
                                    {
                                        if (operation != "cosinus")
                                        {
                                            if (operation != "tangent")
                                            {
                                                if (operation != "cotangent")
                                                {
                                                    if (operation != "sqrt")
                                                    {
                                                        Console.Write("ERROR! You type incorrect value, type your option: ");
                                                        operation = Console.ReadLine();
                                                        return;
                                                    }
                                                    else
                                                    {
                                                        continue;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                static void Trigonometry(string operation)
                {
                    // Просим пользователя ввести первое число.
                    Calculator calculator = new Calculator();
                    Console.Write("Type a number, and then press Enter: ");
                    double result = 0;
                    string number1 = Console.ReadLine();
                    double clearingNumber1 = 0;
                    double clearingNumber2 = 0;
                    while (!double.TryParse(number1, out clearingNumber1))
                    {
                        Console.Write("This is not valid input. Please enter an integer value: ");
                        number1 = Console.ReadLine();
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
                    // Ждем, пока пользователь ответит, прежде чем закрыть.
                    Console.Write("Press 'n' and Enter to close the app, or press any other key and Enter to continue: ");
                }

                if (operation == "sqrt")
                {
                    Trigonometry(operation);
                    if (Console.ReadLine() == "n") endApp = true;
                    Console.WriteLine("\n");
                    calculator.Finish();
                    return;
                }

                if (operation == "sinus")
                {
                    Trigonometry(operation);
                    if (Console.ReadLine() == "n") endApp = true;
                    Console.WriteLine("\n");
                    calculator.Finish();
                    return;
                }

                if (operation == "cosinus")
                {
                    Trigonometry(operation);
                    if (Console.ReadLine() == "n") endApp = true;
                    Console.WriteLine("\n");
                    calculator.Finish();
                    return;
                }

                if (operation == "tangent")
                {
                    Trigonometry(operation);
                    if (Console.ReadLine() == "n") endApp = true;
                    Console.WriteLine("\n");
                    calculator.Finish();
                    return;
                }

                if (operation == "cotangent")
                {
                    Trigonometry(operation);
                    if (Console.ReadLine() == "n") endApp = true;
                    Console.WriteLine("\n");
                    calculator.Finish();
                    return;
                }

                // Просим пользователя ввести и первое, и второе число.
                double result = 0;
                double clearingNumber1 = 0;
                double clearingNumber2 = 0;
                Console.Write("Type a first number, and then press Enter: ");
                number1 = Console.ReadLine();
                while (!double.TryParse(number1, out clearingNumber1))
                {
                    Console.Write("This is not valid input. Please enter an integer value: ");
                    number1 = Console.ReadLine();
                }
                Console.Write("Type a second number, then press Enter: ");
                number2 = Console.ReadLine();
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
                Console.Write("Press 'n' and Enter to close the app, or press any other key and Enter to continue: ");
                if (Console.ReadLine() == "n") endApp = true;

                Console.WriteLine("\n");
                calculator.Finish();
                return;
            }
        }
    }
}
