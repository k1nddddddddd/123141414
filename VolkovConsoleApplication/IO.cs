using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VolkovConsoleApplication
{
    public class IO
    {
        public static bool ReadValue(
            string name,
            out int value, bool showMessage)
        {
            value = 0;
            Console.Write(
                string.Format("Введите {0}: ", name));
            string str = Console.ReadLine();
            if (!int.TryParse(str, out value))
            {
                if (showMessage)
                    Console.WriteLine(
                        "Некорректное значение.");
                return false;
            }

            return true;
        }

        public static bool ReadValue(
            string name,
            out double value, bool showMessage)
        {
            value = 0;
            Console.Write(
                string.Format("Введите {0}: ", name));
            string str = Console.ReadLine();
            if (!double.TryParse(str, out value))
            {
                if (showMessage)
                    Console.WriteLine(
                        "Некорректное значение.");
                return false;
            }

            return true;
        }

    }
}
