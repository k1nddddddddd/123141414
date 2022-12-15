using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VolkovConsoleApplication
{
    public class Cycles
    {
        public static void Task1()
        {
            // Задача 1. Ввод массивов 
            int n; // количество элементов
            string[] names = null;
            double[] values = null;

            // Ввод исходных данных
            if (!IO.ReadValue("количество элементов", out n, true))
                return;
            if (n <= 0)
            {
                Console.WriteLine("Количество элементов должно быть больше 0.");
                return;
            }
            // выделение памяти
            names = new string[n];
            values = new double[n];
            // ввод элементов
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Элемент " + (i + 1).ToString());
                Console.Write("Введите название: ");
                names[i] = Console.ReadLine();
                if (!IO.ReadValue("значение", out values[i], true))
                    return;
            }

            // Вывод элементов массива
            for (int i = 0; i < n; i++)
            {
                Console.Write("Элемент ");
                Console.Write(i + 1);
                Console.Write(": ");
                Console.Write(names[i]);
                Console.Write(" ");
                Console.WriteLine(values[i]);
            }
        }
    }
}
