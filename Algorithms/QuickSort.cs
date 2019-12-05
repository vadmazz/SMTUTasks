﻿using System;

namespace Algorithms
{
    class QuickSort
    {
        private int Partition<T>(T[] m, int a, int b)
            where T : IComparable<T>
        {
            int i = a;
            for (int j = a; j <= b; j++) // смотрим от a до b
            {
                if (m[j].CompareTo(m[b]) <= 0) //если элемент m[j] не превосходит m[b],
                {
                    T t = m[i]; // меняем местами m[j] и m[a]m, m[a+1]...
                    m[i] = m[j]; // то есть переносим элементы меньшие m[b] в начало
                    m[j] = t; // а затем и m[b] сверху
                    i++; // таким образом последний обмен: m[b] и m[i], после чего i++
                }
            }
            return i - 1;
        }

        private void quickSort<T>(T[] m, int a, int b) where T: IComparable<T>
        {
            if (a >= b) return;
            int c = Partition(m, a, b);
            quickSort(m, a, c - 1);
            quickSort(m, c + 1, b);
        }
    }
}
