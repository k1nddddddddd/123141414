using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VolkovConsoleApplication
{
    public class OOP
    {
        public static void Task1()
        {
            // Задача 1. Создание объектов
            Console.WriteLine("Задача 1. Создание объектов");
            // Создание экземпляра 
            Vector v = new Vector(3);
            // Применение индексатора
            v[0] = 1;
            v[1] = 2;
            v[2] = 3;
            // Использование свойства
            Console.Write("Количество элементов: ");
            Console.WriteLine(v.Size);
            Console.Write("Длина вектора: ");
            Console.WriteLine(v.Length);
            Console.Write("Элементы вектора: ");
            Console.WriteLine(v);
            // Использование функций
            v.Mult(2);
            Console.WriteLine("Умножение на число");
            Console.Write("Длина вектора: ");
            Console.WriteLine(v.Length);
            // Использование перегруженной функции
            Console.Write("Элементы вектора: ");
            Console.WriteLine(v.ToString());
            // Нормализация
            v.Normalize();
            Console.WriteLine("Нормализация вектора");
            Console.Write("Элементы вектора: ");
            Console.WriteLine(v);
            Console.Write("Длина вектора: ");
            Console.WriteLine(v.Length);

            // Создание экземпляра из существующего
            Vector w = new Vector(v);
            Console.Write("Элементы вектора: ");
            Console.WriteLine(w);
            Console.Write("Длина вектора: ");
            Console.WriteLine(w.Length);
        }

        public static void Task2()
        {
            // Создание экземпляров
            Vehicle v = new Vehicle("Траспортное средство", 20, 100);
            AirVehicle a = new AirVehicle("Вертолёт", 10, 4, 250);
            WaterVehicle w = new WaterVehicle("Баржа", 50, 400, 80);
            LandVehicle l = new LandVehicle("Лада Priora", 10, 4, 180);

            TestVehicle(v);
            v.Move(100, 200);
            TestVehicle(a);
            a.Fly(50, 40);
            TestVehicle(w);
            w.Sails(130, 60);
            TestVehicle(l);
            l.Roll(500, 4);
        }

        public static void TestVehicle(Vehicle v)
        {
            Console.Write(v.Name);
            Console.Write(": ");
            if(v is AirVehicle)
            {
                Console.WriteLine("Воздушный транспорт");
            }
            else if(v is WaterVehicle)
            {
                Console.WriteLine("Водный транспорт");
            }
            else if(v is LandVehicle)
            {
                Console.WriteLine("Наземный транспорт");
            }
            else
            {
                Console.WriteLine("Транспортное средство общего вида");
            }
        }
    }
}
