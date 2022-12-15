using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VolkovConsoleApplication
{
    public class Vector
    {
        double[] elements;

        public Vector(int n)
        {
            // выделение памяти для массива элементов
            elements = new double[n];
        }

        public Vector(Vector v)
        {
            elements = new double[v.elements.Length];
            for (int i = 0; i < elements.Length; i++)
                elements[i] = v.elements[i];
        }

        public int Size
        {
            get { return elements.Length; }
        }

        public double this[int index]
        {
            set { elements[index] = value; }
            get { return elements[index]; }
        }

        public double Length
        {
            get
            {
                double len = 0;
                for (int i = 0; i < elements.Length; i++)
                    len += elements[i] * elements[i];
                len = Math.Sqrt(len);

                return len;
            }
        }

        public void Mult(double a)
        {
            for (int i = 0; i < elements.Length; i++)
                elements[i] *= a;
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            // '1 2 3'
            for (int i = 0; i < elements.Length - 1; i++)
            {
                str.Append(elements[i]);
                str.Append(' ');
            }
            str.Append(elements[elements.Length - 1]);

            return str.ToString();
        }

        public void Normalize()
        {
            double len = Length;
            if (len > 0)
            {
                Mult(1.0 / len);
            }
        }

    }
}
