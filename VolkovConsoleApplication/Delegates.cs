using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VolkovConsoleApplication
{
    /// <summary>
    /// Тип функции, реализующей операцию с целыми числами
    /// </summary>
    /// <param name="x">Число 1</param>
    /// <param name="y">Число 2</param>
    /// <returns>Целое числами</returns>
    public delegate int Operation(int x, int y);

    public class Delegates
    {
        public static void Task1()
        {
            // Задача 1. Использование делегатов
            Console.WriteLine("Задача 1. Использование делегатов");
            // Массив возможных операций
            Operation[] operations = new Operation[5];
            operations[0] = Sum;
            operations[1] = Dif;
            operations[2] = Mult;
            operations[3] = Div;
            operations[4] = DivEx;

            // Ввод исходных данных
            int x, y, operationIndex;
            if (!IO.ReadValue("число x", out x, true))
                return;
            if (!IO.ReadValue("число y", out y, true))
                return;
            Console.WriteLine("Список возможных операций:");
            Console.WriteLine("0 - Сложение");
            Console.WriteLine("1 - Вычитание");
            Console.WriteLine("2 - Умножение");
            Console.WriteLine("3 - Деление");
            Console.WriteLine("4 - Деление с обработкой исключений");
            if (!IO.ReadValue("номер операции", out operationIndex, true))
                return;
            // проверка корректности номера операции
            if (operationIndex < 0 || operationIndex >= 5)
            {
                Console.WriteLine("Номер операции должен быть от 0 до 4.");
                return;
            }
            Operation operation = operations[operationIndex];
            if (operationIndex == 3 && y == 0)
            {
                Console.WriteLine("Деление на 0 выполнить невозможно.");
                return;
            }
            // выполнение операции - применение делегата - вызов функции
            int res = operation(x, y);
            Console.Write("Результат: ");
            Console.WriteLine(res);
        }

        public static void Task2()
        {
            // Задача 1. Использование делегатов
            Console.WriteLine("Задача 1. Использование делегатов");
            // Массив возможных операций
            List<Operation> operations = new List<Operation>(5);
            operations.Add(Sum);
            operations.Add(Dif);
            operations.Add(Mult);
            operations.Add(Div);
            operations.Add(DivEx);

            // Ввод исходных данных
            int x, y, operationIndex;
            if (!IO.ReadValue("число x", out x, true))
                return;
            if (!IO.ReadValue("число y", out y, true))
                return;
            Console.WriteLine("Список возможных операций:");
            Console.WriteLine("0 - Сложение");
            Console.WriteLine("1 - Вычитание");
            Console.WriteLine("2 - Умножение");
            Console.WriteLine("3 - Деление");
            Console.WriteLine("4 - Деление с обработкой исключений");
            if (!IO.ReadValue("номер операции", out operationIndex, true))
                return;
            // проверка корректности номера операции
            if (operationIndex < 0 || operationIndex >= 5)
            {
                Console.WriteLine("Номер операции должен быть от 0 до 4.");
                return;
            }
            Operation operation = operations[operationIndex];
            if (operationIndex == 3 && y == 0)
            {
                Console.WriteLine("Деление на 0 выполнить невозможно.");
                return;
            }
            // выполнение операции - применение делегата - вызов функции
            int res = operation(x, y);
            Console.Write("Результат: ");
            Console.WriteLine(res);
        }

        public static int Sum(int x, int y)
        {
            return x + y;
        }

        public static int Dif(int x, int y)
        {
            return x - y;
        }

        public static int Mult(int x, int y)
        {
            return x * y;
        }

        public static int Div(int x, int y)
        {
            return x / y;
        }

        public static int DivEx(int x, int y)
        {
            int res = 0;

            try
            {
                res = x / y;
            }
            catch (Exception ex)
            {
                Console.Write("Ошибка при делении: ");
                Console.WriteLine(ex.Message);
            }

            return res;
        }
    }
}
