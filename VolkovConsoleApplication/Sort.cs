using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VolkovConsoleApplication
{
    public class Sort
    {
        public static bool SortMax(int[] a)
        {
            if (a == null)
                return false;
            int n = a.Length; // количество элементов
            int max;// максимальное значение
            int imax;// номер максимального значения

            for (int k = 1; k <= n - 1; k++)
            {
                // поиск максимального значения
                max = int.MinValue;
                imax = -1;
                for (int i = 0; i <= n - k; i++)
                {
                    if (max < a[i])
                    {
                        max = a[i];
                        imax = i;
                    }
                }
                // поменять местами
                a[imax] = a[n - k];
                a[n - k] = max;
            }

            return true;
        }

        public static void QuickSort(int[] a)
        {
            QuickSort(a, 0, a.Length - 1);
        }

        public static void QuickSort(int[] a, int p, int r)
        {
            if (p < r)
            {
                int q = Partition(a, p, r);
                QuickSort(a, p, q - 1);
                QuickSort(a, q + 1, r);
            }
        }
        public static int Partition(int[] a, int p, int r)
        {
            int x = a[r];
            int i = p - 1;
            int temp;
            for (int j = p; j <= r - 1; j++)
            {
                if (a[j] < x)
                {
                    i++;
                    temp = a[i];
                    a[i] = a[j];
                    a[j] = temp;
                }
            }
            temp = a[i + 1];
            a[i + 1] = a[r];
            a[r] = temp;

            return i + 1;
        }
    }
}
