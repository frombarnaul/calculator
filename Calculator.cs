using System;

namespace ConsoleApp27
{
    class CalculatorEventArgs : EventArgs
    {
        public double answer;
    }

    class Calculator
    {
        public event EventHandler<CalculatorEventArgs> Result;
        private double result = 0;
        Stack<double> results = new Stack<double>();

        private void StartEvent()
        {
            Result?.Invoke(this, new CalculatorEventArgs { answer = result });
        }

        public void Run()
        {
            bool exitRequested = false;
            Console.WriteLine("Результат: " + result);
            do
            {
                Console.WriteLine("Выберите оператор (+, -, *, /) (или нажмите ESCAPE для отмены):");
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                Console.WriteLine();

                if (keyInfo.Key == ConsoleKey.Escape)
                {
                    Console.WriteLine("Калькулятор завершил работу");
                    break;
                }

                char op = keyInfo.KeyChar;

                if (op != '+' && op != '-' && op != '*' && op != '/')
                {
                    Console.WriteLine("Некорректный оператор. Пожалуйста, выберите из +, -, *, / или нажмите ESCAPE, чтобы выйти");
                    continue;
                }

                Console.WriteLine("Введите следующее число (или введите пустое значение или не число, чтобы выйти): ");
                string input = Console.ReadLine();

                double number;
                if (!double.TryParse(input, out number))
                {
                    Console.WriteLine("Калькулятор завершил работу");
                    break;
                }

                switch (op)
                {
                    case '+':
                        Add(number);
                        break;
                    case '-':
                        Sub(number);
                        break;
                    case '*':
                        Mul(number);
                        break;
                    case '/':
                        Div(number);
                        break;
                }

            } while (!exitRequested);
        }

        public void Add(double value)
        {
            results.Push(result);
            result += value;
            StartEvent();
        }

        public void Add(int value)
        {
            Add((double)value);
        }

        public void Sub(double value)
        {
            results.Push(result);
            result -= value;
            StartEvent();
        }

        public void Sub(int value)
        {
            Sub((double)value);
        }

        public void Mul(double value)
        {
            results.Push(result);
            result *= value;
            StartEvent();
        }

        public void Mul(int value)
        {
            Mul((double)value);
        }

        public void Div(double value)
        {
            if (value == 0)
            {
                Console.WriteLine("Деление на ноль недопустимо");
                return;
            }
            results.Push(result);
            result /= value;
            StartEvent();
        }

        public void Div(int value)
        {
            Div((double)value);
        }

        public void Cancel()
        {
            if (results.Count > 0)
            {
                result = results.Pop();
                StartEvent();
            }
        }
    }
}