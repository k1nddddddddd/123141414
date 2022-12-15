using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VolkovConsoleApplication
{
    public class Formula
    {
        public static void Task1()
        {
            Console.WriteLine("Задача 1. Вычисление значения по формуле");
            // Ввод целого значения
            int x;
            if (IO.ReadValue("a", out x, true))
            {
                // Вывод
                Console.WriteLine(x);
            }
            // Ввод вещественного числа
            double y;
            if (IO.ReadValue("y", out y, true))
            {
                // Вывод 
                Console.WriteLine(y);
            }
        }
    }
}
