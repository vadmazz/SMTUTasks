﻿using System;
using System.Collections.Generic;
using System.IO;

namespace Task1
{
    //             Анализ
    //  - Подсчитать количество вхождений каждой буквы в строке
    //  - usecases: считать строку с клавиатуры
    //  -           получить количество вхождений букв
    //  - structures: Point-Точка [Считать из файла, Определить дистанцию до],
    //                Cut-Отрезок [Сериализовать из файла, Вычислить длину, Сравнить с числом]
    //  - decomposing: [Получить данные из файла, Получить длину строки из консоли, Сравнить, Вывести ответ]
    struct Cut
    {
        private Point _start;
        private Point _end;

        public void ReadFromFile(StreamReader sr)
        {
            _start.ReadFromFile(sr);
            _end.ReadFromFile(sr);
        }

        private double GetLength() =>
            _start.DistanceToPoint(_end);

        public string GetInfo() =>
            $"Start: {_start.GetInfo()}, \nEnd: {_end.GetInfo()}";

        public bool IsSmaller(double length) => GetLength() < length;
    }

    struct Point
    {
        private double _x;
        private double _y;

        public void ReadFromFile(StreamReader sr)
        {
            var wrap = sr.ReadLine().Split(' ');
            _x = double.Parse(wrap[0]);
            _y = double.Parse(wrap[1]);
        }
        public double DistanceToPoint(Point p) =>
            Math.Sqrt(Math.Pow(_x - p._x, 2) + Math.Pow(_y - p._y, 2));

        public string GetInfo() => $"X: {_x}, Y: {_y}";
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            var cuts = ReadCutsFromFile("Coordinates.txt");
            var length = double.Parse(Console.ReadLine());
            ShowSmallerCuts(cuts, length);
            Console.ReadKey();
        }

        private static void ShowSmallerCuts(List<Cut> cuts, double length)
        {
            foreach (var cut in cuts)
            {
                if (cut.IsSmaller(length))
                    Console.WriteLine(cut.GetInfo());
            }
        }
        private static List<Cut> ReadCutsFromFile(string path)
        {
            Console.WriteLine("Введите длину отрезка: ");
            var cuts = new List<Cut>();
            using (var streamReader = new StreamReader(path))
            {
                while (!streamReader.EndOfStream)
                {
                    var temp = new Cut();
                    temp.ReadFromFile(streamReader);
                    cuts.Add(temp);
                }
            }
            
            return cuts;
        }
    }
}