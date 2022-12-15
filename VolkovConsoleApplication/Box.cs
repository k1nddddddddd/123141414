using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VolkovConsoleApplication
{
    public class Box
    {
        int number;
        double width;
        double height;
        double depth;

        public Box()
        {
            number = 0;
            width = 0;
            height = 0;
            depth = 0;
        }

        public Box(int number, double width, double height, double depth)
        {
            // Инициализация параметров
            Number = number;
            Width = width;
            Height = height;
            Depth = depth;
        }

        public int Number
        {
            set
            {
                if (value < 0)
                    number = 0;
                else
                    number = value;
            }
            get { return number; }
        }

        public double Width
        {
            set
            {
                if (value < 0)
                    width = 0;
                else
                    width = value;
            }
        }

        public double Height
        {
            set
            {
                if (value < 0)
                    height = 0;
                else
                    height = value;
            }
            get { return height; }
        }

        public double Depth
        {
            set
            {
                if (value < 0)
                    depth = 0;
                else
                    depth = value;
            }
            get { return depth; }
        }

        public double GetSquare()
        {
            double s = 2 * (width * height + height * depth + width * depth);
            return s;
        }

        public double GetVolume()
        {
            double v = width * height * depth;
            return v;
        }

        public override string ToString()
        {
            // Динамическая строка
            StringBuilder str = new StringBuilder();
            str.Append("Номер: ");
            str.Append(number);
            str.Append(", ширина: ");
            str.Append(width);
            str.Append(", высота: ");
            str.Append(height);
            str.Append(", глубина: ");
            str.Append(depth);
            return str.ToString();
        }
    }
}
