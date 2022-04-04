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
            double result = double.NaN; // Значение по умолчанию — «не число», если операция, такая как деление, может привести к ошибке..
            writer.WriteStartObject();
            writer.WritePropertyName("Operand1");
            writer.WriteValue(number1);
            writer.WritePropertyName("Operand2");
            writer.WriteValue(number2);
            writer.WritePropertyName("Operation");

            // Используем оператор switch, чтобы выполнить математические вычисления.
            switch (operation)
            {
                case "cotangent":
                    result = 1 / Math.Tan(number1);
                    writer.WriteValue("Cotangent");
                    break;
                case "tangent":
                    result = Math.Tan(number1);
                    writer.WriteValue("Tangent");
                    break;
                case "sqrt":
                    result = Math.Sqrt(number1);
                    writer.WriteValue("Sqrt");
                    break;
                case "cosinus":
                    result = Math.Cos(number1);
                    writer.WriteValue("Cosinus");
                    break;
                case "sinus":
                    result = Math.Sin(number1);
                    writer.WriteValue("Sinus");
                    break;
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
                case "mod":
                    if (number2 != 0)
                    {
                        result = number1 % number2;
                    }
                    writer.WriteValue("Mod");
                    break;
                case "divide":
                    // Просим пользователя ввести ненулевой делитель.
                    if (number2 != 0)
                    {
                        result = number1 / number2;
                    }
                    writer.WriteValue("Divide");
                    break;
                // Возвращаем текст для неверного ввода параметра.
                default:
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
