using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace VolkovConsoleApplication
{
    public class Arrays
    {
        public static bool Input(string name, out int[] a)
        {
            a = null;
            // размерность массива
            int n;
            if (!IO.ReadValue("количество элементов массива",
                out n, true))
                return false;
            if (n < 1)
            {
                Console.WriteLine("Количество элементов массива должно быть больше 0.");
                return false;
            }
            // элементы массива name[0] = ...
            string format = name + "[{0}] = ";
            string str;
            bool success = true;
            int[] temp = new int[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write(string.Format(format, i));
                // ввести значение
                str = Console.ReadLine();
                if (!int.TryParse(str, out temp[i]))
                {
                    success = false;
                    break;// остановить цикл
                }
            }
            if (success)
                a = temp;

            return success;
        }

        public static void Output(string name, int[] a)
        {
            if (a == null)
                return;// если ссылка на массив пустая

            string format = name + "[{0}] = {1}";
            int n = a.Length;// размерность массива
            for (int i = 0; i < n; i++)
            {
                // форматированный вывод элементов массива
                Console.WriteLine(string.Format(format, i, a[i]));
            }
        }

        public static void Write(double[][] a)
        {
            // вывод матрицы в консоль
            int m = a.Length;
            int n;
            for (int i = 0; i < m; i++)
            {
                n = a[i].Length;
                for (int j = 0; j < n - 1; j++)
                {
                    Console.Write(a[i][j]);
                    Console.Write(' ');
                }
                Console.WriteLine(a[i][n - 1]);
            }
        }

        public static void Write(string fileName, double[][] a)
        {
            StreamWriter writer = new StreamWriter(fileName,
                false, Encoding.Default);

            // вывод матрицы в файл
            int m = a.Length;
            int n;
            for (int i = 0; i < m; i++)
            {
                n = a[i].Length;
                for (int j = 0; j < n - 1; j++)
                {
                    writer.Write(a[i][j]);
                    writer.Write(' ');
                }
                writer.WriteLine(a[i][n - 1]);
            }

            writer.Close();
        }

        public static void Write(string fileName, int[][] a)
        {
            StreamWriter writer = new StreamWriter(fileName,
                false, Encoding.Default);

            // вывод матрицы в файл
            int m = a.Length;
            int n;
            for (int i = 0; i < m; i++)
            {
                n = a[i].Length;
                for (int j = 0; j < n - 1; j++)
                {
                    writer.Write(a[i][j]);
                    writer.Write(' ');
                }
                writer.WriteLine(a[i][n - 1]);
            }

            writer.Close();
        }

        public static bool Read(string fileName, out double[][] a)
        {
            a = null;

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
            a = new double[m][];
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

            return true;
        }

        public static bool Read(string fileName, out int[][] a)
        {
            a = null;

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
            a = new int[m][];
            for (int i = 0; i < m; i++)
                a[i] = new int[n];
            // чтение элементов матрицы
            for (int i = 0; i < m; i++)
            {
                // читать строку
                s = reader.ReadLine();
                // разделить строку
                sub = s.Split(del);
                // получить элементы матрицы из массива строк
                for (int j = 0; j < n; j++)
                    a[i][j] = int.Parse(sub[j]);
            }

            // 3. Закрыть файл
            reader.Close();

            return true;
        }

        public static void Task1()
        {
            // Задача 1. Ввод и вывод массива
            Console.WriteLine("Задача 1. Ввод и вывод массива");

            // Ввод массива
            int[] a;
            if (!Input("a", out a))
                return;

            // Вывод массива
            Console.WriteLine("Массив:");
            Output("a", a);
        }

        public static void Task2()
        {
            // Задача 2. Ввод, сортировка и вывод массива
            Console.WriteLine("Задача 2. Ввод, сортировка и вывод массива");

            // Ввод массива
            int[] a;
            if (!Input("a", out a))
                return;

            // Сортировка
            Sort.SortMax(a);

            // Вывод массива
            Console.WriteLine("Массив:");
            Output("a", a);
        }

        public static void Task3()
        {
            /*
            int n = 3;
            double[][] a = new double[3][];
            for (int i = 0; i < n; i++)
                a[i] = new double[n];*/

            // Ввод матрицы
            double[][] a;
            Read("matrix.txt", out a);

            // Вывод матрицы
            Write("matrix2.txt", a);
        }

        public static void Task4()
        {
            // Задача 4. Ввод, быстрая сортировка и вывод массива
            Console.WriteLine("Задача 4. Ввод, быстрая сортировка и вывод массива");

            // Ввод массива
            int[] a;
            if (!Input("a", out a))
                return;

            // Сортировка
            Sort.QuickSort(a);

            // Вывод массива
            Console.WriteLine("Массив:");
            Output("a", a);
        }

        public static void Task5()
        {
            // Задача 5. Ввод матрицы, сортировка элементов строк матрицы, 
            // вывод матрицы
            Console.Write("Введите имя файла с матрицей: ");
            string fileName = Console.ReadLine();

            // Ввод матрицы
            int[][] a;
            Read(fileName, out a);

            for (int i = 0; i < a.Length; i++)
                Sort.QuickSort(a[i]);

            // Вывод матрицы
            Console.Write("Введите имя файла для матрицы: ");
            fileName = Console.ReadLine();
            Write(fileName, a);
        }
    }
}
