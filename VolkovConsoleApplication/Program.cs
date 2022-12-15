using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VolkovConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Программирование формул
            // Задача 1
            //Formula.Task1();
            #endregion

            #region Массивы
            // Задача 1. Ввод и вывод массива
            //Arrays.Task1();

            // Задача 2. Ввод, сортировка и вывод массива
            //Arrays.Task2();

            // Задача 3. Ввод и вывод матрицы
            //Arrays.Task3();

            // Задача 4. Ввод, быстрая сортировка и вывод массива
            // Arrays.Task4();

            // Задача 5. Ввод матрицы, сортировка элементов строк и
            // вывод матрицы
            //Arrays.Task5();

            #endregion

            #region Работа с файлами
            // Задача 1
            //Files.Task1();
            // Задача 2
            //Files.Task2();
            // Задача 3
            //Files.Task3();

            #endregion

            #region Объектно-ориентированное программирование
            // Задача 1
            //OOP.Task1();
            // Задача 2
            OOP.Task2();

            #endregion

            Console.Write(
                "Нажмите любую клавишу, чтобы завершить работу... ");
            Console.ReadKey();
        }
    }
}
