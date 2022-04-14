using System;
using System.IO;
using System.Diagnostics;
using Newtonsoft.Json;

namespace MathematicalCalculations
{
    public class Calculator
    {

        JsonWriter writer;

        public Calculator()
        {
            StreamWriter logFile = File.CreateText("calculatorlog.json");
            logFile.AutoFlush = true;
            writer = new JsonTextWriter(logFile);
            writer.Formatting = Formatting.Indented;
            writer.WriteStartObject();
            writer.WritePropertyName("Operations");
            writer.WriteStartArray();
        }

        public double DoOperation(double number1, double number2, string operation)
        {
            double result = double.NaN;

            writer.WriteStartObject();
            writer.WritePropertyName("Operand1");
            writer.WriteValue(number1);
            writer.WritePropertyName("Operand2");
            writer.WriteValue(number2);
            writer.WritePropertyName("Operation");

            switch (operation)
            {
                case "add":
                    result = number1 + number2;
                    writer.WriteValue("Add");
                    break;

                case "substract":
                    result = number1 - number2;
                    writer.WriteValue("Subtract");
                    break;

                case "multiply":
                    if (number1 >= 100000 || number2 >= 100000)
                    {
                        Console.WriteLine("You entered too large value, enter numbers up to 100000\n");
                        break;
                    }
                    result = number1 * number2;
                    writer.WriteValue("Multiply");
                    break;

                case "divide":
                    if (number2 != 0)
                    {
                        result = number1 / number2;
                    }
                    writer.WriteValue("Divide");
                    break;

                case "mod":
                    if (number2 != 0)
                    {
                        result = number1 % number2;
                    }
                    writer.WriteValue("Mod");
                    break;

                default:
                    Console.WriteLine("ERROR! You type incorrect value, type your option: ");
                    operation = Console.ReadLine();
                    break;
            }
            writer.WritePropertyName("Result");
            writer.WriteValue(result);
            writer.WriteEndObject();

            return result;
        }

        public void Finish()
        {
            writer.WriteEndArray();
            writer.WriteEndObject();
            writer.Close();
        }
    }
}