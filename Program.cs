using System.Collections;
using System.ComponentModel;

delegate void MyDelegate();

namespace ConsoleApp27
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Calculator calculator = new Calculator();
            calculator.Result += Calculator_Result;

            calculator.Run();
        }

        private static void Calculator_Result(object? sender, CalculatorEventArgs e)
        {
            Console.WriteLine("Результат: " + e.answer);
        }
    }

}