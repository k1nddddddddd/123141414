using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace VolkovConsoleApplication
{
    public class VectorRW : Vector, IRead, IWrite
    {
        public VectorRW(int n) : base(n)
        {

        }

        public bool Read(string fileName)
        {
            bool res = true; // признак результата
            StreamReader reader = null;
            string str = string.Empty;
            try
            {
                reader = new StreamReader(fileName,
                    Encoding.Default);
                // чтение из файла
                str = reader.ReadLine();
            }
            catch (Exception ex)
            {
                Console.Write("Ошибка при чтении файла: ");
                Console.WriteLine(ex.Message);
                res = false; // признак результата - не удалось прочитать
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                    reader.Dispose();
                }
            }

            // проверка
            if (res == false || string.IsNullOrEmpty(str))
                return false;
            // получение значений из строки
            char[] del = { ' ', '\t' };
            string[] sub = str.Split(del);
            //
            List<double> values = new List<double>();
            double value;

            for (int i = 0; i < sub.Length; i++)
            {
                if (double.TryParse(sub[i], out value))
                    values.Add(value);
            }
            elements = values.ToArray();

            return res;
        }

        public bool Write(string fileName)
        {
            bool res = true; // признак результата
            StreamWriter writer = null;
            try
            {
                writer = new StreamWriter(fileName, false,
                    Encoding.Default);
                // запись в файл
                string str = ToString();
                writer.Write(str);
            }
            catch (Exception ex)
            {
                Console.Write("Ошибка при записи файла: ");
                Console.WriteLine(ex.Message);
                res = false;// признак результата - не получилось записать
            }
            finally
            {
                if (writer != null)
                {
                    writer.Close();// закрыть
                    writer.Dispose();// освободить ресурс
                }
            }

            return res;
        }
    }
}
