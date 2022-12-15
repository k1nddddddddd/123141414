using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace VolkovConsoleApplication
{
    public class Files
    {
        public static void Task1()
        {
            // Задача 1. Запись данных в файл
            Console.WriteLine("Задача 1. Запись данных в файл");
            // 1. Открыть файл для записи
            Console.Write("Введите имя файла: ");
            string fileName = Console.ReadLine();

            bool append = false;
            StreamWriter writer = new StreamWriter(fileName,
                append, Encoding.Default);
            // 2. Запись данных в файл
            // количество строк
            int n;
            if (IO.ReadValue("количество строк", out n, true))
            {
                string s;
                for (int i = 0; i < n; i++)
                {
                    // ввод строки
                    Console.Write("Введите строку: ");
                    s = Console.ReadLine();
                    // запись строки в файл
                    writer.WriteLine(s);
                }
            }
            // 3. Закрытие файла
            writer.Close();
        }

        public static void Task2()
        {
            // Задача 2. Чтение данных из файла
            Console.WriteLine("Задача 2. Чтение данных из файла");
            // Ввод имени файла
            Console.Write("Введите имя файла: ");
            string fileName = Console.ReadLine();
            // 1. Открыть файл для чтения
            StreamReader reader = new StreamReader(fileName,
                Encoding.Default);
            // 2. Прочитать данные из файла
            string s;
            while (!reader.EndOfStream)// EOF
            {
                // пока файл не закончился
                // прочитать одну строку
                s = reader.ReadLine();

                // Вывести в консоль
                Console.WriteLine(s);
            }

            // 3. Закрыть файл
            reader.Close();
        }

        public static void Task3()
        {
            // Задача 3. Чтение матрицы из файла
            Console.WriteLine("Задача 3. Чтение матрицы из файла");
            // Ввод имени файла
            Console.Write("Введите имя файла: ");
            string fileName = Console.ReadLine();
            // 1. Открыть файл для чтения
            StreamReader reader = new StreamReader(fileName,
                Encoding.Default);
            // 2. Прочитать данные из файла
            string s;
            // разделитель
            char[] del = { ' ' };
            // размерность матрицы
            int m;// количество строк
            int n;// количество столбцов

            s = reader.ReadLine();
            string[] sub = s.Split(del);
            m = int.Parse(sub[0]);
            n = int.Parse(sub[1]);
            // матрица (двумерный массив)
            double[][] a = new double[m][];
            for (int i = 0; i < m; i++)
                a[i] = new double[n];
            // чтение элементов матрицы
            for (int i = 0; i < m; i++)
            {
                // читать строку
                s = reader.ReadLine();
                // разделить строку
                sub = s.Split(del);
                // получить элементы матрицы из массива строк
                for (int j = 0; j < n; j++)
                    a[i][j] = double.Parse(sub[j]);
            }

            // 3. Закрыть файл
            reader.Close();

            // Вывод матрицы на консоль
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n - 1; j++)
                {
                    Console.Write(a[i][j]);
                    Console.Write(' ');
                }
                Console.WriteLine(a[i][n - 1]);
            }
        }
    }
}
